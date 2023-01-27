using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using Desktop.ViewReports;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class FrmInicio : Form
    {
        IUnitOfWork unitOfWork = new UnitOfWork();
        BindingSource listaProductos = new BindingSource();
        BindingSource listaVentas = new BindingSource();
        BindingSource listaVentaDetalles = new BindingSource();
        string ventaSeleccionada = "";
        string fechaVenta = "";
        int idVentaSeleccionada = 0;
        public FrmInicio()
        {
            InitializeComponent();
            GetAll();
            
           
        }

        private async Task GetAll()
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.Nombre));
            gridProductos.DataSource = listaProductos;


            listaVentas.DataSource = await unitOfWork.VentaRepository.GetAllAsync(orderBy: c => c.OrderByDescending(c => c.Id));
            GridVenta1.DataSource = listaVentas;
            GridVenta2.DataSource = listaVentas;


            
        }

        private async Task GetAll(string txtBusqueda)
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(filter: c => c.Nombre.Contains(txtBusqueda), orderBy: c => c.OrderBy(c => c.Nombre));
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
           await GetAll(txtBusqueda.Text);
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            TxtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LimpiarProducto();
            LimpiarCliente();
            NudCantidad.Value = 1;

        }


        private void LimpiarProducto()
        {
            TxtProducto.Text = "";
            TxtPrecio.Text = "0,00";
            TxtIdProducto.Text = "0";
            TxtMarca.Text = "";
            NudCantidad.Value = 1;
            BtnAgregar.Enabled = false;
        }
        private void LimpiarCliente()
        {
            TxtIdCliente.Text = "0";
            TxtNombre.Text = "Consumidor Final";
            NudDNI.Value = 11111;
            TxtPaga.Text = "";
            TxtCambio.Text = "0,00";
            TxtTotal.Text = "0,00";
            BtnCrearVenta.Enabled = false;

        }

        private void BtnEscribir_Click(object sender, EventArgs e)
        {
            RecuperarEscribir();
            BtnAgregar.Enabled = true;
        }

        private void RecuperarEscribir()
        {
            var producto = (Producto)listaProductos.Current;

            TxtIdProducto.Text = producto.Id.ToString("0");
            TxtProducto.Text = producto.Nombre;
            TxtMarca.Text = producto.Marca;
            TxtPrecio.Text = producto.Precio.ToString("0.00");
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExiste = false;

            if (TxtProducto == null)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(TxtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(NudCantidad.Value.ToString()) >= 0)
            {

            }

            foreach (DataGridViewRow fila in GridVentas.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == TxtIdProducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                GridVentas.Rows.Add(new object[]
                {
                    TxtIdProducto.Text,
                    TxtProducto.Text,
                    precio.ToString("0.00"),
                    NudCantidad.Value.ToString(),
                    (NudCantidad.Value * precio).ToString("0.00")
                });
            }

            CalcularTotal();
            LimpiarProducto();
            TxtProducto.Select();
        }


        // calcular el total sumando los valores en la celda SubTotal
        private void CalcularTotal()
        {
            decimal total = 0;
            if (GridVentas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in GridVentas.Rows)
                    total += Convert.ToDecimal(row.Cells["SubTotal"].Value.ToString());
            }
            TxtTotal.Text = total.ToString("0.00");
        }

        private void TxtPaga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (TxtPaga.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void calcularCambio()
        {
            if (TxtTotal.Text.Trim() == "0,00")
            {
                MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal pagacon;
            decimal total = Convert.ToDecimal(TxtTotal.Text);

            if (TxtPaga.Text.Trim() == "")
            {
                TxtPaga.Text = "0";
            }

            if (decimal.TryParse(TxtPaga.Text.Trim(), out pagacon))
            {
                if (pagacon < total)
                {
                    MessageBox.Show("El valor es menor al total", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    decimal cambio = pagacon - total;
                    TxtCambio.Text = cambio.ToString("0.00");
                    BtnCrearVenta.Enabled = true;
                }
            }

        }

        private void TxtPaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularCambio();
            }
        }

        private async void BtnCrearVenta_Click(object sender, EventArgs e)
        {
            // asegurar que se ingrese un cliente. Por defecto esta Seleccionado "consumidor final" 
            if (TxtNombre.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // si no hay proguctos ingresados en el DataGridView, no pordra seguir con la venta

            if (GridVentas.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar un Producto para continuar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            calcularCambio();

            //Guardar datos de la venta...
            await GuardarVenta();



            //optengo el Ultimo Id generado en la tabla "Ventas"
            //para luego utilizarlo en la tabla "DetalleDeVentas"



            int OptnerIDVenta = GridVenta1.RowCount + 1;
            await GetAll();

            //el foreach recorre el DataGridView para optener los datos de los productos.
            foreach (DataGridViewRow row in GridVentas.Rows)
            {
                // se guardan los datos optenidos en la tabla "VentaDetalle"
                VentaDetalle ventaDetalle = new VentaDetalle();

                ventaDetalle.IdVenta = OptnerIDVenta;
                ventaDetalle.IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                ventaDetalle.Producto = Convert.ToString(row.Cells["Producto"].Value);
                ventaDetalle.PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value);
                ventaDetalle.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                ventaDetalle.SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);
                //datos extras utilizados en los reportes.
                ventaDetalle.DNICliente = Convert.ToInt32(NudDNI.Value);
                ventaDetalle.NombreCliente = TxtNombre.Text;
                ventaDetalle.MontoPago = Convert.ToDecimal(TxtPaga.Text);
                ventaDetalle.MontoTotal = Convert.ToDecimal(TxtTotal.Text);
                ventaDetalle.MontoCambio = Convert.ToDecimal(TxtCambio.Text);
                ventaDetalle.FechaRegistro = TxtFecha.Text;

                unitOfWork.VentaDetalleRepository.Add(ventaDetalle);

                unitOfWork.Save();

            }       

                LimpiarCliente();

                GridVentas.Rows.Clear();

                GridVentas.Refresh();

            if (OptnerIDVenta > 0)
            {
                var result = MessageBox.Show("¿Desea imprimir comproante? ", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    IrAPestañaDetalles();
                }
            }
            MessageBox.Show("Venta Completada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



        }

        private void IrAPestañaDetalles()
        {
            TabVentaDetalle.SelectedIndex = 1;
        }

        private async Task GuardarVenta()
        {
            int OptnerIDVenta = GridVenta1.RowCount + 1;

            Venta venta = new Venta()
            {
                IdCliente = Convert.ToInt32(TxtIdCliente.Text),
                DNICliente = Convert.ToInt32(NudDNI.Value),
                NumeroVenta = OptnerIDVenta.ToString(),
                NombreCliente = TxtNombre.Text,
                MontoPago = Convert.ToDecimal(TxtPaga.Text),
                MontoTotal = Convert.ToDecimal(TxtTotal.Text),
                MontoCambio = Convert.ToDecimal(TxtCambio.Text),
                FechaRegistro = TxtFecha.Text,
            };
            unitOfWork.VentaRepository.Add(venta);
            
            unitOfWork.Save();
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new FrmClienteView())
            {
                var resul = modal.ShowDialog();

                if (resul == DialogResult.OK)
                {
                    TxtNombre.Text = modal._Cliente.Nombre + " " + modal._Cliente.Apellido;
                    NudDNI.Value = modal._Cliente.DNI;
                    TxtIdCliente.Text = modal._Cliente.Id.ToString("0");
                    TxtProducto.Select();
                }
                else
                {
                    TxtNombre.Select();
                }
            }
        }

       
        // terminados los procesos de TabInicio...

        // Incio de procesos de TabVentas
       
        private void GridVenta2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn columna in GridVenta2.Columns)
            {
                if (columna.Name == "IdCliente")
                    columna.Visible = false;
                if (columna.Name == "NumeroVenta")
                    columna.Visible = false ;
                if (columna.Name == "Id")
                    columna.HeaderText = "Venta N°";
                if (columna.Name == "NombreCliente")
                    columna.HeaderText = "Cliente";
                 if (columna.Name == "DNICliente")
                    columna.HeaderText = "DNI";
                 if (columna.Name == "MontoPago")
                    columna.HeaderText = "Pago con $";
                 if (columna.Name == "MontoCambio")
                    columna.HeaderText = "Cambio $";
                 if (columna.Name == "MontoTotal")
                    columna.HeaderText = "Total $";
                 if (columna.Name == "FechaRegistro")
                    columna.HeaderText = "Fecha";

            }
        }

        private void GridVentas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 5)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.eliminarUno.Width;
                var h = Properties.Resources.eliminarUno.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.eliminarUno, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void GridVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridVentas.Columns[e.ColumnIndex].Name == "elimina")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    GridVentas.Rows.RemoveAt(index);
                    CalcularTotal();
                }
            }
        }


        private async void GridVenta2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridVenta2.Rows.Count > 0)
            {
                idVentaSeleccionada = (int)GridVenta2.CurrentRow.Cells[0].Value;
                ventaSeleccionada = (string)GridVenta2.CurrentRow.Cells[3].Value;
                fechaVenta = (string)GridVenta2.CurrentRow.Cells[8].Value;
                LblDetalle.Text = $"Detalles de venta N°: "+idVentaSeleccionada+" del cliente " +ventaSeleccionada+" el dia "+fechaVenta;

                listaVentaDetalles.DataSource = await unitOfWork.VentaDetalleRepository.GetAllAsync(c => c.IdVenta == idVentaSeleccionada);
                GridVentaDetalle.DataSource = listaVentaDetalles;
            }
            BtnImprimirBoleta.Enabled = true;
        }

        private void GridVentaDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn columna in GridVentaDetalle.Columns)
            {
                if (columna.Name == "IdProducto")
                    columna.Visible = false;
                if (columna.Name == "IdVenta")
                    columna.Visible = false;
                if (columna.Name == "NombreCliente")
                    columna.Visible = false;
                if (columna.Name == "MontoPago")
                    columna.Visible = false;
                if (columna.Name == "MontoCambio")
                    columna.Visible = false;
                if (columna.Name == "MontoTotal")
                    columna.Visible = false;
                if (columna.Name == "Id")
                    columna.Visible = false;
                if (columna.Name == "DNICliente")
                    columna.Visible = false;
                if (columna.Name == "PrecioVenta")
                    columna.HeaderText = "Precio $";
                if (columna.Name == "SubTotal")
                    columna.HeaderText = "Total $";
                if (columna.Name == "FechaRegistro")
                    columna.HeaderText = "Fecha";

            }
        }

        private void BtnImprimirBoleta_Click(object sender, EventArgs e)
        {
            if (GridVenta2.Rows.Count > 0)
            {
                FrmBoleta frmBoleta = new FrmBoleta((int)GridVenta2.CurrentRow.Cells[0].Value);
                frmBoleta.ShowDialog();
            }
            else
            {
                MessageBox.Show("No a seleccionado ninguna venta");
            }
            BtnImprimirBoleta.Enabled = false;
        }

        private void BtnVerVentas_Click(object sender, EventArgs e)
        {
            TabVentaDetalle.SelectedIndex = 1;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            TabVentaDetalle.SelectedIndex = 0;
        }
    }
}
