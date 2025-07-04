using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TCT_EDI_Organizer.Models;
using static System.Windows.Forms.LinkLabel;

namespace TCT_EDI_Organizer.Services
{
    public class EdiParser
    {
        private readonly AppSettings _settings;

        public EdiParser(AppSettings settings)
        {
            _settings = settings;
        }

        public static string PadRightFixed(string input, int totalLength)
        {
            return input.Length >= totalLength
                ? input.Substring(0, totalLength)
                : input.PadRight(totalLength, ' ');
        }

        public static List<string> CheckListContent(List<string> lines322, int countOf322, int line322Id, List<string> lines329, int countOf329, int line329Id)
        {
            List<string> errors = new List<string>();
            bool columnsCheck = true;

            var line322NaValues = lines322.Where(c => c.StartsWith("!NA")).ToList();
            if (line322NaValues != null && line322NaValues.Count > 0)
            {
                foreach (var item in line322NaValues)
                {
                    string erro = item.Split(new string[] { "!NA;" }, StringSplitOptions.None)[1].Trim();
                    errors.Add($"linha {line322Id + 1}: " + erro);
                    columnsCheck = false;
                }
            }

            var line329NaValues = lines329.Where(c => c.StartsWith("!NA")).ToList();
            if (line329NaValues != null && line329NaValues.Count > 0)
            {
                foreach (var item in line329NaValues)
                {
                    string erro = item.Split(new string[] { "!NA;" }, StringSplitOptions.None)[1].Trim();
                    errors.Add($"linha {line322Id + 1}: " + erro);
                    columnsCheck = false;
                }
            }

            if (!columnsCheck)
            {
                return errors;
            }


            if (lines322 == null || (lines322 != null && lines322.Count != countOf322))
            {
                errors.Add($"linha {line322Id + 1} inválida (colunas faltando ou excedente)");
            }

            if (lines329 == null || (lines329 != null && lines329.Count != countOf329))
            {
                errors.Add($"linha {line329Id + 1} inválida (colunas faltando ou excedente)");
            }


            return errors;
        }

        public void ParseNew(string[] fileLines)
        {
            for (int i = 0; i < fileLines.Length; i++)
            {
                if (fileLines[i].StartsWith("322"))
                {
                    string line322Text = fileLines[i];
                    string line329Text = FindCorrespondingLine(fileLines, i + 1, "329");

                    Parse322New(line322Text, i);
                    Parse329New(line329Text, i + 1);
                }
            }
        }

        public AppResult Parse(string[] fileLines)
        {
            var results = new List<DecodedRecord>();
            var outpuData = new AppResult();


            for (int i = 0; i < fileLines.Length; i++)
            {
                if (fileLines[i].StartsWith("322"))
                {
                    string line322 = fileLines[i];
                    string line329 = FindCorrespondingLine(fileLines, i + 1, "329");

                    var parsed322line = Parse322(line322);
                    var parsed329line = Parse329(line329);

                    var errorList = CheckListContent(parsed322line, 48, i, parsed329line, 12, i + 1);
                    List<string> warningList = new List<string>();

                    if (errorList != null && errorList.Count > 0)
                    {
                        outpuData.ErrorList.AddRange(errorList);
                        continue;
                    }

                    //Protocolo
                    string protocol = parsed322line[3];

                    //Filial
                    var foundBranch = _settings.Branches.FirstOrDefault(b => b.EdiCode == parsed322line[1]);

                    if (int.TryParse(parsed322line[2], out _))
                    {
                        int currentBranchCode = int.Parse(parsed322line[2]);

                        if (currentBranchCode == foundBranch.EvenCode)
                        {
                            errorList.Add($"linha {i + 1}: Filial com código PAR");
                        }
                        else if (currentBranchCode != foundBranch.OddCode)
                        {
                            errorList.Add($"linha {i + 1}: Filial com código INVÁLIDO");
                        }
                    }
                    else if (parsed322line[2] != "ND")
                    {
                        errorList.Add($"linha {i + 1}: Filial com código INVÁLIDO");
                    }

                    if (parsed322line[2] == "ND")
                    {
                        if (!parsed329line[5].EndsWith("ND"))
                        {
                            errorList.Add($"linha {i + 1 + 1}: Nota de débito INVÁLIDA");
                        }
                    }

                    if (parsed322line[2] != parsed329line[6])
                    {
                        errorList.Add($"linha {i + 1}: Filial com códigos DIFERENTES");
                        errorList.Add($"linha {i + 1 + 1}: Filial com códigos DIFERENTES");
                    }

                    //Tipo de Protocolo
                    string protocolType = parsed329line[3];
                    bool isDedicatedProtocol = protocolType.All(c => c == '0' || c == '1');

                    if (isDedicatedProtocol && protocolType != "000001")
                    {
                        warningList.Add($"linha {i + 1 + 1}: Tipo de protocolo com valor INVÁLIDO (quantidade de zeros)");
                        parsed329line[3] = "000001";
                    }

                    //CONFIGURAR VEICULOS

                    outpuData.DecodedProtocols.Add(new DecodedProtocol
                    {
                        Protocol = protocol,
                        Line322 = parsed322line,
                        Line329 = parsed329line,
                    });

                    outpuData.ErrorList.AddRange(errorList);
                    outpuData.WarningList.AddRange(warningList);

                }
            }

            return outpuData;
        }

