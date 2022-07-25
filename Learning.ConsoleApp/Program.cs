using Helpers.iText7;
using Helpers.iText7.Certificates;
using System;

namespace Learning.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WritePdfFromTemplate();
            Console.ReadKey(true);
        }

        public static void WritePdfWithTable()
        {
            string pdfPath = @"C:\Temp\doc1.pdf";
            PdfBuilder2 pdfBuilder = new PdfBuilder2();
            pdfBuilder.WritePdf(pdfPath);
        }

        public static void WritePdfFromTemplate()
        {
            string pdfPath = @"C:\Temp\doc3.pdf";
            DeliveredMessagesCertificate pdfBuilder = new DeliveredMessagesCertificate(pdfPath);
            pdfBuilder.Write();
           
        }
    }
}
