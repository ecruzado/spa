using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Consilium.Entity;
using Consilium.Logica;
using iTextSharp.text.html.simpleparser;

namespace Consilium.Web.Controllers
{
    public class ClaseImpresionController : Controller
    {
        //
        // GET: /ClaseImpresion/
        private ClaseMatriz claseMatriz;
        private ClaseActividad claseActividad;

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
                //HTMLWorker worker = HTMLWorker.

                mainTable.AddCell(celdaTitulo);
                mainTable.AddCell(GetPrimeraFila(id));

                mainTable.AddCell(GetSegundaFila(id));
                mainTable.AddCell(GetTerceraFila(id));
                mainTable.AddCell(GetFilaMatriz(id));

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

        private PdfPTable GetCabecera() 
        {
            PdfPTable table = new PdfPTable(1);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            
            PdfPCell celdaTitulo = new PdfPCell(new Phrase("Cabecera"));
            // se alinea a la derecha
            celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            // se quitan los bordes de la celda
            //celdaTitulo.Border = Rectangle.NO_BORDER;
            // se agrega la celda a la tabla
            table.AddCell(celdaTitulo);
            return table;
        }

        private PdfPTable GetPrimeraFila(int claseId)
        {
            PdfPTable table = new PdfPTable(4);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            // se definen los anchos de la tabla
            float[] widthTable = new float[] { 20.0f, 30.0f, 20.0f, 30.0f};
            table.SetWidths(widthTable);

            Clase clase = ClaseLogica.Instancia.Get(claseId);

            PdfPCell celdaLabelNombre = new PdfPCell(new Phrase("Titulo: "));
            celdaLabelNombre.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLabelNombre.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelNombre);

            PdfPCell celdaNombre = new PdfPCell(new Phrase(clase.Titulo));
            celdaNombre.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaNombre.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaNombre);

