using MagazineModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceImplementList
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<AuthorModel> Authors { get; set; }
        public List<ArticleModel> Articles { get; set; }
        

        private DataListSingleton()
        {
            Authors = new List<AuthorModel>();
            Articles = new List<ArticleModel>();

        }

        public static DataListSingleton GetSingleton()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
