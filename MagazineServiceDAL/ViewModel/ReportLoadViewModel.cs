using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.ViewModel
{
    public class ReportLoadViewModel
    {
        public string ArticleName { get; set; }
        public DateTime DateCreate { get; set; }
        public IEnumerable<Tuple<string, string, string>> Authors { get; set; }
    }
}
