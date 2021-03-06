using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DBProc.FileWork
{
    /// <summary>
    /// Class for create pdf-file
    /// </summary>
    public class CreatePdfFile
    {
        /// <summary>
        /// Method for create pdf-file
        /// </summary>
        /// <param name="path">Path of file</param>
        /// <param name="mas">Array of string</param>
        /// <param name="kol">Number of params for filling</param>
        public void CreatePdf(string path, string[] mas, int kol)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 14);

            if (kol == 2)
            {
                for (int i = 2; i < mas.Length; i += 2)
                    gfx.DrawString(mas[0] + mas[i] + ". " + mas[1] + mas[i + 1] + ".", font, XBrushes.Black, new XPoint(30, i * 40 - i * 30 + 30));
            }
            else if ( kol == 3)
            {
                for (int i = 3; i < mas.Length; i += 3)
                    gfx.DrawString(mas[0] + mas[i] + ". " + mas[1] + mas[i + 1] +  ". " + mas[2] + mas[i + 2] +".", font, XBrushes.Black, new XPoint(30, i * 40 - i * 30 + 30));

            }
            else
            {
                for (int i = 0; i < mas.Length; i++)
                    gfx.DrawString(mas[i], font, XBrushes.Black, new XPoint(i + 10, i * 40 - i * 30 + 30));
            }

            document.Save(path);
        }
    }
}


