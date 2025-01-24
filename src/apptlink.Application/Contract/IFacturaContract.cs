using System;
using PdfSharp.Pdf;

namespace apptlink.Application.Contract;

public interface IFacturaContract
{
    public Task<PdfDocument> GenerarFactura(int pedido_id);
}
