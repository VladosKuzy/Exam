using iTextSharp.text;
using iTextSharp.text.pdf;
using MagazineModel;
using MagazineServiceDAL.BindingModel;
using MagazineServiceDAL.Interfaces;
using MagazineServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineServiceImplementDataBase.Implementations
{
    public class ReportServiceDB : IReportServiceDAL
    {
        private MagazineDbContext context;

        public ReportServiceDB(MagazineDbContext context)
        {
            this.context = context;
        }

        public List<ReportLoadViewModel> GetLoadDataReport(ReportBindingModel model)
        {

            List<ArticleViewModel> articles = context.Articles.Select(rec => new ArticleViewModel
            {
                Id = rec.Id,
                ArticleName = rec.ArticleName,
                Theme = rec.Theme,
                DateCreate = rec.DateCreate
            }).ToList();

            List<AuthorBindingModel> authors = context.Authors.Select(rec => new AuthorBindingModel
            {
                AuthorName = rec.AuthorName,
                Birthday = rec.Birthday,
                WorkShop = rec.WorkShop,
                ArticleId = rec.ArticleId
            }).ToList();

            List<ReportLoadViewModel> list = articles.GroupJoin(
            authors,
           r1 => r1.Id,
           r2 => r2.ArticleId,
           (article, athrs) => new ReportLoadViewModel
           {
               ArticleName = article.ArticleName,
               DateCreate = article.DateCreate,
               Authors = athrs.Select(a => new Tuple<string, string, string>(a.AuthorName, a.Birthday.ToShortDateString(), a.WorkShop))
           }).ToList();

            return list;
        }

        public void CreateReport(List<ReportLoadViewModel> list, string fileName)
        {
            Document doc = new Document(PageSize.A4.Rotate());
            using (var writer = PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create)))
            {
                doc.Open();
               
                Font font = GetFont("Tahoma");

                for (int i = 0; i < list.Count(); i++)
                {
                    Paragraph name = new Paragraph(list[i].ArticleName, font);
                    Paragraph date = new Paragraph(list[i].DateCreate.ToShortDateString(), font);
                    IEnumerable<Tuple<string, string, string>> Authors = list[i].Authors;
                    PdfPTable table = CreateTable(Authors, font);
                    doc.Add(name);
                    doc.Add(date);
                    doc.Add(table);                  
                }

                doc.Close();
            }
        }

        private PdfPTable CreateTable(IEnumerable<Tuple<string, string, string>> Authors, Font font)
        {
            PdfPTable table = new PdfPTable(3);

            table.AddCell(new PdfPCell(new Phrase("Автор", font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Дата рождения", font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Издательство", font))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            for (int i =0; i < Authors.Count(); i++)
            {
                table.AddCell(new PdfPCell(new Phrase(Authors.ElementAt(i).Item1, font))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(Authors.ElementAt(i).Item2, font))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                table.AddCell(new PdfPCell(new Phrase(Authors.ElementAt(i).Item3, font))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
            }

            return table;
        }

        private Font GetFont(string fontName)
        {
            if (!FontFactory.IsRegistered(fontName))
            {
                var fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\"+ fontName + ".ttf";
                FontFactory.Register(fontPath);
            }
            return FontFactory.GetFont(fontName, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
    }
}
