namespace MagazineView
{
    partial class FormAuthorsSerialization
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
            this.buttonLoadXML = new System.Windows.Forms.Button();
            this.buttonCreateXMLFile = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCreateJSON = new System.Windows.Forms.Button();
            this.buttonGetJSON = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadXML
            // 
            this.buttonLoadXML.Location = new System.Drawing.Point(451, 74);
            this.buttonLoadXML.Name = "buttonLoadXML";
            this.buttonLoadXML.Size = new System.Drawing.Size(181, 44);
            this.buttonLoadXML.TabIndex = 5;
            this.buttonLoadXML.Text = "Загрузить XML";
            this.buttonLoadXML.UseVisualStyleBackColor = true;
            this.buttonLoadXML.Click += new System.EventHandler(this.buttonLoadXML_Click);
            // 
            // buttonCreateXMLFile
            // 
            this.buttonCreateXMLFile.Location = new System.Drawing.Point(451, 12);
            this.buttonCreateXMLFile.Name = "buttonCreateXMLFile";
            this.buttonCreateXMLFile.Size = new System.Drawing.Size(181, 44);
            this.buttonCreateXMLFile.TabIndex = 4;
            this.buttonCreateXMLFile.Text = "Создать XML файл";
            this.buttonCreateXMLFile.UseVisualStyleBackColor = true;
            this.buttonCreateXMLFile.Click += new System.EventHandler(this.buttonCreateFile_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(419, 426);
            this.dataGridView1.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(451, 394);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(181, 44);
            this.buttonOk.TabIndex = 6;
            this.buttonOk.Text = "Ок";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCreateJSON
            // 
            this.buttonCreateJSON.Location = new System.Drawing.Point(451, 140);
            this.buttonCreateJSON.Name = "buttonCreateJSON";
            this.buttonCreateJSON.Size = new System.Drawing.Size(181, 44);
            this.buttonCreateJSON.TabIndex = 7;
            this.buttonCreateJSON.Text = "Создать JSON";
            this.buttonCreateJSON.UseVisualStyleBackColor = true;
            this.buttonCreateJSON.Click += new System.EventHandler(this.buttonCreateJSON_Click);
            // 
            // buttonGetJSON
            // 
            this.buttonGetJSON.Location = new System.Drawing.Point(451, 205);
            this.buttonGetJSON.Name = "buttonGetJSON";
            this.buttonGetJSON.Size = new System.Drawing.Size(181, 44);
            this.buttonGetJSON.TabIndex = 8;
            this.buttonGetJSON.Text = "Создать JSON";
            this.buttonGetJSON.UseVisualStyleBackColor = true;
            this.buttonGetJSON.Click += new System.EventHandler(this.buttonGetJSON_Click);
            // 
            // FormAuthorsSerialization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 450);
            this.Controls.Add(this.buttonGetJSON);
            this.Controls.Add(this.buttonCreateJSON);
            this.Controls.Add(this.buttonCreateXMLFile);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonLoadXML);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormAuthorsSerialization";
            this.Text = "FormAuthorsSerialization";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadXML;
        private System.Windows.Forms.Button buttonCreateXMLFile;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCreateJSON;
        private System.Windows.Forms.Button buttonGetJSON;
    }
}