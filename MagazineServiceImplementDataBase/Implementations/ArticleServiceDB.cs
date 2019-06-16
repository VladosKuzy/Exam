using MagazineModel;
using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.Interfaces;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceImplementDataBase.Implementations
{
    public class ArticleServiceDB : IArticleServiceDAL
    {
        private MagazineDbContext context;

        public ArticleServiceDB(MagazineDbContext context)
        {
            this.context = context;
        }

        public void AddElement(ArticleBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    ArticleModel article = context.Articles
                .FirstOrDefault(rec => rec.ArticleName == model.ArticleName);

                    if (article != null)
                    {
                        throw new Exception("Error");
                    }

                    context.Articles.Add(new ArticleModel
                    {
                        ArticleName = model.ArticleName,
                        Theme = model.Theme,
                        DateCreate = model.DateCreate
                    });

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }


        public void DeleteElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    ArticleModel article = context.Articles
                .FirstOrDefault(rec => rec.Id == id);

                    var delete = (article != null)
                        ? context.Articles.Remove(article)
                        : throw new Exception("Error");

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public ArticleViewModel GetElement(int id)
        {
            ArticleModel article = context.Articles.FirstOrDefault(r => r.Id == id);

            if (article == null)
            {
                throw new Exception("Error");
            }

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
            return context.Articles.Select(rec => new ArticleViewModel
            {
                Id = rec.Id,
                ArticleName = rec.ArticleName,
                Theme = rec.Theme,
                DateCreate = rec.DateCreate
            }).ToList();
        }

        public void UpdateElement(ArticleBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    ArticleModel article = context.Articles
               .FirstOrDefault(rec => rec.Id == model.Id);

                    if (article == null)
                    {
                        throw new Exception("Ошибка, обновляемый элемент отсутствует");
                    }

                    article.ArticleName = model.ArticleName;
                    article.Theme = model.Theme;
                    article.DateCreate = model.DateCreate;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
