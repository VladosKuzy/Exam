using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.Interfaces;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace MagazineView
{
    public partial class FormArticle : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }
        private readonly IArticleServiceDAL article;
        private int? id;


        public FormArticle(IArticleServiceDAL article)
        {
            InitializeComponent();
            this.article = article;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.HasValue)
                {
                    article.UpdateElement(new ArticleBindingModel
                    {
                        Id = id.Value,
                        ArticleName = textBoxName.Text,
                        Theme = textBoxTheme.Text,
                        DateCreate = DateTime.Parse(textBoxDateCreate.Text)
                    });
                }
                else
                {
                    article.AddElement(new ArticleBindingModel
                    {
                        ArticleName = textBoxName.Text,
                        Theme = textBoxTheme.Text,
                        DateCreate = DateTime.Parse(textBoxDateCreate.Text)
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormArticle_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ArticleViewModel element = article.GetElement(id.Value);
                    if (element != null)
                    {
                        textBoxName.Text = element.ArticleName;
                        textBoxDateCreate.Text = element.DateCreate.ToShortDateString();
                        textBoxTheme.Text = element.Theme;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonArticle_Click(object sender, EventArgs e)
        {

        }
    }
}
