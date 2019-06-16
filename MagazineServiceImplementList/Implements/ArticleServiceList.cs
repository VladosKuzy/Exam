using MagazineModel;
using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.Interfaces;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceImplementList.Implements
{
    public class ArticleServiceList : IArticleServiceDAL
    {
        private DataListSingleton data;

        public ArticleServiceList()
        {
            data = DataListSingleton.GetSingleton();
        }

        public void AddElement(ArticleBindingModel model)
        {
            ArticleModel article = data.Articles
                .FirstOrDefault(rec => rec.ArticleName == model.ArticleName);

            if (article != null)
            {
                throw new Exception("Error");
            }

            int id = data.Articles.Count > 0 
                ? data.Articles.Max(rec => rec.Id)
                : 0;

            data.Articles.Add(new ArticleModel
            {
                Id = id + 1,
                ArticleName = model.ArticleName,
                Theme = model.Theme,
                DateCreate = model.DateCreate
            }); 
        }

      
        public void DeleteElement(int id)
        {
            ArticleModel article = data.Articles
                .FirstOrDefault(rec => rec.Id == id);

            bool delete = (article != null)
                ? data.Articles.Remove(article)
                : throw new Exception("Error");
        }

        public ArticleViewModel GetElement(int id)
        {
            var article = data.Articles
                .Contains(data.Articles.FirstOrDefault(r => r.Id == id))
                ? data.Articles.FirstOrDefault(r => r.Id == id)
                : throw new Exception("Error");

            return new ArticleViewModel
            {
                Id = article.Id,
                ArticleName = article.ArticleName,
                Theme = article.Theme,
                DateCreate = article.DateCreate
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return data.Articles.Select(rec => new ArticleViewModel
            {
                Id = rec.Id,
                ArticleName = rec.ArticleName,
                Theme = rec.Theme,
                DateCreate = rec.DateCreate
            }).ToList();
        }

        public void UpdateElement(ArticleBindingModel model)
        {
            ArticleModel article = data.Articles
               .FirstOrDefault(rec => rec.Id == model.Id);

            if (article == null)
            {
                throw new Exception("Ошибка, обновляемый элемент отсутствует");
            }
            
            article.ArticleName = model.ArticleName;
            article.Theme = model.Theme;
            article.DateCreate = model.DateCreate;
        }
    }
}
