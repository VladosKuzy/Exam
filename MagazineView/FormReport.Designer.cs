namespace MagazineView
{
    partial class FormReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.buttonCreateList = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "От";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "До";
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Location = new System.Drawing.Point(52, 26);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(274, 20);
            this.textBoxFrom.TabIndex = 2;
            // 
            // textBoxTo
            // 
            this.textBoxTo.Location = new System.Drawing.Point(52, 71);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(274, 20);
            this.textBoxTo.TabIndex = 3;
            // 
            // buttonCreateList
            // 
            this.buttonCreateList.Location = new System.Drawing.Point(195, 119);
            this.buttonCreateList.Name = "buttonCreateList";
            this.buttonCreateList.Size = new System.Drawing.Size(131, 25);
            this.buttonCreateList.TabIndex = 4;
            this.buttonCreateList.Text = "Сформировать отчет";
            this.buttonCreateList.UseVisualStyleBackColor = true;
            this.buttonCreateList.Click += new System.EventHandler(this.buttonCreateList_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(177, 194);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(149, 44);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить отчет";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 251);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCreateList);
            this.Controls.Add(this.textBoxTo);
            this.Controls.Add(this.textBoxFrom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.Button buttonCreateList;
        private System.Windows.Forms.Button buttonSave;
    }
}