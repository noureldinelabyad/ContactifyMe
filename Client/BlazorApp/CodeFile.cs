// public class CustomPdfPageEventHelper : PdfPageEventHelper
// {
//     private iTextSharp.text.Image logo;
//     private Paragraph title;

//     public CustomPdfPageEventHelper(iTextSharp.text.Image logo, Paragraph title)
//     {
//         this.logo = logo;
//         this.title = title;
//     }

//     public override void OnEndPage(PdfWriter writer, Document document)
//     {
//         base.OnEndPage(writer, document);

//         // Add a logo in the upper right corner if it's not null
//         if (logo != null)
//         {
//             logo.SetAbsolutePosition(document.Right - 70, document.Top - 5);
//             PdfContentByte canvas = writer.DirectContent;
//             canvas.AddImage(logo);
//         }

//         // Add a title above the table if it's not null
//         if (title != null)
//         {
//             title.SpacingBefore = document.Top - 5;
//             title.IndentationLeft = document.Left;
//             title.PaddingTop = document.Top + 5;
//             document.AddTitle(title.ToString());

//             //document.Add(title);
//         }

//         // Add page number
//         int pageN = writer.PageNumber;
//         string text = "Page " + pageN;
//         Rectangle pageSize = document.PageSize;
//         ColumnText.ShowTextAligned
//         (writer.DirectContent, Element.ALIGN_CENTER, new Phrase(text), pageSize.GetRight(40), pageSize.GetBottom(30), 0);
//     }
// }




//private async Task DownloadAsPdf()
//{
//    var pgSize = new iTextSharp.text.Rectangle(141.732f, 141.732f);
//    Document doc = new Document(pgSize);
//    try
//    {
//        // Create a new PDF document
//        Document document = new Document(PageSize.A4, 26, 36, 15, 0);

//        MemoryStream memoryStream = new MemoryStream();
//        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

//        // Customize every PDF page
//        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(Path.Combine
//            ("wwwroot", "thinfabrics-logo_200x30.png"));
//        float logoWidth = 80f;
//        float logoHeight = 80f;
//        logo.ScaleToFit(logoWidth, logoHeight);

//        Paragraph title = new Paragraph
//        ("Kontakttabelle", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD, new BaseColor(0, 204, 102)));

//        //CustomPdfPageEventHelper pageEventHelper = new CustomPdfPageEventHelper(logo, title);
//        // writer.PageEvent = pageEventHelper;

//        document.Open();

//        // Add content to the PDF
//        PdfPTable table = new PdfPTable(11); // Adjust the number of columns as per your data

//        // Set custom column widths
//        float[] columnWidths = new float[] { 110f, 120f, 120f, 200f, 140f, 100f, 100f, 100f, 100f, 100f, 100f };
//        table.SetWidths(columnWidths);

//        // Set table properties
//        table.WidthPercentage = 98;
//        table.SpacingBefore = 10f;
//        table.SpacingAfter = 10f;
//        table.HorizontalAlignment = Element.ALIGN_CENTER;

//        // Headers style
//        BaseFont bfHelvetica = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
//        Font headerFont = new Font(bfHelvetica, 9, Font.BOLD, BaseColor.WHITE); // Header font style

//        // Set header background color
//        BaseColor headerBgColor = new BaseColor(0, 204, 102); // #00CC66
//        headerFont.Color = BaseColor.WHITE; // White text color for headers

//        // Add headers with bold font and specified background color
//        string[] headerTitles =
//        { "Vorname", "Nachname", "Mittelname", "Email", "Tel.Nr", "Straße", "Haus.Nr", "PLZ", "Stadt", "Land", "Gender" };
//        foreach (var headerTitle in headerTitles)
//        {
//            PdfPCell headerCell = new PdfPCell(new Phrase(headerTitle, headerFont))
//            {
//                BackgroundColor = headerBgColor,
//                HorizontalAlignment = Element.ALIGN_CENTER,
//                VerticalAlignment = Element.ALIGN_CENTER
//            };
//            table.AddCell(headerCell);
//        }


//        // Body style
//        Font bodyFont = new Font(bfHelvetica, 8, Font.NORMAL, new BaseColor(23, 50, 77)); // #17324D

//        // Set even and odd row background colors
//        BaseColor evenBgColor = new BaseColor(255, 255, 255); // White background for even rows
//        BaseColor oddBgColor = new BaseColor(238, 238, 238); // Light gray background for odd rows

//        // Add data with small font size and alternating row background colors
//        for (int i = 0; i < _PersonList.Count; i++)
//        {
//            var person = _PersonList[i];

//            table.AddCell(new PdfPCell(new Phrase(person.Vorname, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Nachname, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Zwischenname, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Email, bodyFont)));
//            var telefonnummern = string.Join(", ", person.PersonNummern.Select(p => p.TelNummer));
//            table.AddCell(new PdfPCell(new Phrase(telefonnummern, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Strasse, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Hausnummer, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.PLZ.ToString(), bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Stadt, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Land, bodyFont)));
//            table.AddCell(new PdfPCell(new Phrase(person.Gender, bodyFont)));

//            // Set padding to wrap text
//            foreach (PdfPCell cell in table.Rows[table.Rows.Count - 1].GetCells())
//            {
//                cell.Padding = 3;
//                cell.FixedHeight = 15f;
//                cell.HorizontalAlignment = Element.ALIGN_CENTER;
//                cell.VerticalAlignment = Element.ALIGN_CENTER;

//            }

//            // Add new row every 30 rows for page breaks
//            if (i > 0 && i % 50 == 0)
//            {
//                document.Add(table);
//                document.NewPage();
//                table = new PdfPTable(11); // Create a new table for the next page
//                                           // Set custom column widths, table properties, and headers as needed
//            }
//        }

//        document.Add(table);

//        document.Close();

//        // Trigger the download
//        byte[] data = memoryStream.ToArray();
//        await JSRuntime.InvokeVoidAsync("downloadPdf", Convert.ToBase64String(data), "person_data.pdf");

//    }
//    catch (Exception ex)
//    {
//        // Handle any exceptions
//        Console.WriteLine("Error: " + ex.Message);
//    }
//}