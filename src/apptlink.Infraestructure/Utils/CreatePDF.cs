using System;
using System.Threading.Tasks;
using apptlink.Application.Contract;
using apptlink.Domain.Models;
using apptlink.Domain.Types;
using apptlink.Infraestructure.Context;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace apptlink.Infraestructure.Utils;

public class CreatePDF
{
    private readonly DB _context;

    public CreatePDF(DB context)
    {
        _context = context;
    }

    public async Task<PdfDocument> Exect(UsuarioModel usuario, PedidoModel pedido, List<DetallePedidoModel> ListaDetallePedido)
    {
        // Crear un nuevo documento PDF
        PdfDocument doc = new PdfDocument();
        PdfPage page = doc.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);
        XFont font = new XFont("Verdana", 20, XFontStyleEx.Bold);

        // Obtener la página actual y su tamaño
        XRect rect = new XRect(0, 0, page.Width.Point, page.Height.Point);

        // Agregar un título
        XRect layoutRectangle = new XRect(0, 0, page.Width.Value, 0); // Altura del rectángulo de diseño debe ser 0
        gfx.DrawString("Factura", font, XBrushes.Black, layoutRectangle, XStringFormats.TopLeft);

        // Agregar detalles de la factura (ejemplo)
        gfx.DrawString($"Cliente: {usuario.Nombre} {usuario.Apellido}", new XFont("Arial", 12), XBrushes.Black, new XRect(50, 50, rect.Width, 20));
        gfx.DrawString($"Fecha: {pedido.FechaCreacion:dd/MM/yyyy}", new XFont("Arial", 12), XBrushes.Black, new XRect(50, 70, rect.Width, 20));

        // Crear una tabla para los productos
        int columns = 5;
        double cellHeight = 20;
        double cellWidth = (rect.Width - 100) / columns;

        // Crear una lista de tareas para obtener los detalles de los productos
        Task<string[]>[]? lista_detalles = ListaDetallePedido.Select(async data =>
        {
            // Obtener el producto
            ProductosModel? producto = await _context.Producto.FindAsync(data.ProductoId);
            // Si el producto no existe, retornar un array vacío
            if(producto == null) return ["", "", "", "", ""];

            // Retornar un array con los detalles del producto
            return new string[] { producto.Nombre!, data.Cantidad.ToString(), data.PrecioUnitario.ToString(), data.Descuento.ToString(), data.Impuesto.ToString() };
        }).ToArray();

        // Esperar a que todas las tareas se completen
        string[][] jaggedData = await Task.WhenAll(lista_detalles);

        // Crear un array bidimensional con los datos de los productos
        string[,] data = new string[lista_detalles.Count(), columns];

        // Llenar el array bidimensional con los datos de los productos
        for (int i = 0; i < lista_detalles.Count(); i++)
        {
            for (int j = 0; j < columns; j++)
            {
                data[i, j] = jaggedData[i][j];
            }
        }

        // Dibujar la tabla en el PDF
        for (int row = 0; row < lista_detalles.Count(); row++)
        {
            // Dibujar el borde superior de la celda
            for (int col = 0; col < columns; col++)
            {
                // Dibujar el borde de la celda
                gfx.DrawRectangle(XPens.Black, XBrushes.White, 50 + col * cellWidth, 100 + row * cellHeight, cellWidth, cellHeight);
                gfx.DrawString(data[row, col], new XFont("Arial", 12), XBrushes.Black, new XRect(50 + col * cellWidth, 100 + row * cellHeight, cellWidth, cellHeight), XStringFormats.Center);
            }
        }

        // Guardar el PDF
        doc.Save("mi_factura.pdf");

        // Retornar el documento PDF
        return doc;
    }
}