        private List<string> Parse329(string line329)
        {
            const string lineCode = "329";
            var lineList = new List<string> { lineCode };

            var regexVehicle = new Regex(@"329\s*([A-Z0-9]+)\s+");
            var matchVehicle = regexVehicle.Match(line329);

            var vehicleCode = matchVehicle.Success ? matchVehicle.Groups[1].Value.Trim() : "!NA;Código de veículo INVÁLIDO";
            lineList.Add(vehicleCode);

            var fullMatchedPrefix = matchVehicle.Success ? matchVehicle.Groups[0].Value : string.Empty;
            var lineRemainder = line329.Substring(fullMatchedPrefix.Length);

            var columns = Regex.Split(lineRemainder, @"\s+").Where(c => !string.IsNullOrWhiteSpace(c));
            lineList.AddRange(columns);

            return lineList;
        }

        private List<string> Parse322(string line322)
        {
            const string lineCode = "322";
            var lineList = new List<string> { lineCode };

            var lineRemainder = line322.Substring(3); // remove "322"

            var foundBranch = _settings.Branches.FirstOrDefault(b => lineRemainder.StartsWith(b.EdiCode));
            var branchCode = foundBranch?.EdiCode ?? "!NA;Filial INVÁLIDA";
            lineList.Add(branchCode);

            if (branchCode == "!NA;Filial INVÁLIDA")
            {
                return lineList;
            }

            var afterBranchCode = foundBranch != null
                ? lineRemainder.Substring(foundBranch.EdiCode.Length).Trim()
                : lineRemainder.Trim();

            var regexProtocol = new Regex(@"^(ND|\d)\s*(\d+)\s*(.*)$");
            var matchProtocol = regexProtocol.Match(afterBranchCode);

            var branchNumber = matchProtocol.Success ? matchProtocol.Groups[1].Value.Trim() : "!NA;Filial com posição ERRADA";
            var protocolNumber = matchProtocol.Success ? matchProtocol.Groups[2].Value.Trim() : "!NA;Protocolo com posição ERRADA";
            var remainingData = matchProtocol.Success ? matchProtocol.Groups[3].Value.Trim() : string.Empty;

            lineList.Add(branchNumber);
            lineList.Add(protocolNumber);

            var columns = Regex.Split(remainingData, @"\s+").Where(c => !string.IsNullOrWhiteSpace(c));
            lineList.AddRange(columns);

            return lineList;
        }

        private EdiLine Parse329New(string line329Text, int lineId)
        {
            int expectedColumns = 12;
            int expectedRemainingColumns = 10;
            int expectedNonRemainingColumns = expectedColumns - expectedRemainingColumns;
            int[] skippedColumns = new int[] { 7 };


            EdiLine line329 = new EdiLine(lineId, "329");

            var regexStart329 = new Regex(@"^(329)\s*([A-Z0-9]+)\s+");
            var matchStart329 = regexStart329.Match(line329Text);

            if (matchStart329.Success)
            {

                string remainingLineText = line329Text.Substring(matchStart329.Length);
                var remainingColumnsRegex = new Regex(@"\s+");
                var ramainingColumn = remainingColumnsRegex
                    .Split(remainingLineText)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Select(s => s.Trim()).ToList();

                if (ramainingColumn != null && ramainingColumn.Count == expectedRemainingColumns)
                {
                    line329.AddValidColumn(0, "329");

                    string vehicleCodetext = matchStart329.Groups[2].Value.Trim();
                    string collectTypeText = ramainingColumn[5].Trim();

                    //VALIDAÇÃO - VEÍCULOS
                    ValidateVehicle(line329, vehicleCodetext);

                    //VALIDAÇÃO - TIPO E COLETA
                    ValidateCollectType(line329, collectTypeText);

                    for (int c = 0; c < ramainingColumn.Count; c++)
                    {
                        if (!skippedColumns.Contains(c + expectedNonRemainingColumns))
                        {
                            line329.AddValidColumn(c + expectedNonRemainingColumns, ramainingColumn[c].ToString());

                        }
                    }
                }
                else
                {
                    line329.AddInvalidColumn(0, line329Text, $"Quantidade inválida de colunas. {(ramainingColumn.Count + expectedNonRemainingColumns):000} <> 012");
                }

            }
            else
            {
                line329.AddInvalidColumn(0, line329Text, "Início da linha com formato inválido.");
            }

            line329.HasErrors = line329.Columns.Any(c => !c.IsValidated);
            var errorColumns = GetErrorColumns(line329);


            return line329;
        }

