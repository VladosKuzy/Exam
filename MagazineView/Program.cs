using MagazineServiceDAL.Interfaces;
using MagazineServiceImplementDataBase.Implementations;
using MagazineServiceImplementList.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace MagazineView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IAuthorServiceDAL, AuthorServiceDB>(
                new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IArticleServiceDAL, ArticleServiceDB>(
               new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IReportServiceDAL, ReportServiceDB>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
