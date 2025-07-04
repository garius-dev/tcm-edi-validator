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
    public partial class ConfigForm : Form
    {
        private AppSettings _settings;

        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            // Carrega as configurações quando o formulário é aberto
            _settings = ConfigManager.LoadSettings();

            // Vincula os dados das configurações aos DataGridViews
            // O BindingSource ajuda a gerenciar a ligação de dados de forma mais robusta
            dgvVehicles.DataSource = new BindingSource { DataSource = _settings.Vehicles };
            dgvBranches.DataSource = new BindingSource { DataSource = _settings.Branches };
            dgvCollections.DataSource = new BindingSource { DataSource = _settings.Collections };
            dgv322.DataSource = new BindingSource { DataSource = _settings.Positions322 };
            dgv329.DataSource = new BindingSource { DataSource = _settings.Positions329 };

            // Ajusta as colunas para preencher o espaço
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBranches.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCollections.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Força o fim da edição no DataGridView para garantir que os dados sejam atualizados
            this.Validate();

            // Salva as configurações (que foram atualizadas automaticamente pela ligação de dados)
            ConfigManager.SaveSettings(_settings);

            MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK; // Sinaliza que as configs foram salvas
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
