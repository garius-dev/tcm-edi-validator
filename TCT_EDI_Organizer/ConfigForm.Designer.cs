namespace TCT_EDI_Organizer
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.dgvBranches = new System.Windows.Forms.DataGridView();
            this.dgvCollections = new System.Windows.Forms.DataGridView();
            this.grpVeichles = new System.Windows.Forms.GroupBox();
            this.grpBranches = new System.Windows.Forms.GroupBox();
            this.grpCollections = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv322 = new System.Windows.Forms.DataGridView();
            this.dgv329 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollections)).BeginInit();
            this.grpVeichles.SuspendLayout();
            this.grpBranches.SuspendLayout();
            this.grpCollections.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv322)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv329)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVehicles.Location = new System.Drawing.Point(18, 33);
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.RowHeadersWidth = 51;
            this.dgvVehicles.RowTemplate.Height = 24;
            this.dgvVehicles.Size = new System.Drawing.Size(461, 214);
            this.dgvVehicles.TabIndex = 0;
            // 
            // dgvBranches
            // 
            this.dgvBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBranches.Location = new System.Drawing.Point(18, 33);
            this.dgvBranches.Name = "dgvBranches";
            this.dgvBranches.RowHeadersWidth = 51;
            this.dgvBranches.RowTemplate.Height = 24;
            this.dgvBranches.Size = new System.Drawing.Size(956, 206);
            this.dgvBranches.TabIndex = 1;
            // 
            // dgvCollections
            // 
            this.dgvCollections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCollections.Location = new System.Drawing.Point(18, 33);
            this.dgvCollections.Name = "dgvCollections";
            this.dgvCollections.RowHeadersWidth = 51;
            this.dgvCollections.RowTemplate.Height = 24;
            this.dgvCollections.Size = new System.Drawing.Size(453, 214);
            this.dgvCollections.TabIndex = 2;
            // 
            // grpVeichles
            // 
            this.grpVeichles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVeichles.Controls.Add(this.dgvVehicles);
            this.grpVeichles.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVeichles.Location = new System.Drawing.Point(515, 284);
            this.grpVeichles.Name = "grpVeichles";
            this.grpVeichles.Padding = new System.Windows.Forms.Padding(18);
            this.grpVeichles.Size = new System.Drawing.Size(497, 265);
            this.grpVeichles.TabIndex = 3;
            this.grpVeichles.TabStop = false;
            this.grpVeichles.Text = "Veículos";
            // 
            // grpBranches
            // 
            this.grpBranches.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBranches.Controls.Add(this.dgvBranches);
            this.grpBranches.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBranches.Location = new System.Drawing.Point(20, 17);
            this.grpBranches.Name = "grpBranches";
            this.grpBranches.Padding = new System.Windows.Forms.Padding(18);
            this.grpBranches.Size = new System.Drawing.Size(992, 257);
            this.grpBranches.TabIndex = 4;
            this.grpBranches.TabStop = false;
            this.grpBranches.Text = "Filiais";
            // 
            // grpCollections
            // 
            this.grpCollections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCollections.Controls.Add(this.dgvCollections);
            this.grpCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCollections.Location = new System.Drawing.Point(20, 284);
            this.grpCollections.Name = "grpCollections";
            this.grpCollections.Padding = new System.Windows.Forms.Padding(18);
            this.grpCollections.Size = new System.Drawing.Size(489, 265);
            this.grpCollections.TabIndex = 5;
            this.grpCollections.TabStop = false;
            this.grpCollections.Text = "Tipos de Coleta";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(725, 627);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(161, 50);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Crimson;
            this.btnClose.Location = new System.Drawing.Point(892, 627);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 50);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1045, 603);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpBranches);
            this.tabPage1.Controls.Add(this.grpVeichles);
            this.tabPage1.Controls.Add(this.grpCollections);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1037, 574);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Códigos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dgv329);
            this.tabPage2.Controls.Add(this.dgv322);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1037, 574);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Posições";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv322
            // 
            this.dgv322.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv322.Location = new System.Drawing.Point(25, 56);
            this.dgv322.Name = "dgv322";
            this.dgv322.RowHeadersWidth = 51;
            this.dgv322.RowTemplate.Height = 24;
            this.dgv322.Size = new System.Drawing.Size(320, 478);
            this.dgv322.TabIndex = 0;
            // 
            // dgv329
            // 
            this.dgv329.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv329.Location = new System.Drawing.Point(372, 56);
            this.dgv329.Name = "dgv329";
            this.dgv329.RowHeadersWidth = 51;
            this.dgv329.RowTemplate.Height = 24;
            this.dgv329.Size = new System.Drawing.Size(320, 478);
            this.dgv329.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "322";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "329";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 689);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigForm";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollections)).EndInit();
            this.grpVeichles.ResumeLayout(false);
            this.grpBranches.ResumeLayout(false);
            this.grpCollections.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv322)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv329)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehicles;
        private System.Windows.Forms.DataGridView dgvBranches;
        private System.Windows.Forms.DataGridView dgvCollections;
        private System.Windows.Forms.GroupBox grpVeichles;
        private System.Windows.Forms.GroupBox grpBranches;
        private System.Windows.Forms.GroupBox grpCollections;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv329;
        private System.Windows.Forms.DataGridView dgv322;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}