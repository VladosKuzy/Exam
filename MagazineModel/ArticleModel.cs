using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineModel
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string Theme { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual List<AuthorModel> Authors { get; set; }
    }
}
