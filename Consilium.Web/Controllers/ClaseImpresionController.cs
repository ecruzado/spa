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
using iTextSharp.text.html;

namespace Consilium.Web.Controllers
{
    public class ClaseImpresionController : Controller
    {
        //
        // GET: /ClaseImpresion/
        private ClaseMatriz claseMatriz;
        private ClaseActividad claseActividad;
        private Clase clase;
        private List<ColumnaColegio> columnas;
        Font normal;
        Font negrita;
        Font letraTitulo;

        public ActionResult Imprimir(int id)
        {
            clase = ClaseLogica.Instancia.Get(id);
            columnas = ColumnaColegioLogica.Instancia.ListByColegio(clase.ColegioId);

            letraTitulo = new Font(FontFactory.GetFont("Arial", 11, Font.BOLD));
            normal = new Font(FontFactory.GetFont("Arial", 9, Font.NORMAL));
            negrita = new Font(FontFactory.GetFont("Arial", 9, Font.BOLD));

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

                mainTable.AddCell(GetEncabezado());

                PdfPCell celdaTitulo = new PdfPCell(new Phrase("Diseño de Clase", letraTitulo));
                // se alinea a la derecha
                celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
                // se quitan los bordes de la celda
                //celdaTitulo.Border = Rectangle.NO_BORDER;
                // se agrega la celda a la tabla
                //HTMLWorker worker = HTMLWorker.

                mainTable.AddCell(celdaTitulo);
                mainTable.AddCell(GetPrimeraFila(id));

                mainTable.AddCell(GetSegundaFila(id));
                mainTable.AddCell(GetFilaActividad(id));
                mainTable.AddCell(GetFilaMatriz(id));

                mainTable.AddCell(GetTablaComentario(id));

                //Se inicializa el archivo PDF
                document.Open();
                document.Add(mainTable);
                // Se cierra el archivo Pdf
                document.Close();


                writer.Close();

                return File(memoryStream.ToArray(), "application/pdf");   
            }
        }

        private PdfPTable GetEncabezado() 
        {
            //se crea la  1 tabla que contiene las celdas
            PdfPTable table1 = new PdfPTable(2);

            // se definen los anchos de la tabla
            float[] anchos1 = new float[] { 20.0f, 80.0f };
            table1.SetWidths(anchos1);

            // se crea la celda con el valor que contiene
            string imagepath = Server.MapPath(@"~/Images");
            //Image img = Image.GetInstance(imagepath + "/logocentro.jpg");
            //img.ScalePercent(7f);
            //PdfPCell logo = new PdfPCell(img);
            PdfPCell logo = new PdfPCell();
            logo.HorizontalAlignment = Element.ALIGN_LEFT;
            // se quitan los bordes de la celda
            logo.Border = Rectangle.NO_BORDER;
            // se agrega la celda a la tabla
            table1.AddCell(logo);
            PdfPCell celdaVacia = new PdfPCell(new Phrase(clase.Colegio,letraTitulo));
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.VerticalAlignment = Element.ALIGN_MIDDLE;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table1.AddCell(celdaVacia);


            return table1;        
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
            PdfPCell celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;

            PdfPTable table = new PdfPTable(12);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            // se definen los anchos de la tabla
            float[] widthTable = new float[] { 8.0f, 2.0f, 15.0f, 8.0f, 2.0f, 7.0f, 12.0f, 2.0f, 15.0f, 12.0f, 2.0f, 15.0f };
            table.SetWidths(widthTable);

            PdfPCell celdaLabelNombre = new PdfPCell(new Phrase("Título", negrita));
            celdaLabelNombre.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelNombre.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelNombre);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaNombre = new PdfPCell(new Phrase(clase.Titulo,normal));
            celdaNombre.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaNombre.Border = Rectangle.NO_BORDER;
            celdaNombre.Colspan = 10;
            table.AddCell(celdaNombre);

