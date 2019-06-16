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
    public class AuthorServiceList : IAuthorServiceDAL
    {
        private DataListSingleton data;

        public AuthorServiceList()
        {
            data = DataListSingleton.GetSingleton();
        }

        public void AddElement(AuthorBindingModel model)
        {
            AuthorModel author = data.Authors.FirstOrDefault(rec => 
                rec.AuthorName == model.AuthorName && 
                rec.WorkShop == model.WorkShop && 
                rec.Email == model.Email);

            if (author != null)
            {
                throw new Exception("Error");
            }

            int id = data.Authors.Count > 0 
                ? data.Authors.Max(rec => rec.Id) 
                : 0;

            data.Authors.Add(new AuthorModel
            {
                Id = id + 1,
                AuthorName = model.AuthorName,
                Birthday = model.Birthday,
                Email = model.Email,
                WorkShop = model.WorkShop,
                ArticleId = model.ArticleId
            });
        }

        public void DeleteElement(int id)
        {
            AuthorModel author = data.Authors
                .FirstOrDefault(rec => rec.Id == id);

            bool delete = (author != null) 
                ? (data.Authors.Remove(author))
                : throw new Exception("Error");
        }

        public AuthorViewModel GetElement(int id)
        {
            AuthorModel author = data.Authors
                .Contains(data.Authors.FirstOrDefault(r => r.Id == id)) 
                ? data.Authors.FirstOrDefault(r => r.Id == id)
                : throw new Exception("Error");

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
            return data.Authors.Select(rec => new AuthorViewModel
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
            AuthorModel author = data.Authors.FirstOrDefault(rec =>
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
            
        }
    }
}
