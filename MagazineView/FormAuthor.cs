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
    public partial class FormAuthor : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }
        private readonly IAuthorServiceDAL author;
        private int? id;
        private ArticleViewModel article;

        public FormAuthor(IAuthorServiceDAL author)
        {
            InitializeComponent();
            this.author = author;
        }

        private void FormAuthor_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AuthorViewModel element = author.GetElement(id.Value);
                    if (element != null)
                    {
                        textBoxName.Text = element.AuthorName;
                        textBoxBirthday.Text = element.Birthday.ToShortDateString();
                        textBoxEmail.Text = element.Email;
                        textBoxWorkshop.Text = element.WorkShop;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (id.HasValue)
                {
                    author.UpdateElement(new AuthorBindingModel
                    {
                        Id = id.Value,
                        AuthorName = textBoxName.Text,
                        WorkShop = textBoxWorkshop.Text,
                        Email = textBoxEmail.Text,
                        Birthday = DateTime.Parse(textBoxBirthday.Text),
                        ArticleId = article.Id
                    });
                }
                else
                {
                    author.AddElement(new AuthorBindingModel
                    {
                        AuthorName = textBoxName.Text,
                        WorkShop = textBoxWorkshop.Text,
                        Email = textBoxEmail.Text,
                        Birthday = DateTime.Parse(textBoxBirthday.Text),
                        ArticleId = article.Id
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

        private void buttonArticle_Click(object sender, EventArgs e)
        {

            var form = Container.Resolve<FormSelectArticle>();          
            if (form.ShowDialog() == DialogResult.OK)
            {
                article = form.SelectArticle;
                textBoxArticle.Text = article.ArticleName;
            }

        }
    }
}
