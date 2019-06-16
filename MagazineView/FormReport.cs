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
    public partial class FormReport : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public readonly IReportServiceDAL report;
        private List<ReportLoadViewModel> list;

        public FormReport(IReportServiceDAL report)
        {
            InitializeComponent();
            this.report = report;
        }

        private void buttonCreateList_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBoxFrom.Text.Equals("") && !textBoxTo.Equals(""))
                {
                    list = report.GetLoadDataReport(new ReportBindingModel
                    {
                        DateTo = Convert.ToDateTime(textBoxTo.Text),
                        DateFrom = Convert.ToDateTime(textBoxFrom.Text)
                    });
                    MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog()
            {
                Filter = "PDF file|*.pdf",
                ValidateNames = true
            })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        report.CreateReport(list, saveFile.FileName);
                        MessageBox.Show("Отчёт успешно создан", "Информация", MessageBoxButtons.OK);
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
