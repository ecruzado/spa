using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Consilium.Web.Controllers
{
    public class ClaseImpresionController : Controller
    {
        //
        // GET: /ClaseImpresion/

        public ActionResult Imprimir(int id)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4.Rotate(), 10, 20, 10, 20);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);


                PdfPTable mainTable = new PdfPTable(1);
                mainTable.HorizontalAlignment = Element.ALIGN_LEFT;
                mainTable.WidthPercentage = 100.0f;
                mainTable.SplitLate = false;
                // se definen los anchos de la tabla
                //float[] widthMainTable = new float[] { 100.0f };
                //mainTable.set(widthMainTable);

                PdfPCell celdaTitulo = new PdfPCell(new Phrase("Titulo"));
                // se alinea a la derecha
                celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
                // se quitan los bordes de la celda
                //celdaTitulo.Border = Rectangle.NO_BORDER;
                // se agrega la celda a la tabla
                mainTable.AddCell(celdaTitulo);

                mainTable.AddCell(GetPrimeraFilaContenido());

                var parrafo = new Phrase();
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));
                parrafo.Add("ola q ase".PadRight(500, 'e'));

                PdfPCell test = new PdfPCell(parrafo);
                // se alinea a la derecha
                test.HorizontalAlignment = Element.ALIGN_CENTER;
                // se quitan los bordes de la celda
                //celdaTitulo.Border = Rectangle.NO_BORDER;
                // se agrega la celda a la tabla
                mainTable.AddCell(test);

                PdfPCell celdaPiePagina = new PdfPCell(new Phrase("Pie de Pagina"));
                // se alinea a la derecha
                celdaPiePagina.HorizontalAlignment = Element.ALIGN_CENTER;
                // se quitan los bordes de la celda
                //celdaTitulo.Border = Rectangle.NO_BORDER;
                // se agrega la celda a la tabla
                mainTable.AddCell(celdaPiePagina);

                //Se inicializa el archivo PDF
                document.Open();
                document.Add(mainTable);
                // Se cierra el archivo Pdf
                document.Close();


                writer.Close();

                return File(memoryStream.ToArray(), "application/pdf");   
            }
        }

        private PdfPTable GetPrimeraFilaContenido() 
        {
            PdfPTable table = new PdfPTable(6);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            // se definen los anchos de la tabla
            float[] widthTable = new float[] { 20.0f, 20.0f, 20.0f, 20.0f, 20.0f, 20.0f };
            table.SetWidths(widthTable);

            for (int i = 0; i < 6; i++)
            {
                PdfPCell celdaTitulo = new PdfPCell(new Phrase("Fila 1-"+(i+1)));
                // se alinea a la derecha
                celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
                // se quitan los bordes de la celda
                //celdaTitulo.Border = Rectangle.NO_BORDER;
                // se agrega la celda a la tabla
                table.AddCell(celdaTitulo);
            }

            return table;
        } 
    }
}
