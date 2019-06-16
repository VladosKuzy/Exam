namespace MagazineView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.buttonAddArticle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.Location = new System.Drawing.Point(606, 12);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(182, 44);
            this.buttonAddAuthor.TabIndex = 0;
            this.buttonAddAuthor.Text = "Добавить автора";
            this.buttonAddAuthor.UseVisualStyleBackColor = true;
            this.buttonAddAuthor.Click += new System.EventHandler(this.buttonAddAuthor_Click);
            // 
            // buttonAddArticle
            // 
            this.buttonAddArticle.Location = new System.Drawing.Point(606, 62);
            this.buttonAddArticle.Name = "buttonAddArticle";
            this.buttonAddArticle.Size = new System.Drawing.Size(182, 44);
            this.buttonAddArticle.TabIndex = 1;
            this.buttonAddArticle.Text = "Добавить статью";
            this.buttonAddArticle.UseVisualStyleBackColor = true;
            this.buttonAddArticle.Click += new System.EventHandler(this.buttonAddArticle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить отчет";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAddArticle);
            this.Controls.Add(this.buttonAddAuthor);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.Button buttonAddArticle;
        private System.Windows.Forms.Button button1;
    }
}

