using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceDAL.Interfaces
{
    public interface IReportServiceDAL
    {
        List<ReportLoadViewModel> GetLoadDataReport(ReportBindingModel model);
        void CreateReport(List<ReportLoadViewModel> list, string fileName);
    }
}
