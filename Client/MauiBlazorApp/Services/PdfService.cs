using DinkToPdf;
using DinkToPdf.Contracts;
using System.IO;
using System.Threading.Tasks;
using MauiBlazorApp.Models;

//public interface IFileService
//{
//    Task SaveFileAsync(string fileName, byte[] content);
//}

namespace MauiBlazorApp.Services
{

    //public class FileService : IFileService
    //{
    //    public async Task SaveFileAsync(string fileName, byte[] content)
    //    {
    //        // Implement file saving logic for Android here
    //    }
    //}

    public class PdfService
    {
        private readonly IConverter _converter;

        public PdfService(IConverter converter)
        {
            _converter = converter;
        }

        public async Task<byte[]> GeneratePdfAsync(string htmlContent)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10, Bottom = 10 }
                },
                Objects = {
                    new ObjectSettings
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            return await Task.Run(() => _converter.Convert(doc));
        }
    }
}
