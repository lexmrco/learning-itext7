using Helpers.iText7.Resources;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using iText.Kernel.Events;
using iText.Kernel.Geom;

namespace Helpers.iText7
{
    public abstract class PdfBuilder
    {
        string _targetFilePath;
        PdfTemplate _pdfTemplate;
        public PdfBuilder(string targetFilePath, PdfTemplate pdfTemplate)
        {
            _targetFilePath = targetFilePath;
            _pdfTemplate = pdfTemplate;
        }

        public void Write()
        {
            try
            {
                PdfWriter writer = new PdfWriter(_targetFilePath);
                PdfDocument pdfDoc = new PdfDocument(writer);
                if(_pdfTemplate != PdfTemplate.Without)
                {
                    IEventHandler handler = new NewPageEventHandler(pdfDoc, _pdfTemplate);
                    pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, handler);
                }
                
                pdfDoc.SetDefaultPageSize(PageSize.LETTER);
                Document doc = new Document(pdfDoc);
                doc.SetMargins(100, 55, 100, 55);
                WritePdf(doc);
                doc.Close();
                writer.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        protected abstract void WritePdf(Document doc);
       
    }
}
