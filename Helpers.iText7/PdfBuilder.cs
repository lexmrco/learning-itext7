using Helpers.iText7.Resources;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using System;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;

namespace Helpers.iText7
{
    public class PdfBuilder2
    {
        public void WritePdf(string fileName) {
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
            PdfDocument pdfDoc = new PdfDocument(new PdfWriter(fileName));
            Document doc = new Document(pdfDoc);

            Text label1 = new Text("Responsable").SetFont(bold).SetFontSize(10);
            Text info1 = new Text("Margot Villaraga").SetFont(font).SetFontSize(10);
            Text label2 = new Text("Conjunto").SetFont(bold).SetFontSize(10);
            Text info2 = new Text("Balsillas").SetFont(font).SetFontSize(10);
            Text label3 = new Text("Torre").SetFont(bold).SetFontSize(10);
            Text info3 = new Text("15").SetFont(font).SetFontSize(10);
            Text label4 = new Text("Apto - Casa").SetFont(bold).SetFontSize(10);
            Text info4 = new Text("402").SetFont(font).SetFontSize(10);
            Text label5 = new Text("Raza").SetFont(bold).SetFontSize(10);
            Text info5 = new Text("Galgo Español").SetFont(font).SetFontSize(10);
            Table infoTable = new Table(2).UseAllAvailableWidth().SetFontSize(10);

            Cell cellLabel1 = new Cell();
            cellLabel1.Add(new Paragraph(label1));
            cellLabel1.SetBorder(Border.NO_BORDER);

            Cell cellInfo1 = new Cell();
            cellInfo1.Add(new Paragraph(info1));
            cellInfo1.SetBorder(Border.NO_BORDER);

            Cell cellLabel2 = new Cell();
            cellLabel2.Add(new Paragraph(label2));
            cellLabel2.SetBorder(Border.NO_BORDER);

            Cell cellInfo2 = new Cell();
            cellInfo2.Add(new Paragraph(info2));
            cellInfo2.SetBorder(Border.NO_BORDER);

            Cell cellLabel3 = new Cell();
            cellLabel3.Add(new Paragraph(label3));
            cellLabel3.SetBorder(Border.NO_BORDER);

            Cell cellInfo3 = new Cell();
            cellInfo3.Add(new Paragraph(info3));
            cellInfo3.SetBorder(Border.NO_BORDER);

            Cell cellLabel4 = new Cell();
            cellLabel4.Add(new Paragraph(label4));
            cellLabel4.SetBorder(Border.NO_BORDER);

            Cell cellInfo4 = new Cell();
            cellInfo4.Add(new Paragraph(info4));
            cellInfo4.SetBorder(Border.NO_BORDER);

            Cell cellLabel5 = new Cell();
            cellLabel5.Add(new Paragraph(label5));
            cellLabel5.SetBorder(Border.NO_BORDER);

            Cell cellInfo5 = new Cell();
            cellInfo5.Add(new Paragraph(info5));
            cellInfo5.SetBorder(Border.NO_BORDER);

            infoTable.AddCell(cellLabel1);
            infoTable.AddCell(cellInfo1);
            infoTable.AddCell(cellLabel2);
            infoTable.AddCell(cellInfo2);
            infoTable.AddCell(cellLabel3);
            infoTable.AddCell(cellInfo3);
            infoTable.AddCell(cellLabel4);
            infoTable.AddCell(cellInfo4);
            infoTable.AddCell(cellLabel5);
            infoTable.AddCell(cellInfo5);

            Image image = ResourceHelper.FindImage("paw1");
            image.SetWidth(150);
            Image imagePets = ResourceHelper.FindImage("pets");
            imagePets.SetWidth(50);

            Table tableCarnet = new Table(3);
            tableCarnet.SetWidth(480);
            
            Cell cellLogo = new Cell();
            cellLogo.SetBorder(Border.NO_BORDER);
            cellLogo.SetBorderTop(new SolidBorder(1));
            cellLogo.SetBorderLeft(new SolidBorder(1));
            
            Cell cellHeader = new Cell();
            cellHeader.SetBorder(Border.NO_BORDER);
            cellHeader.SetBorderTop(new SolidBorder(1));
            
            Cell cellPhoto = new Cell(2,1);
            cellPhoto.SetBorder(Border.NO_BORDER);
            cellPhoto.SetBorderTop(new SolidBorder(1));
            cellPhoto.SetBorderRight(new SolidBorder(1));

            Cell cellInfo = new Cell(1,2);
            cellInfo.SetBorder(Border.NO_BORDER);
            cellInfo.SetBorderLeft(new SolidBorder(1));

            Cell cellFooter1 = new Cell();
            cellFooter1.SetBorder(Border.NO_BORDER);
            cellFooter1.SetBorderLeft(new SolidBorder(1));
            cellFooter1.SetBorderBottom(new SolidBorder(1));

            Cell cellFooter2 = new Cell();
            cellFooter2.SetBorder(Border.NO_BORDER);
            cellFooter2.SetBorderBottom(new SolidBorder(1));

            Cell cellFooter3 = new Cell();
            cellFooter3.SetBorder(Border.NO_BORDER);
            cellFooter3.SetBorderRight(new SolidBorder(1));
            cellFooter3.SetBorderBottom(new SolidBorder(1));

            cellLogo.Add(imagePets);
            cellHeader.Add(new Paragraph("Cédula de Mascotas Hacienda Casablanca"));
            cellPhoto.Add(image);

            cellFooter1.Add(new Paragraph("Canino"));
            cellFooter2.Add(new Paragraph("HCB023"));
            cellFooter3.Add(new Paragraph("MONGO"));
            cellInfo.Add(infoTable);

            tableCarnet.AddCell(cellLogo);
            tableCarnet.AddCell(cellHeader);
            tableCarnet.AddCell(cellPhoto);
            tableCarnet.AddCell(cellInfo);
            tableCarnet.AddCell(cellFooter1);
            tableCarnet.AddCell(cellFooter2);
            tableCarnet.AddCell(cellFooter3);
            doc.Add(tableCarnet);

            doc.Close();
        }

        public void WritePdfFromTempalte(string fileName)
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
            try
            {

                PdfReader reader = ResourceHelper.GetTemplate(PdfTemplate.Inalambria);
                PdfWriter writer = new PdfWriter(fileName);
                PdfDocument pdfDoc = new PdfDocument(writer);
                IEventHandler handler = new NewPageEventHandler(pdfDoc,PdfTemplate.Inalambria);
                pdfDoc.AddEventHandler(PdfDocumentEvent.START_PAGE, handler);
                pdfDoc.SetDefaultPageSize(PageSize.LETTER);
                Document doc = new Document(pdfDoc);
                doc.SetMargins(90, 50, 100, 50);


                // Texto
                Text headerDateText = new Text(
                    string.Format(ResourceHelper.GetText("CertDate"), pCity, currentDay, currentMonth, currentYear)
                    ).SetFont(normalFont).SetFontSize(fontSize);
                Text blankSpace = new Text(" ").SetFont(boldFont).SetFontSize(fontSize);
                Text comaText = new Text(",").SetFont(boldFont).SetFontSize(fontSize);
                Text custNameBold = new Text(pCustName).SetFont(boldFont).SetFontSize(fontSize);
                Text custNameNormal= new Text(pCustName).SetFont(normalFont).SetFontSize(fontSize);
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
                reader.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
