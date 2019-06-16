using MagazineModel;
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
    public partial class FormArticlesSerialization : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IArticleServiceDAL article;


        public FormArticlesSerialization(IArticleServiceDAL article)
        {
            InitializeComponent();
            this.article = article;
        }

        private void buttonCreateXMLFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog()
            {
                Filter = "XML file|*.xml",
                ValidateNames = true
            })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        article.CreateXMLFile(saveFile.FileName);

                        MessageBox.Show("Файл успешно создан", "Информация", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void buttonLoadXML_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog()
            {
                Filter = "XML file|*.xml",
                ValidateNames = true
            })
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ArticleModel[] articles = article.GetXMLFile(openDialog.FileName);
                        List<ArticleViewModel> list = articles.Select(rec => new ArticleViewModel
                        {
                            ArticleName = rec.ArticleName,
                            Theme = rec.Theme,
                            DateCreate = rec.DateCreate
                        }).ToList();

                        LoadData(list);

                        MessageBox.Show("Файл успешно загружен", "Информация", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void buttonCreateJSON_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog()
            {
                Filter = "JSON file|*.json",
                ValidateNames = true
            })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        article.CreateJSONFile(saveFile.FileName);

                        MessageBox.Show("Файл успешно создан", "Информация", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void buttonGetJSON_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog()
            {
                Filter = "JSON file|*.json",
                ValidateNames = true
            })
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ArticleModel[] articles = article.GetJSONFile(openDialog.FileName);
                        List<ArticleViewModel> list = articles.Select(rec => new ArticleViewModel
                        {
                            ArticleName = rec.ArticleName,
                            Theme = rec.Theme,
                            DateCreate = rec.DateCreate
                        }).ToList();

                        LoadData(list);

                        MessageBox.Show("Файл успешно загружен", "Информация", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoadData(List<ArticleViewModel> list)
        {
            try
            {
                
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
