using MagazineModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceImplementDataBase
{
    public class MagazineDbContext : DbContext
    {
        public MagazineDbContext() : base("ExamDb")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<AuthorModel> Authors { get; set; }
        public virtual DbSet<ArticleModel> Articles { get; set; }

    }
}
