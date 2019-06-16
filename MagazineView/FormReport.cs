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
using System.Threading;
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

        private async void buttonCreateList_Click(object sender, EventArgs e)
        {
            Task task = null;

            if (!textBoxFrom.Text.Equals("") && !textBoxTo.Equals(""))
            {
                task = Task.Run(() => list = report.GetLoadDataReport(new ReportBindingModel
                {
                    DateTo = Convert.ToDateTime(textBoxTo.Text),
                    DateFrom = Convert.ToDateTime(textBoxFrom.Text)
                }));
            }

            try
            {
                if (!textBoxFrom.Text.Equals("") && !textBoxTo.Equals(""))
                {

                    await task;
                    
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

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFile = new SaveFileDialog()
            {
                Filter = "PDF file|*.pdf",
                ValidateNames = true
            })
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    Task task = Task.Run(() => report.CreateReport(list, saveFile.FileName));

                    try
                    {
                        await task;
                       
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
