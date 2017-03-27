namespace lab_mpp
{
    partial class MainView
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
            this.components = new System.ComponentModel.Container();
            this.clienticurseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.firmatransportDataSet = new lab_mpp.firmatransportDataSet();
            this.clienti_curseTableAdapter = new lab_mpp.firmatransportDataSetTableAdapters.clienti_curseTableAdapter();
            this.listViewCurse = new System.Windows.Forms.ListView();
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Destinatie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Data_Ora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NrLocuri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewClienti = new System.Windows.Forms.ListView();
            this.NrLoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NumeClient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtDestinatie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtNumeClient = new System.Windows.Forms.TextBox();
            this.txtNrLocuri = new System.Windows.Forms.TextBox();
            this.btnRezervare = new System.Windows.Forms.Button();
            this.btnCauta = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clienticurseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmatransportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // clienticurseBindingSource
            // 
            this.clienticurseBindingSource.DataMember = "clienti_curse";
            this.clienticurseBindingSource.DataSource = this.firmatransportDataSet;
            // 
            // firmatransportDataSet
            // 
            this.firmatransportDataSet.DataSetName = "firmatransportDataSet";
            this.firmatransportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clienti_curseTableAdapter
            // 
            this.clienti_curseTableAdapter.ClearBeforeFill = true;
            // 
            // listViewCurse
            // 
            this.listViewCurse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Id,
            this.Destinatie,
            this.Data_Ora,
            this.NrLocuri});
            this.listViewCurse.FullRowSelect = true;
            this.listViewCurse.Location = new System.Drawing.Point(12, 12);
            this.listViewCurse.Name = "listViewCurse";
            this.listViewCurse.Size = new System.Drawing.Size(273, 369);
            this.listViewCurse.TabIndex = 0;
            this.listViewCurse.UseCompatibleStateImageBehavior = false;
            this.listViewCurse.View = System.Windows.Forms.View.Details;
            this.listViewCurse.SelectedIndexChanged += new System.EventHandler(this.listViewCurse_SelectedIndexChanged);
            // 
            // Id
            // 
            this.Id.Text = "Id";
            this.Id.Width = 25;
            // 
            // Destinatie
            // 
            this.Destinatie.Text = "Destinatie";
            this.Destinatie.Width = 76;
            // 
            // Data_Ora
            // 
            this.Data_Ora.Text = "DataOra";
            this.Data_Ora.Width = 111;
            // 
            // NrLocuri
            // 
            this.NrLocuri.Text = "NrLocuri";
            this.NrLocuri.Width = 55;
            // 
            // listViewClienti
            // 
            this.listViewClienti.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NrLoc,
            this.NumeClient});
            this.listViewClienti.Location = new System.Drawing.Point(495, 12);
            this.listViewClienti.Name = "listViewClienti";
            this.listViewClienti.Size = new System.Drawing.Size(168, 369);
            this.listViewClienti.TabIndex = 1;
            this.listViewClienti.UseCompatibleStateImageBehavior = false;
            this.listViewClienti.View = System.Windows.Forms.View.Details;
            // 
            // NrLoc
            // 
            this.NrLoc.Text = "NrLoc";
            this.NrLoc.Width = 51;
            // 
            // NumeClient
            // 
            this.NumeClient.Text = "Nume Client";
            this.NumeClient.Width = 113;
            // 
            // txtDestinatie
            // 
            this.txtDestinatie.Location = new System.Drawing.Point(360, 66);
            this.txtDestinatie.Name = "txtDestinatie";
            this.txtDestinatie.Size = new System.Drawing.Size(129, 20);
            this.txtDestinatie.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(344, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cautare:";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(360, 92);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(129, 20);
            this.txtData.TabIndex = 4;
            // 
            // txtNumeClient
            // 
            this.txtNumeClient.Location = new System.Drawing.Point(360, 241);
            this.txtNumeClient.Name = "txtNumeClient";
            this.txtNumeClient.Size = new System.Drawing.Size(129, 20);
            this.txtNumeClient.TabIndex = 5;
            // 
            // txtNrLocuri
            // 
            this.txtNrLocuri.Location = new System.Drawing.Point(360, 267);
            this.txtNrLocuri.Name = "txtNrLocuri";
            this.txtNrLocuri.Size = new System.Drawing.Size(129, 20);
            this.txtNrLocuri.TabIndex = 6;
            // 
            // btnRezervare
            // 
            this.btnRezervare.Location = new System.Drawing.Point(360, 293);
            this.btnRezervare.Name = "btnRezervare";
            this.btnRezervare.Size = new System.Drawing.Size(129, 35);
            this.btnRezervare.TabIndex = 7;
            this.btnRezervare.Text = "Rezervare";
            this.btnRezervare.UseVisualStyleBackColor = true;
            // 
            // btnCauta
            // 
            this.btnCauta.Location = new System.Drawing.Point(360, 118);
            this.btnCauta.Name = "btnCauta";
            this.btnCauta.Size = new System.Drawing.Size(129, 23);
            this.btnCauta.TabIndex = 8;
            this.btnCauta.Text = "Cauta";
            this.btnCauta.UseVisualStyleBackColor = true;
            this.btnCauta.Click += new System.EventHandler(this.btnCauta_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(360, 147);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(129, 23);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(344, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rezervare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Destinatie:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nume Client:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Numar Locuri:";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 393);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCauta);
            this.Controls.Add(this.btnRezervare);
            this.Controls.Add(this.txtNrLocuri);
            this.Controls.Add(this.txtNumeClient);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestinatie);
            this.Controls.Add(this.listViewClienti);
            this.Controls.Add(this.listViewCurse);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "MainView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clienticurseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmatransportDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private firmatransportDataSet firmatransportDataSet;
        private System.Windows.Forms.BindingSource clienticurseBindingSource;
        private firmatransportDataSetTableAdapters.clienti_curseTableAdapter clienti_curseTableAdapter;
        private System.Windows.Forms.ListView listViewCurse;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.ColumnHeader Destinatie;
        private System.Windows.Forms.ColumnHeader Data_Ora;
        private System.Windows.Forms.ColumnHeader NrLocuri;
        private System.Windows.Forms.ListView listViewClienti;
        private System.Windows.Forms.ColumnHeader NrLoc;
        private System.Windows.Forms.ColumnHeader NumeClient;
        private System.Windows.Forms.TextBox txtDestinatie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtNumeClient;
        private System.Windows.Forms.TextBox txtNrLocuri;
        private System.Windows.Forms.Button btnRezervare;
        private System.Windows.Forms.Button btnCauta;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

