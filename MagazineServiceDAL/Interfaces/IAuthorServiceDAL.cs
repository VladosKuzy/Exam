using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.Interfaces
{
    public interface IAuthorServiceDAL
    {
        List<AuthorViewModel> GetList();
        AuthorViewModel GetElement(int id);
        void AddElement(AuthorBindingModel model);
        void UpdateElement(AuthorBindingModel model);
        void DeleteElement(int id);
    }
}
