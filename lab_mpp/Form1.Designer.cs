namespace lab_mpp
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.clienticurseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmatransportDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // dataGridView1
            // 
            this.dataGridView1.AccessibleName = "GridView1";
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(82, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(365, 184);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 420);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clienticurseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmatransportDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private firmatransportDataSet firmatransportDataSet;
        private System.Windows.Forms.BindingSource clienticurseBindingSource;
        private firmatransportDataSetTableAdapters.clienti_curseTableAdapter clienti_curseTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

