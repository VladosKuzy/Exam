using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.Interfaces
{
    public interface IArticleServiceDAL
    {
        List<ArticleViewModel> GetList();
        ArticleViewModel GetElement(int id);
        void AddElement(ArticleBindingModel model);
        void UpdateElement(ArticleBindingModel model);
        void DeleteElement(int id);
    }
}
