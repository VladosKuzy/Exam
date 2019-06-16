using MagazineModel;
using MagazineServiceDAL.Interfaces;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Unity;

namespace MagazineView
{
    public partial class FormAuthorsSerialization : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IAuthorServiceDAL author;

        public FormAuthorsSerialization(IAuthorServiceDAL author)
        {
            InitializeComponent();
            this.author = author;
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
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
                        author.CreateXMLFile(saveFile.FileName);

                        MessageBox.Show("Файл успешно создан", "Информация", MessageBoxButtons.OK);
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
                        AuthorModel[] authors = author.GetXMLFile(openDialog.FileName);
                        List<AuthorViewModel> list = authors.Select(rec => new AuthorViewModel
                        {
                            AuthorName = rec.AuthorName,
                            Birthday = rec.Birthday,
                            Email = rec.Email,
                            WorkShop = rec.WorkShop,
                            ArticleId = rec.ArticleId
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

        private void LoadData(List<AuthorViewModel> list)
        {
            try
            {             
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = false;
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                        author.CreateJSONFile(saveFile.FileName);

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
                        AuthorModel[] authors = author.GetJSONFile(openDialog.FileName);
                        List<AuthorViewModel> list = authors.Select(rec => new AuthorViewModel
                        {
                            AuthorName = rec.AuthorName,
                            Birthday = rec.Birthday,
                            Email = rec.Email,
                            WorkShop = rec.WorkShop,
                            ArticleId = rec.ArticleId
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

       
    }
}
