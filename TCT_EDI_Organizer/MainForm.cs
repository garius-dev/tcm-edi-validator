using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCT_EDI_Organizer.Models;
using TCT_EDI_Organizer.Services;

namespace TCT_EDI_Organizer
{
    public partial class MainForm : Form
    {

        private AppSettings _settings;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _settings = ConfigManager.LoadSettings();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            

            if (configForm.ShowDialog() == DialogResult.OK)
            {
                _settings = ConfigManager.LoadSettings();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
                openFileDialog.Title = "Selecione o arquivo EDI";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    //lblStatus.Text = $"Arquivo carregado: {filePath}";


                    try
                    {
                        // Lê as linhas do arquivo
                        string[] ediLines = System.IO.File.ReadAllLines(filePath);

                        // Cria uma instância do nosso parser com as configurações atuais
                        var parser = new EdiParser(_settings);

                        string resultadoFinal = "PASSOU";

                        //// Executa a decodificação
                        //var decodedData = parser.Parse(ediLines);
                        parser.ParseNew(ediLines);

                        //List<FinalResultsErros> finalResultsErros = new List<FinalResultsErros>();

                        //if(decodedData.ErrorList != null && decodedData.ErrorList.Count > 0)
                        //{
                        //    resultadoFinal = "FALHOU";

                        //    foreach (var item in decodedData.ErrorList)
                        //    {
                        //        var splitResult = item.Split(':');
                        //        string linha = splitResult[0].Replace("linha", string.Empty).Trim();
                        //        string erro = splitResult[1].Trim();
                        //        finalResultsErros.Add(new FinalResultsErros
                        //        {
                        //            Line = linha,
                        //            Erro = erro
                        //        });
                        //    }
                        //}

                        //if (decodedData.WarningList != null && decodedData.WarningList.Count > 0)
                        //{
                        //    resultadoFinal = "AVISO";

                        //    foreach (var item in decodedData.WarningList)
                        //    {
                        //        var splitResult = item.Split(':');
                        //        string linha = splitResult[0].Replace("linha", string.Empty).Trim();
                        //        string erro = splitResult[1].Trim();
                        //        finalResultsErros.Add(new FinalResultsErros
                        //        {
                        //            Line = linha,
                        //            Erro = erro
                        //        });
                        //    }
                        //}

                        //dgvErrors.DataSource = new BindingSource { DataSource = finalResultsErros };
                        //dgvErrors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        //lblFinalResult.Text = resultadoFinal;

                        //if (resultadoFinal == "PASSOU")
                        //{
                        //    lblFinalResult.ForeColor = Color.Green;
                        //}
                        //else if(resultadoFinal == "AVISO")
                        //{
                        //    lblFinalResult.ForeColor = Color.Orange;
                        //}
                        //else
                        //{
                        //    lblFinalResult.ForeColor = Color.Red;
                        //}

                        ////// Exibe os resultados na grade
                        //////dgvResults.DataSource = decodedData;

                        ////int errorCount = decodedData.Count(rec => rec.Status == "Erro");
                        ////lblStatus.Text = $"Arquivo processado. {decodedData.Count} registros encontrados ({errorCount} com erros).";
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Ocorreu um erro ao ler ou processar o arquivo: {ex.Message}", "Erro de Processamento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //lblStatus.Text = "Falha no processamento.";
                    }

                    //MessageBox.Show("A lógica para processar o arquivo será adicionada no próximo passo.", "Em breve");
                }
            }
        }
    }
}
