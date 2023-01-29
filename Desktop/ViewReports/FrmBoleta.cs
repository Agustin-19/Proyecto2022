using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.ViewReports
{
    public partial class FrmBoleta : Form
    {

        ReportViewer reporte = new ReportViewer();
        UnitOfWork unitOfWork = new UnitOfWork();
        int ventaSeleccionada;
       

        public FrmBoleta(int IdVenta)
        {
            InitializeComponent();

            ventaSeleccionada = IdVenta;
            reporte.Dock = DockStyle.Fill;
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.ZoomMode = ZoomMode.Percent;
            reporte.ZoomPercent = 100;
            Controls.Add(reporte);
        }

       

        private async void FrmBoleta_Load(object sender, EventArgs e)
        {
            if (ventaSeleccionada > 0)
            {


                reporte.LocalReport.ReportEmbeddedResource = "Desktop.Reports.RptBoleta.rdlc";
                var ventaDetalle = await unitOfWork.VentaDetalleRepository.GetAllAsync(
                    filter:d => d.IdVenta==ventaSeleccionada);

                var ventas = from VentaDetalle detalleDeVenta in ventaDetalle
                             
                             select new
                             {
                                 //Datos detalle de venta
                                 Id = detalleDeVenta.Id,
                                 IdVenta = detalleDeVenta.IdVenta,
                                 IdProducto = detalleDeVenta.IdProducto,
                                 Producto = detalleDeVenta.Producto,
                                 PrecioVenta = detalleDeVenta.PrecioVenta,
                                 Cantidad = detalleDeVenta.Cantidad,
                                 SubTotal = detalleDeVenta.SubTotal,
                                 //Datos de venta 
                                 DNICliente = detalleDeVenta.DNICliente,
                                 NombreCliente = detalleDeVenta.NombreCliente,
                                 MontoPago = detalleDeVenta.MontoPago,
                                 MontoTotal = detalleDeVenta.MontoTotal,
                                 MontoCambio = detalleDeVenta.MontoCambio,
                                 FechaRegistro = detalleDeVenta.FechaRegistro
                             };
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DataSetReportes", ventas));

                reporte.RefreshReport();
            }
        }
    }
}
