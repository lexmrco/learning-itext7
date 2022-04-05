using Helpers.iText7;
using System;

namespace Learning.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfPath = @"C:\Temp\doc1.pdf";
            PdfBuilder pdfBuilder = new PdfBuilder();
            pdfBuilder.WritePdf(pdfPath);
            Console.WriteLine("Pdf escrito. '{0}'", pdfPath);
            Console.ReadKey(true);
        }
    }
}
