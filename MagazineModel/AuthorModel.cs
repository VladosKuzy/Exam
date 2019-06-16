using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineModel
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string WorkShop { get; set; }
       
        public int ArticleId { get; set; }
        public virtual ArticleModel Article { get; set; }
    }
}
