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
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAuthors>();
            form.ShowDialog();
        }

        private void buttonAddArticle_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormArticles>();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReport>();
            form.ShowDialog();
        }
    }
}
