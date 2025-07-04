using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using TCT_EDI_Organizer.Models;

namespace TCT_EDI_Organizer.Services
{
    public static class ConfigManager
    {
        private static readonly string ConfigFilePath = Path.Combine(Application.StartupPath, "settings.json");

        public static AppSettings LoadSettings()
        {
            if (File.Exists(ConfigFilePath))
            {
                try
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    return JsonConvert.DeserializeObject<AppSettings>(json);
                }
                catch // Em caso de arquivo corrompido ou erro de leitura
                {
                    // Retorna configurações padrão se houver erro
                    return CreateDefaultSettings();
                }
            }
            else
            {
                return CreateDefaultSettings();
            }
        }

        public static void SaveSettings(AppSettings settings)
        {
            try
            {
                // O Formatting.Indented torna o arquivo JSON legível para humanos
                string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Erro ao salvar as configurações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static AppSettings CreateDefaultSettings()
        {
            var defaultSettings = new AppSettings();
            // Podemos popular com um exemplo inicial
            //defaultSettings.Vehicles.Add(new VehicleConfig { Name = "Carreta 3 eixos", Code = "C3" });
            //defaultSettings.Branches.Add(new BranchConfig { Name = "São Bernado do Campo", OddCode = 1, EvenCode = 2, EdiCode = "SÃO BERNAR" });
            //defaultSettings.Collections.Add(new CollectionConfig { Name = "Centro de Consolidação de Carga", Code = "CCC" });

            

            SaveSettings(defaultSettings); // Salva o novo arquivo padrão
            return defaultSettings;
        }
    }
}
