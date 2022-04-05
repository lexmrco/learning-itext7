using Helpers.iText7.Resources;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;

namespace Helpers.iText7
{
    public class PdfBuilder
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
    }
}