        private EdiLine Parse322New(string line322Text, int lineId)
        {
            int expectedColumns = 48;
            int expectedRemainingColumns = 45;
            int expectedNonRemainingColumns = expectedColumns - expectedRemainingColumns;
            int[] skippedColumns = new int[] { };

            EdiLine line322 = new EdiLine(lineId, "322");

            var regexStart322 = new Regex(@"^(322)\s*([\p{L}\s]+?)(\d+|ND)", RegexOptions.IgnoreCase);
            var matchStart322 = regexStart322.Match(line322Text);

            if (matchStart322.Success)
            {

                string remainingLineText = line322Text.Substring(matchStart322.Length);
                var remainingColumnsRegex = new Regex(@"\s+");
                var ramainingColumn = remainingColumnsRegex
                    .Split(remainingLineText)
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .Select(s => s.Trim()).ToList();

                if (ramainingColumn != null && ramainingColumn.Count == expectedRemainingColumns)
                {
                    line322.AddValidColumn(0, "322");

                    string branchNameText = matchStart322.Groups[2].Value.Trim();
                    string branchCodeText = matchStart322.Groups[3].Value.Trim();

                    //VALIDAÇÃO - FILIAL
                    ValidateBranch(line322, branchNameText, branchCodeText);

                    for (int c = 0; c < ramainingColumn.Count; c++)
                    {

                        if (!skippedColumns.Contains(c + expectedNonRemainingColumns))
                        {
                            line322.AddValidColumn(c + expectedNonRemainingColumns, ramainingColumn[c].ToString());

                        }
                    }
                }
                else
                {
                    line322.AddInvalidColumn(0, line322Text, $"Quantidade inválida de colunas. {(ramainingColumn.Count + expectedNonRemainingColumns):000} <> 048");
                }
            }
            else
            {
                line322.AddInvalidColumn(0, line322Text, "Início da linha com formato inválido.");
            }

            line322.HasErrors = line322.Columns.Any(c => !c.IsValidated);
            var errorColumns = GetErrorColumns(line322);

            return line322;
        }

        private List<EdiColumn> GetErrorColumns(EdiLine ediLine)
        {
            var errorColumns = ediLine.Columns.Where(w => w.IsValidated).ToList();

            if(errorColumns != null && errorColumns.Count > 0)
            {
                var deepCloneErrorColumns = JsonConvert.DeserializeObject<List<EdiColumn>>(
                JsonConvert.SerializeObject(errorColumns));

                return deepCloneErrorColumns;
            }

            return new List<EdiColumn>();            
        }

        private void ValidateCollectType(EdiLine line, string collectTypeText)
        {
            var foundCollectType = _settings.Collections.FirstOrDefault(b => b.Code == collectTypeText);

            if (foundCollectType != null)
            {
                line.AddValidColumn(7, collectTypeText);
            }
            else
            {
                line.AddInvalidColumn(7, collectTypeText, "Código de tipo de coleta inválido");
            }
        }

        private void ValidateVehicle(EdiLine line, string vehicleCodeText)
        {
            var foundVehicle = _settings.Vehicles.FirstOrDefault(b => b.Code == vehicleCodeText);

            if (foundVehicle != null)
            {
                line.AddValidColumn(1, vehicleCodeText);
            }
            else
            {
                line.AddInvalidColumn(1, vehicleCodeText, "Código de veículo inválido");
            }
        }

        private void ValidateBranch(EdiLine line, string branchNameText, string branchCodeText)
        {
            var foundBranch = _settings.Branches.FirstOrDefault(b => b.EdiCode == branchNameText);

            if (foundBranch != null)
            {
                line.AddValidColumn(1, branchNameText);

                if (int.TryParse(branchCodeText, out var branchCode))
                {
                    if (branchCode % 2 > 0)
                    {
                        line.AddValidColumn(2, branchCodeText);
                    }
                    else
                    {
                        line.AddInvalidColumn(2, branchCodeText, "Código da filial com valor par.");
                    }
                }
                else if (branchCodeText == "ND")
                {
                    line.AddValidColumn(2, branchCodeText);
                }
                else
                {
                    line.AddInvalidColumn(2, branchCodeText, "Código da filial inválido.");
                }
            }
            else
            {
                line.AddInvalidColumn(1, branchNameText, "Filial não encontrado nas configurações.");
                line.AddValidColumn(2, branchCodeText);
            }
        }

        private string FindCorrespondingLine(string[] lines, int startIndex, string prefix)
        {
            for (int i = startIndex; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(prefix)) return lines[i];
                if (lines[i].StartsWith("322") || lines[i].StartsWith("323")) return null;
            }
            return null;
        }

    }
}