            PdfPCell celdaLabelArea = new PdfPCell(new Phrase("Área",negrita));
            celdaLabelArea.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelArea.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelArea);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaArea = new PdfPCell(new Phrase(clase.Area,normal));
            celdaArea.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaArea.Border = Rectangle.NO_BORDER;
            celdaArea.Colspan = 4;
            table.AddCell(celdaArea);

            PdfPCell celdaLabelUsuario = new PdfPCell(new Phrase("Usuario", negrita));
            celdaLabelUsuario.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelUsuario.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelUsuario);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaUsuario = new PdfPCell(new Phrase(clase.Usuario, normal));
            celdaUsuario.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaUsuario.Border = Rectangle.NO_BORDER;
            celdaUsuario.Colspan = 4;
            table.AddCell(celdaUsuario);

            PdfPCell celdaLabelNivel = new PdfPCell(new Phrase("Nivel", negrita));
            celdaLabelNivel.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelNivel.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelNivel);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaNivel = new PdfPCell(new Phrase(clase.Nivel, normal));
            celdaNivel.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaNivel.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaNivel);

            PdfPCell celdaLabelGrado = new PdfPCell(new Phrase("Grado", negrita));
            celdaLabelGrado.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelGrado.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelGrado);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaGrado = new PdfPCell(new Phrase(clase.Grado, normal));
            celdaGrado.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaGrado.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaGrado);

            PdfPCell celdaLabelFechaInicio = new PdfPCell(new Phrase("Fecha Inicio", negrita));
            celdaLabelFechaInicio.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelFechaInicio.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelFechaInicio);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaFechaInicio = new PdfPCell(new Phrase(clase.FechaInicioFormato,normal));
            celdaFechaInicio.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaFechaInicio.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaFechaInicio);

            PdfPCell celdaLabelFechaFin = new PdfPCell(new Phrase("Fecha Fin", negrita));
            celdaLabelFechaFin.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaLabelFechaFin.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaLabelFechaFin);
            celdaVacia = new PdfPCell();
            celdaVacia.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaVacia.Border = Rectangle.NO_BORDER;
            table.AddCell(celdaVacia);

            PdfPCell celdaFechaFin = new PdfPCell(new Phrase(clase.FechaFinFormato, normal));
            celdaFechaFin.HorizontalAlignment = Element.ALIGN_LEFT;
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
            table.DefaultCell.Border = Rectangle.RIGHT_BORDER;            
            // se definen los anchos de la tabla
            float[] widthTable = new float[] { 20.0f, 20.0f, 20.0f, 20.0f, 20.0f, 20.0f };
            table.SetWidths(widthTable);

            table.AddCell(GetTablaCapacidades(claseId));
            table.AddCell(GetTablaMetodologia(claseId));
            table.AddCell(GetTablaContenidos(claseId));
            table.AddCell(GetTablaValores(claseId));
            table.AddCell(GetTablaColumna3Nodos(claseId,1));
            table.AddCell(GetTablaColumna3Nodos(claseId,2));
            
            return table;
        }

        private PdfPTable GetTablaCapacidades(int claseId)
        {
            PdfPTable tabla = new PdfPTable(1);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            
            PdfPCell celdaTituloCapacidad = new PdfPCell(new Phrase("1. Capacidades",negrita));
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
                    celda.AddElement(new Phrase(item.DeArea,normal));
                    deAreaAnt = item.DeArea;
                }
                if (especificaAnt != item.Especifica)
                {
                    celda.AddElement(new Phrase("  "+item.Especifica,normal));
                    especificaAnt = item.Especifica;
                }
                celda.AddElement(new Phrase("    "+ item.Operativa,normal));
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

            PdfPCell celdaTituloCapacidad = new PdfPCell(new Phrase("3. Contenidos",negrita));
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
                    celda = new PdfPCell(new Phrase(item.Conocimiento,normal));
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

                    celda = new PdfPCell(new Phrase(item.Detalle,normal));
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

                celda = new PdfPCell(new Phrase(item.ContenidoDesc,normal));
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

            PdfPCell celdaTitulo = new PdfPCell(new Phrase("4. Valores",negrita));
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
                    celda = new PdfPCell(new Phrase(item.Valor,normal));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    tabla.AddCell(celda);

                    valorAnt = item.Valor;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Actitud,normal));
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

            PdfPCell celdaTitulo = new PdfPCell(new Phrase("2. Metodología",negrita));
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
                    celda = new PdfPCell(new Phrase(item.Criterio,normal));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    tabla.AddCell(celda);

                    criterioAnt = item.Criterio;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Metecnica,normal));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            return tabla;
        }
        
        private PdfPTable GetTablaColumna3Nodos(int claseId, int columnaId)
        {
            PdfPTable tabla = new PdfPTable(3);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 10.0f, 10.0f, 80.0f };
            tabla.SetWidths(widthTable);

            PdfPCell celdaTituloCapacidad = new PdfPCell(new Phrase(GetNombreColumna(columnaId), negrita));
            celdaTituloCapacidad.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloCapacidad.Border = Rectangle.BOTTOM_BORDER;
            celdaTituloCapacidad.Colspan = 3;
            tabla.AddCell(celdaTituloCapacidad);

            PdfPCell celda = null;

            var list = ClaseConfColumnaColegioLogica.Instancia.ListByClase(new ClaseColColumnaColegio { ClaseId = claseId, ColumnaId = columnaId });
            var nodo1IdAnt = 0;
            var nodo2IdAnt = 0;

            foreach (var item in list)
            {
                if (nodo1IdAnt != item.Nodo1Id)
                {
                    celda = new PdfPCell(new Phrase(item.Nodo1Valor, normal));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 3;
                    tabla.AddCell(celda);

                    nodo1IdAnt = item.Nodo1Id;
                }
                if (nodo2IdAnt != item.Nodo2Id)
                {
                    celda = new PdfPCell(new Phrase(""));
                    celda.Border = Rectangle.NO_BORDER;
                    tabla.AddCell(celda);

                    celda = new PdfPCell(new Phrase(item.Nodo2Valor, normal));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;

                    tabla.AddCell(celda);

                    nodo2IdAnt = item.Nodo2Id;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Nodo3Valor, normal));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            return tabla;
        }

        private string GetNombreColumna(int columnaId)
        {
            return columnas.FirstOrDefault(x => x.ColumnaId == columnaId).Nombre;
        }

        #endregion

        private PdfPTable GetFilaActividad(int claseId)
        {
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 70.0f, 10.0f, 20.0f };
            table.SetWidths(widthTable);
            table.DefaultCell.Border = Rectangle.RIGHT_BORDER;       

            claseActividad = ClaseLogica.Instancia.GetClaseActividadByClase(claseId);

            PdfPTable tablaActividad = new PdfPTable(1);
            tablaActividad.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaActividad.WidthPercentage = 100.0f;

            PdfPCell celdaTituloActividad = new PdfPCell(new Phrase("7. Actividades",negrita));
            celdaTituloActividad.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloActividad.Border = Rectangle.BOTTOM_BORDER;
            tablaActividad.AddCell(celdaTituloActividad);

            PdfPCell celdaActividad;
            StyleSheet styles = new StyleSheet();
            styles.LoadTagStyle(HtmlTags.P, HtmlTags.SIZE, "9f");
            styles.LoadTagStyle(HtmlTags.LI, HtmlTags.SIZE, "9f");

            var lista = HTMLWorker.ParseToList(new StringReader(claseActividad.Actividades), styles);
            foreach (var item in lista)
            {
                //if (item is Paragraph)
                //{
                //    //((Paragraph)item).Font = normal;
                //    Paragraph itemPar = (Paragraph)item;
                //    foreach (Chunk chunk in itemPar.Chunks) 
                //    {
                //        if (chunk.Content != "\n")
                //        {
                //            celdaActividad = new PdfPCell();
                //            celdaActividad.Border = Rectangle.NO_BORDER;
                //            celdaActividad.AddElement((IElement)chunk);
                //            tablaActividad.AddCell(celdaActividad);
                //        }
                //    }
                //}
                celdaActividad = new PdfPCell();
                celdaActividad.Border = Rectangle.NO_BORDER;
                celdaActividad.AddElement((IElement)item);
                tablaActividad.AddCell(celdaActividad);
            }
            

            //tablaActividad.AddCell(celdaActividad);
            //tablaActividad.SplitRows = true;
            //tablaActividad.SplitLate = true;
            tablaActividad.KeepTogether = false;
            table.AddCell(tablaActividad);

            PdfPTable tablaActividadHora = new PdfPTable(1);
            tablaActividadHora.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaActividadHora.WidthPercentage = 100.0f;

            PdfPCell celdaTituloActividadHora = new PdfPCell(new Phrase("8. Horas",negrita));
            celdaTituloActividadHora.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloActividadHora.Border = Rectangle.BOTTOM_BORDER;
            tablaActividadHora.AddCell(celdaTituloActividadHora);

            PdfPCell celdaActividadHora = new PdfPCell(new Phrase(claseActividad.Horas,normal));
            celdaActividadHora.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaActividadHora.Border = Rectangle.NO_BORDER;
            tablaActividadHora.AddCell(celdaActividadHora);

            table.AddCell(tablaActividadHora);

            var listaClaseArchivos = ClaseLogica.Instancia.ListClaseArchivoByClase(claseId);

            PdfPTable tablaArchivo = new PdfPTable(2);
            tablaArchivo.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaArchivo.WidthPercentage = 100.0f;
            float[] widthTableArchivos = new float[] { 10.0f, 90.0f };
            tablaArchivo.SetWidths(widthTableArchivos);
            tablaArchivo.DefaultCell.Border = Rectangle.RIGHT_BORDER;   

            PdfPCell celdaTituloArchivo = new PdfPCell(new Phrase("9. Archivos",negrita));
            celdaTituloArchivo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloArchivo.Border = Rectangle.BOTTOM_BORDER;
            celdaTituloArchivo.Colspan = 2;
            tablaArchivo.AddCell(celdaTituloArchivo);

            PdfPCell celda;
            foreach (var archivo in listaClaseArchivos)
            {
                celda = new PdfPCell();
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Border = Rectangle.NO_BORDER;
                tablaArchivo.AddCell(celda);

                PdfPCell celdaArchivo = new PdfPCell(new Phrase(archivo.Nombre,normal));
                celdaArchivo.HorizontalAlignment = Element.ALIGN_LEFT;
                celdaArchivo.Border = Rectangle.NO_BORDER;
                tablaArchivo.AddCell(celdaArchivo);
            }

            table.AddCell(tablaArchivo);

            return table;
        }

        #region Matriz
        
        private PdfPTable GetFilaMatriz(int claseId)
        {
            PdfPTable table = new PdfPTable(1);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 100.0f};
            table.SetWidths(widthTable);

            claseMatriz = ClaseLogica.Instancia.GetClaseMatrizByClase(claseId);
            table.AddCell(GetFilaMatrizCombos(claseId));
            table.AddCell(GetSegundaFilaMatriz(claseId));

            return table;
        }

        private PdfPTable GetFilaMatrizCombos(int claseId)
        {
            PdfPTable tableMatrizCombo = new PdfPTable(7);
            tableMatrizCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            tableMatrizCombo.WidthPercentage = 100.0f;
            tableMatrizCombo.DefaultCell.Border = Rectangle.NO_BORDER;
            float[] widthTable = new float[] { 15.0f, 15.0f, 15.0f, 15.0f, 15.0f, 15.0f, 10.0f};
            tableMatrizCombo.SetWidths(widthTable);

            PdfPCell celdaCombo = null;

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.Formativa)+"Formativa",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.RIGHT_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.Sumativa) + "Sumativa",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.RIGHT_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.AutoEvaluativa) + "AutoEvaluativa",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.RIGHT_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.Coevaluativa) + "Coevaluativa",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.RIGHT_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.HeteroEvalucion) + "HeteroEvalucion",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.RIGHT_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.Censal) + "Censal",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.RIGHT_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            celdaCombo = new PdfPCell(new Phrase(EtiquetaCheck(claseMatriz.Muestral) + "Muestral",normal));
            celdaCombo.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaCombo.Border = Rectangle.NO_BORDER;
            tableMatrizCombo.AddCell(celdaCombo);

            return tableMatrizCombo;
        }
        
        private string EtiquetaCheck(bool valor) 
        {
            return valor ? "(X) " : "( ) ";
        }

        private PdfPTable GetSegundaFilaMatriz(int claseId)
        {
            PdfPTable table = new PdfPTable(5);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100.0f;
            table.DefaultCell.Border = Rectangle.RIGHT_BORDER;
            // se definen los anchos de la tabla
            float[] widthTable = new float[] { 20.0f, 20.0f, 20.0f, 20.0f, 40.0f };
            table.SetWidths(widthTable);

            table.AddCell(GetTablaIndicadoresLogro(claseId));
            table.AddCell(GetTablaTiposConocimiento(claseId));
            table.AddCell(GetTablaColumna3Nodos(claseId,3));
            table.AddCell(GetTablaColumna3Nodos(claseId,4));
            table.AddCell(GetTablaPrueba(claseId));

            return table;
        }

        private PdfPTable GetTablaIndicadoresLogro(int claseId)
        {
            PdfPTable tablaIndicadoresLogro = new PdfPTable(1);
            tablaIndicadoresLogro.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaIndicadoresLogro.WidthPercentage = 100.0f;
            tablaIndicadoresLogro.DefaultCell.Border = Rectangle.NO_BORDER;

            PdfPCell celdaTituloIndicadorLogro = new PdfPCell(new Phrase("1. Indicadores Logro", negrita));
            celdaTituloIndicadorLogro.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloIndicadorLogro.Border = Rectangle.BOTTOM_BORDER;
            tablaIndicadoresLogro.AddCell(celdaTituloIndicadorLogro);

            PdfPCell celdaIndicadorLogro = new PdfPCell(new Phrase(claseMatriz.IndicadorLogro,normal));
            celdaIndicadorLogro.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaIndicadorLogro.Border = Rectangle.NO_BORDER;
            tablaIndicadoresLogro.AddCell(celdaIndicadorLogro);
            return tablaIndicadoresLogro;
        }
        
        private PdfPTable GetTablaTiposConocimiento(int claseId)
        {
            PdfPTable tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 10.0f, 90.0f };
            tabla.SetWidths(widthTable);

            PdfPCell celdaTitulo = new PdfPCell(new Phrase("2. Tipo de Conocimiento", negrita));
            celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTitulo.Border = Rectangle.BOTTOM_BORDER;
            celdaTitulo.Colspan = 2;
            tabla.AddCell(celdaTitulo);

            PdfPCell celda = null;

            var list = ClaseLogica.Instancia.ListClaseConocimientoByClase(claseId);
            var nodo1IdAnt = 0;

            foreach (var item in list)
            {
                if (nodo1IdAnt != item.Nodo1Id)
                {
                    celda = new PdfPCell(new Phrase(item.Nodo1Valor, normal));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    tabla.AddCell(celda);

                    nodo1IdAnt = item.Nodo1Id;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Nodo2Valor, normal));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            return tabla;
        }

        private PdfPTable GetTablaPrueba(int claseId)
        {
            PdfPTable tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = Element.ALIGN_LEFT;
            tabla.WidthPercentage = 100.0f;
            float[] widthTable = new float[] { 10.0f, 90.0f };
            tabla.SetWidths(widthTable);

            PdfPCell celdaTitulo = new PdfPCell(new Phrase("5. Pruebas", negrita));
            celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTitulo.Border = Rectangle.BOTTOM_BORDER;
            celdaTitulo.Colspan = 2;
            tabla.AddCell(celdaTitulo);

            PdfPCell celda = null;

            var list = ClaseLogica.Instancia.ListClasePruebaByClase(claseId);
            var nodo1IdAnt = 0;

            foreach (var item in list)
            {
                if (nodo1IdAnt != item.Nodo1Id)
                {
                    celda = new PdfPCell(new Phrase(item.Nodo1Valor, normal));
                    celda.HorizontalAlignment = Element.ALIGN_LEFT;
                    celda.Border = Rectangle.NO_BORDER;
                    celda.Colspan = 2;
                    tabla.AddCell(celda);

                    nodo1IdAnt = item.Nodo1Id;
                }
                celda = new PdfPCell(new Phrase(""));
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

                celda = new PdfPCell(new Phrase(item.Nodo2Valor, normal));
                celda.HorizontalAlignment = Element.ALIGN_LEFT;
                celda.Border = Rectangle.NO_BORDER;
                tabla.AddCell(celda);

            }
            celda = new PdfPCell(new Phrase(""));
            celda.Border = Rectangle.NO_BORDER;
            celda.Colspan = 2;
            tabla.AddCell(celda);

            celdaTitulo = new PdfPCell(new Phrase("Ingrese algun comentario referente a la prueba", negrita));
            celdaTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTitulo.Border = Rectangle.BOTTOM_BORDER;
            celdaTitulo.Colspan = 2;
            tabla.AddCell(celdaTitulo);

            celda = new PdfPCell(new Phrase(claseMatriz.PruebaTexto,normal));
            celda.HorizontalAlignment = Element.ALIGN_LEFT;
            celda.Border = Rectangle.NO_BORDER;
            celda.Colspan = 2;
            tabla.AddCell(celda);

            return tabla;
        }

        private PdfPTable GetTablaComentario(int claseId)
        {
            PdfPTable tablaComentario = new PdfPTable(1);
            tablaComentario.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaComentario.WidthPercentage = 100.0f;
            tablaComentario.DefaultCell.Border = Rectangle.NO_BORDER;

            PdfPCell celdaTituloComentario = new PdfPCell(new Phrase("Ingrese algun comentario referente a la clase", negrita));
            celdaTituloComentario.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTituloComentario.Border = Rectangle.BOTTOM_BORDER;
            tablaComentario.AddCell(celdaTituloComentario);

            PdfPCell celdaComentario = new PdfPCell(new Phrase(claseMatriz.ObservacionClase, normal));
            celdaComentario.HorizontalAlignment = Element.ALIGN_LEFT;
            celdaComentario.Border = Rectangle.NO_BORDER;
            tablaComentario.AddCell(celdaComentario);
            return tablaComentario;
        }

        #endregion
    }
}
