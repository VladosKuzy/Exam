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
    public class AuthorServiceDB : IAuthorServiceDAL
    {
        private MagazineDbContext context;

        public AuthorServiceDB(MagazineDbContext context)
        {
            this.context = context;
        }

        public void AddElement(AuthorBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    AuthorModel author = context.Authors.FirstOrDefault(rec =>
               rec.AuthorName == model.AuthorName &&
               rec.WorkShop == model.WorkShop &&
               rec.Email == model.Email);

                    if (author != null)
                    {
                        throw new Exception("Error");
                    }

                    context.Authors.Add(new AuthorModel
                    {

                        AuthorName = model.AuthorName,
                        Birthday = model.Birthday,
                        Email = model.Email,
                        WorkShop = model.WorkShop,
                        ArticleId = model.ArticleId
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

                    AuthorModel author = context.Authors
                .FirstOrDefault(rec => rec.Id == id);

                    var delete = author != null
                       ? context.Authors.Remove(author)
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

        public AuthorViewModel GetElement(int id)
        {
            AuthorModel author = context.Authors.FirstOrDefault(r => r.Id == id);

            if (author == null)
            {
                throw new Exception("Error");
            }

            return new AuthorViewModel
            {
                Id = author.Id,
                AuthorName = author.AuthorName,
                Birthday = author.Birthday,
                Email = author.Email,
                WorkShop = author.WorkShop
            };
        }

        public List<AuthorViewModel> GetList()
        {
            return context.Authors.Select(rec => new AuthorViewModel
            {
                Id = rec.Id,
                AuthorName = rec.AuthorName,
                Birthday = rec.Birthday,
                Email = rec.Email,
                WorkShop = rec.WorkShop
            }).ToList();
        }

        public void UpdateElement(AuthorBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    AuthorModel author = context.Authors.FirstOrDefault(rec =>
                rec.Id == model.Id);

                    if (author == null)
                    {
                        throw new Exception("Ошибка, обновляемый элемент отсутствует");
                    }

                    author.AuthorName = model.AuthorName;
                    author.Birthday = model.Birthday;
                    author.Email = model.Email;
                    author.WorkShop = model.WorkShop;
                    author.ArticleId = model.ArticleId;

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
