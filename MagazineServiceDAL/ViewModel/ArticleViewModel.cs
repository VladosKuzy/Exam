using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.ViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название выставки")]
        public string ArticleName { get; set; }

        [DisplayName("Тема")]
        public string Theme { get; set; }

        [DisplayName("Дата публикации")]
        public DateTime DateCreate { get; set; }
        
        public List<AuthorViewModel> Authors { get; set; }
    }
}