            PdfPCell celdaLabelArea = new PdfPCell(new Phrase("Area: "));
            celdaLabelArea.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLabelArea.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelArea);

            PdfPCell celdaArea = new PdfPCell(new Phrase("Religion"));
            celdaArea.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaArea.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaArea);

            PdfPCell celdaLabelNivel = new PdfPCell(new Phrase("Nivel: "));
            celdaLabelNivel.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLabelNivel.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelNivel);

            PdfPCell celdaNivel = new PdfPCell(new Phrase(clase.Nivel));
            celdaNivel.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaNivel.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaNivel);

            PdfPCell celdaLabelGrado = new PdfPCell(new Phrase("Grado: "));
            celdaLabelGrado.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLabelGrado.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelGrado);

            PdfPCell celdaGrado = new PdfPCell(new Phrase(clase.Grado));
            celdaGrado.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaGrado.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaGrado);

            PdfPCell celdaLabelFechaInicio = new PdfPCell(new Phrase("Fecha Inicio: "));
            celdaLabelFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLabelFechaInicio.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelFechaInicio);

            PdfPCell celdaFechaInicio = new PdfPCell(new Phrase(clase.FechaInicioFormato));
            celdaFechaInicio.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaFechaInicio.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaFechaInicio);

            PdfPCell celdaLabelFechaFin = new PdfPCell(new Phrase("Fecha Fin: "));
            celdaLabelFechaFin.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaLabelFechaFin.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelFechaFin);

            PdfPCell celdaFechaFin = new PdfPCell(new Phrase(clase.FechaFinFormato));
            celdaFechaFin.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaFechaFin.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaFechaFin);

            return table;
        }

        #region Segunda Fila

        private PdfPTable GetSegundaFila(int claseId) 
        {
            PdfPTable table = new PdfPTable(6);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            // se definen los anchos de la tabla
            float[] widthTable = new float[] { 20.0f, 20.0f, 20.0f, 20.0f, 20.0f, 20.0f };
            table.SetWidths(widthTable);

            table.AddCell(GetTablaCapacidades(claseId));
            table.AddCell(GetTablaContenidos(claseId));
            table.AddCell(GetTablaValores(claseId));
            table.AddCell(GetTablaMetodologia(claseId));

            for (int i = 4; i < 6; i++)
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

        private PdfPTable GetTablaCapacidades(int claseId)
        {
            PdfPTable tabla = new PdfPTable(1);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;

            PdfPCell celdaTituloCapacidad = new PdfPCell(new Phrase("1. Capcacidades"));
            celdaTituloCapacidad.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloCapacidad.Border = Rectangle.BOTTOM_BORDER;
            tabla.AddCell(celdaTituloCapacidad);

            PdfPCell celda = new PdfPCell();
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Border = Rectangle.NO_BORDER;

            var list = ClaseLogica.Instancia.ListClaseCapacidadByClase(claseId);
            var deAreaAnt = string.Empty;
            var especificaAnt = string.Empty;

            foreach (var item in list)
            {
                if (deAreaAnt != item.DeArea)
                {
                    celda.AddElement(new Phrase(item.Operativa));
                    deAreaAnt = item.DeArea;
                }
                if (especificaAnt != item.Especifica)
                {
                    celda.AddElement(new Phrase("  "+item.Especifica));
                    especificaAnt = item.Especifica;
                }
                celda.AddElement(new Phrase("    "+ item.Operativa));
            }
            tabla.AddCell(celda);
            return tabla;
        }
        
        private PdfPTable GetTablaContenidos(int claseId)
        {
            PdfPTable tabla = new PdfPTable(3);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 10.0f, 10.0f, 80.0f };
            tabla.SetWidths(widthTable);

            PdfPCell celdaTituloCapacidad = new PdfPCell(new Phrase("2. Contenidos"));
            celdaTituloCapacidad.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloCapacidad.Border = Rectangle.BOTTOM_BORDER;
            celdaTituloCapacidad.Colspan = 3;
            tabla.AddCell(celdaTituloCapacidad);

            PdfPCell celda = null;
           
            var list = ClaseLogica.Instancia.ListClaseContenidoByClase(claseId);
            var conocimientoAnt = string.Empty;
            var detalleAnt = string.Empty;

            foreach (var item in list)
            {
                if (conocimientoAnt != item.Conocimiento)
                {
                    celda = new PdfPCell(new Phrase(item.Conocimiento));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 3;
                    tabla.AddCell(celda);
                    
                    conocimientoAnt = item.Conocimiento;
                }
                if (detalleAnt != item.Detalle)
                {
                    celda = new PdfPCell(new Phrase(""));
                    celda.Border = Rectangle.NO_BORDER;
                    tabla.AddCell(celda);

                    celda = new PdfPCell(new Phrase(item.Detalle));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    
                    tabla.AddCell(celda);

                    detalleAnt = item.Detalle;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.ContenidoDesc));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            return tabla;
        }

        private PdfPTable GetTablaValores(int claseId)
        {
            PdfPTable tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 10.0f, 80.0f };
            tabla.SetWidths(widthTable);

            PdfPCell celdaTitulo = new PdfPCell(new Phrase("3. Valores"));
            celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTitulo.Border = Rectangle.BOTTOM_BORDER;
            celdaTitulo.Colspan = 2;
            tabla.AddCell(celdaTitulo);

            PdfPCell celda = null;

            var list = ClaseLogica.Instancia.ListClaseValorByClase(claseId);
            var valorAnt = string.Empty;

            foreach (var item in list)
            {
                if (valorAnt != item.Valor)
                {
                    celda = new PdfPCell(new Phrase(item.Valor));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    tabla.AddCell(celda);

                    valorAnt = item.Valor;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Actitud));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            return tabla;
        }
        
        private PdfPTable GetTablaMetodologia(int claseId)
        {
            PdfPTable tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 10.0f, 80.0f };
            tabla.SetWidths(widthTable);

            PdfPCell celdaTitulo = new PdfPCell(new Phrase("4. Metodologia"));
            celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTitulo.Border = Rectangle.BOTTOM_BORDER;
            celdaTitulo.Colspan = 2;
            tabla.AddCell(celdaTitulo);

            PdfPCell celda = null;

            var list = ClaseLogica.Instancia.ListClaseMetodoByClase(claseId);
            var criterioAnt = string.Empty;

            foreach (var item in list)
            {
                if (criterioAnt != item.Criterio)
                {
                    celda = new PdfPCell(new Phrase(item.Criterio));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    tabla.AddCell(celda);

                    criterioAnt = item.Criterio;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Metecnica));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            return tabla;
        }

        #endregion

        private PdfPTable GetTerceraFila(int claseId)
        {
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 70.0f, 10.0f, 20.0f };
            table.SetWidths(widthTable);

            claseMatriz = ClaseLogica.Instancia.GetClaseMatrizByClase(claseId);
            claseActividad = ClaseLogica.Instancia.GetClaseActividadByClase(claseId);

            PdfPTable tablaActividad = new PdfPTable(1);
            tablaActividad.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaActividad.WidthPercentage = 100.0f;

            PdfPCell celdaTituloActividad = new PdfPCell(new Phrase("7. Actividades"));
            celdaTituloActividad.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloActividad.Border = Rectangle.BOTTOM_BORDER;
            tablaActividad.AddCell(celdaTituloActividad);

            PdfPCell celdaActividad = new PdfPCell(new Phrase(claseActividad.Actividades));
            celdaActividad.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaActividad.Border = Rectangle.NO_BORDER;
            tablaActividad.AddCell(celdaActividad);

            table.AddCell(tablaActividad);


            PdfPTable tablaActividadHora = new PdfPTable(1);
            tablaActividadHora.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaActividadHora.WidthPercentage = 100.0f;

            PdfPCell celdaTituloActividadHora = new PdfPCell(new Phrase("8. Horas"));
            celdaTituloActividadHora.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloActividadHora.Border = Rectangle.BOTTOM_BORDER;
            tablaActividadHora.AddCell(celdaTituloActividadHora);

            PdfPCell celdaActividadHora = new PdfPCell(new Phrase(claseActividad.Horas));
            celdaActividadHora.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaActividadHora.Border = Rectangle.NO_BORDER;
            tablaActividadHora.AddCell(celdaActividadHora);

            table.AddCell(tablaActividadHora);


            PdfPTable tablaArchivo = new PdfPTable(1);
            tablaArchivo.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaArchivo.WidthPercentage = 100.0f;

            PdfPCell celdaTituloArchivo = new PdfPCell(new Phrase("8. Archivos"));
            celdaTituloArchivo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloArchivo.Border = Rectangle.BOTTOM_BORDER;
            tablaArchivo.AddCell(celdaTituloArchivo);

            PdfPCell celdaArchivo = new PdfPCell(new Phrase(""));
            celdaArchivo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaArchivo.Border = Rectangle.NO_BORDER;
            tablaArchivo.AddCell(celdaArchivo);

            table.AddCell(tablaActividad);

            return table;
        }

        private PdfPTable GetFilaMatriz(int claseId)
        {
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 70.0f, 10.0f, 20.0f };
            table.SetWidths(widthTable);

            claseMatriz = ClaseLogica.Instancia.GetClaseMatrizByClase(claseId);

            PdfPTable tablaIndicadorLogro = new PdfPTable(1);
            tablaIndicadorLogro.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaIndicadorLogro.WidthPercentage = 100.0f;

            PdfPCell celdaTituloIndicadorLogro = new PdfPCell(new Phrase("1. Indicador Logro"));
            celdaTituloIndicadorLogro.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloIndicadorLogro.Border = Rectangle.BOTTOM_BORDER;
            tablaIndicadorLogro.AddCell(celdaTituloIndicadorLogro);

            PdfPCell celdaIndicadorLogro = new PdfPCell(new Phrase(claseMatriz.IndicadorLogro));
            celdaIndicadorLogro.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaIndicadorLogro.Border = Rectangle.NO_BORDER;
            tablaIndicadorLogro.AddCell(celdaIndicadorLogro);

            table.AddCell(tablaIndicadorLogro);


            PdfPTable tablaTipoConocimiento = new PdfPTable(1);
            tablaTipoConocimiento.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaTipoConocimiento.WidthPercentage = 100.0f;

            PdfPCell celdaTituloTipoConocimiento = new PdfPCell(new Phrase("2. Tipo Conocimiento"));
            celdaTituloTipoConocimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloTipoConocimiento.Border = Rectangle.BOTTOM_BORDER;
            tablaTipoConocimiento.AddCell(celdaTituloTipoConocimiento);

            PdfPCell celdaTipoConocimiento = new PdfPCell(new Phrase(""));
            celdaTipoConocimiento.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTipoConocimiento.Border = Rectangle.NO_BORDER;
            tablaTipoConocimiento.AddCell(celdaTipoConocimiento);

            table.AddCell(tablaTipoConocimiento);


            PdfPTable tablaPrueba = new PdfPTable(1);
            tablaPrueba.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaPrueba.WidthPercentage = 100.0f;

            PdfPCell celdaTituloExamen = new PdfPCell(new Phrase("3. Examen"));
            celdaTituloExamen.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloExamen.Border = Rectangle.BOTTOM_BORDER;
            tablaPrueba.AddCell(celdaTituloExamen);

            PdfPCell celdaExamen = new PdfPCell(new Phrase(claseMatriz.PruebaTexto));
            celdaExamen.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaExamen.Border = Rectangle.NO_BORDER;
            tablaPrueba.AddCell(celdaExamen);

            table.AddCell(tablaIndicadorLogro);

            return table;
        }

    }
}
