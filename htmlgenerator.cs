using System;
using System.IO;
using System.Web.UI;

class Program
{
    static void Main()
    {
        string htmlFilePath = "sample.html";

        using (StreamWriter streamWriter = new StreamWriter(htmlFilePath))
        {
            using (HtmlTextWriter writer = new HtmlTextWriter(streamWriter))
            {
                writer.WriteDocType("html", null, null, null);
                writer.RenderBeginTag(HtmlTextWriterTag.Html);
                writer.RenderBeginTag(HtmlTextWriterTag.Head);
                writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                writer.WriteAttribute("charset", "UTF-8");
                writer.RenderEndTag(); // Meta

                writer.RenderBeginTag(HtmlTextWriterTag.Meta);
                writer.WriteAttribute("name", "viewport");
                writer.WriteAttribute("content", "width=device-width, initial-scale=1.0");
                writer.RenderEndTag(); // Meta

                writer.RenderBeginTag(HtmlTextWriterTag.Title);
                writer.Write("Sample Webpage with Table");
                writer.RenderEndTag(); // Title

                writer.RenderBeginTag(HtmlTextWriterTag.Style);

                writer.Write("table {");
                writer.Write("width: 100%;");
                writer.Write("border-collapse: collapse;");
                writer.Write("margin-top: 20px;");
                writer.Write("}");

                writer.Write("th, td {");
                writer.Write("border: 1px solid #dddddd;");
                writer.Write("padding: 8px;");
                writer.Write("text-align: left;");
                writer.Write("}");

                writer.Write("th {");
                writer.Write("background-color: #f2f2f2;");
                writer.Write("}");

                writer.Write("tr:nth-child(even) {");
                writer.Write("background-color: #f9f9f9;");
                writer.Write("}");

                writer.Write("tr:nth-child(odd) {");
                writer.Write("background-color: #ffffff;");
                writer.Write("}");

                writer.RenderEndTag(); // Style

                writer.RenderEndTag(); // Head

                writer.RenderBeginTag(HtmlTextWriterTag.Body);

                writer.RenderBeginTag(HtmlTextWriterTag.H1);
                writer.Write("Sample Webpage with Table");
                writer.RenderEndTag(); // H1

                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                writer.RenderBeginTag(HtmlTextWriterTag.Thead);

                WriteTableHeader(writer, "Header 1");
                WriteTableHeader(writer, "Header 2");
                WriteTableHeader(writer, "Header 3");

                writer.RenderEndTag(); // Thead
                writer.RenderBeginTag(HtmlTextWriterTag.Tbody);

                WriteTableRow(writer, "Row 1, Cell 1", "Row 1, Cell 2", "Row 1, Cell 3");
                WriteTableRow(writer, "Row 2, Cell 1", "Row 2, Cell 2", "Row 2, Cell 3");
                WriteTableRow(writer, "Row 3, Cell 1", "Row 3, Cell 2", "Row 3, Cell 3");

                writer.RenderEndTag(); // Tbody
                writer.RenderEndTag(); // Table

                writer.RenderEndTag(); // Body
                writer.RenderEndTag(); // Html
            }
        }

        Console.WriteLine($"HTML content generated and saved to {htmlFilePath}");
    }

    static void WriteTableHeader(HtmlTextWriter writer, string headerText)
    {
        writer.RenderBeginTag(HtmlTextWriterTag.Th);
        writer.Write(headerText);
        writer.RenderEndTag(); // Th
    }

    static void WriteTableRow(HtmlTextWriter writer, string cell1, string cell2, string cell3)
    {
        writer.RenderBeginTag(HtmlTextWriterTag.Tr);
        WriteTableCell(writer, cell1);
        WriteTableCell(writer, cell2);
        WriteTableCell(writer, cell3);
        writer.RenderEndTag(); // Tr
    }

    static void WriteTableCell(HtmlTextWriter writer, string cellText)
    {
        writer.RenderBeginTag(HtmlTextWriterTag.Td);
        writer.Write(cellText);
        writer.RenderEndTag(); // Td
    }
}
