using Helpers.iText7.Resources;
using iText.Kernel.Events;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Xobject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.iText7
{
    public class InsertPageEventHandler : IEventHandler
    {
        PdfTemplate _template;
        public InsertPageEventHandler(PdfTemplate template)
        {
            _template = template;
        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent documentEvent = (PdfDocumentEvent)@event;
            PdfDocument templateDoc = new PdfDocument(ResourceHelper.GetTemplate(_template));
            PdfDocument pdfDoc = documentEvent.GetDocument();

            //pdfDoc.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handler);

            //var coverPage = templateDoc.GetPage(1);
            //coverPage.CopyTo(pdfDoc);
            //pdfDoc.AddPage(coverPage.CopyTo(pdfDoc));
        }
    }
    public class NewPageEventHandler : IEventHandler
    {
        readonly PdfXObject stationery;
        public NewPageEventHandler(PdfDocument document, PdfTemplate template)
        {
            PdfDocument templateDoc = new PdfDocument(ResourceHelper.GetTemplate(template));

            PdfPage page = templateDoc.GetPage(1);
            stationery = page.CopyAsFormXObject(document);
            templateDoc.Close();
        }
        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdf = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();
            PdfCanvas pdfCanvas = new PdfCanvas(
                page.NewContentStreamBefore(), page.GetResources(), pdf);
            pdfCanvas.AddXObjectAt(stationery, 0, 0);
        }
    }
}
