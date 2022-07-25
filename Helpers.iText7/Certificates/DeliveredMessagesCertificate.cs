using Helpers.iText7.Resources;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace Helpers.iText7.Certificates
{
    public class DeliveredMessagesCertificate: PdfBuilder
    {
        public DeliveredMessagesCertificate(string targetFilePath) : base(targetFilePath, PdfTemplate.Inalambria) { }

        protected override void WritePdf(Document doc)
        {
            PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            int fontSize = 10;

            // Custom Variables
            string pCustName = "ITAU CORPBANCA COLOMBIA S A";
            string pResponsibleName = "LUIS FERNANDO ARIAS - OPE TRANSACCIONAL";
            string pOperator = "MOVISTAR";
            string pPhone = "3125365309";
            string pStatus = "Envío exitoso";
            string pCity = "Bogotá";
            DateTime currentDate = DateTime.Now;
            int currentDay = currentDate.Day;
            string currentMonth = GetMonthLetters(currentDate.Month);
            int currentYear = currentDate.Year;

            // Texto
            Text headerDateText = new Text(
                string.Format(ResourceHelper.GetText("CertDate"), pCity, currentDay, currentMonth, currentYear)
                ).SetFont(normalFont).SetFontSize(fontSize);
            Text blankSpace = new Text(" ").SetFont(boldFont).SetFontSize(fontSize);
            Text comaText = new Text(",").SetFont(boldFont).SetFontSize(fontSize);
            Text custNameBold = new Text(pCustName).SetFont(boldFont).SetFontSize(fontSize);
            Text custNameNormal = new Text(pCustName).SetFont(normalFont).SetFontSize(fontSize);
            Text greeting1Text = new Text(ResourceHelper.GetText("CertGreeting1")).SetFont(normalFont).SetFontSize(fontSize);
            Text greeting2Text = new Text(ResourceHelper.GetText("CertGreeting2")).SetFont(normalFont).SetFontSize(fontSize);
            Text title1Text = new Text(ResourceHelper.GetText("CertBodyTitle1").ToUpper()).SetFont(boldFont).SetFontSize(fontSize).SetTextAlignment(TextAlignment.CENTER);
            Text body1Text = new Text(ResourceHelper.GetText("CertDeliveredBody1")).SetFont(normalFont).SetFontSize(fontSize);
            Text body2Text = new Text(ResourceHelper.GetText("CertDeliveredBody2")).SetFont(normalFont).SetFontSize(fontSize);
            Text body3Text = new Text(ResourceHelper.GetText("CertDeliveredBody3")).SetFont(normalFont).SetFontSize(fontSize);
            Text body4Text = new Text(ResourceHelper.GetText("CertDeliveredBody4")).SetFont(normalFont).SetFontSize(fontSize);
            Text body5Text = new Text(ResourceHelper.GetText("CertDeliveredBody5")).SetFont(normalFont).SetFontSize(fontSize);
            Text closingText = new Text(
                string.Format(ResourceHelper.GetText("CertClosing"), currentDay, currentMonth, currentYear)
                ).SetFont(normalFont).SetFontSize(fontSize);
            Text signatureName = new Text(ResourceHelper.GetText("CertSignatureName")).SetFont(boldFont).SetFontSize(fontSize);
            Text signatureText = new Text(ResourceHelper.GetText("CertSignature")).SetFont(normalFont).SetFontSize(fontSize);
            Image signatureImage = ResourceHelper.FindImage("firmaVivian").SetWidth(150);


            Paragraph headerParagraph = new Paragraph(headerDateText);
            headerParagraph.Add(Environment.NewLine);
            doc.Add(headerParagraph);

            Paragraph regardsParagraph = new Paragraph(greeting1Text);
            regardsParagraph.Add(Environment.NewLine);
            regardsParagraph.Add(custNameBold);
            regardsParagraph.Add(Environment.NewLine);
            regardsParagraph.Add(greeting2Text);
            regardsParagraph.Add(Environment.NewLine);
            regardsParagraph.Add(Environment.NewLine);
            regardsParagraph.SetMultipliedLeading(1.0f);
            doc.Add(regardsParagraph);


            Paragraph bodyTitleParagraph = new Paragraph(title1Text)
                .Add(Environment.NewLine)
                .Add(Environment.NewLine)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMultipliedLeading(1.0f);
            doc.Add(bodyTitleParagraph);


            Paragraph bodyParagraph = new Paragraph(body1Text)
                .Add(blankSpace)
                .Add(custNameNormal)
                .Add(blankSpace)
                .Add(body2Text)
                .Add(blankSpace)
                .Add(custNameBold)
                .Add(blankSpace)
                .Add(body3Text)
                .Add(blankSpace)
                .Add(custNameBold)
                .Add(blankSpace)
                .Add(body4Text)
                .Add(blankSpace)
                .Add(custNameNormal)
                .Add(comaText)
                .Add(blankSpace)
                .Add(body5Text)
                .SetTextAlignment(TextAlignment.JUSTIFIED)
                .SetMultipliedLeading(1.0f);
            doc.Add(bodyParagraph);

            #region Body Table
            Table bodyTableHeader = new Table(2);

            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text("CLIENTE:").SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text(pCustName.ToUpper()).SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text("RESPONSABLE:").SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text(pResponsibleName.ToUpper()).SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text("OPERADOR:").SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text(pOperator.ToUpper()).SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text("TELÉFONO:").SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text(pPhone.ToUpper()).SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text("ESTADO:").SetFont(boldFont).SetFontSize(fontSize))));
            bodyTableHeader.AddCell(new Cell().Add(new Paragraph(new Text(pStatus.ToUpper()).SetFont(boldFont).SetFontSize(fontSize))));
            doc.Add(bodyTableHeader);
            doc.Add(new Paragraph(Environment.NewLine));

            Table detailedTable = new Table(4);
            detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("CUENTA").SetFont(boldFont).SetFontSize(fontSize))));
            detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("MENSAJE").SetFont(boldFont).SetFontSize(fontSize))));
            detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("FECHA LLEGADA A INALAMBRIA").SetFont(boldFont).SetFontSize(fontSize))));
            detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("FECHA ENVÍO AL OPERADOR").SetFont(boldFont).SetFontSize(fontSize))));

            for (int i = 0; i < 4; i++)
            {
                detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("SGbancocr").SetFont(normalFont).SetFontSize(fontSize))));
                detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("Se realizo una compra en OPTICAS GMO COLOMBIA desde tu Cuenta de Ahorros ****2082 por $600,000  el 2022/05/01 10:56:25 ITAU Tel: 5818181 Bta o 018000512633 Nal").SetFont(normalFont).SetFontSize(fontSize))));
                detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("1/05/2022 10:56:27").SetFont(normalFont).SetFontSize(fontSize))));
                detailedTable.AddCell(new Cell().Add(new Paragraph(new Text("1/05/2022 10:56:28").SetFont(normalFont).SetFontSize(fontSize))));

            }

            doc.Add(detailedTable);
            #endregion

            Paragraph closingParagraph = new Paragraph(closingText)
                .SetMultipliedLeading(1.0f);
            doc.Add(closingParagraph);

            doc.Add(signatureImage);

            SolidLine line = new SolidLine(1f);
            LineSeparator ls = new LineSeparator(line).SetWidth(150);
            doc.Add(ls);

            Paragraph signatureParagraph = new Paragraph(signatureName)
                .Add(Environment.NewLine)
                .Add(signatureText)
                .SetMultipliedLeading(1.0f);
            doc.Add(signatureParagraph);

            doc.Close();
        }
        string GetMonthLetters(int month)
        {
            switch (month)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
                default:
                    return "";
            }
        }
    }
    
}
