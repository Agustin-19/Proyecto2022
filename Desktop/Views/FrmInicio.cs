using Data.Interfaces;
using Data.Models;
using Data.Repositories;
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
        public FrmInicio()
        {
            InitializeComponent();
            GetAll();
            gridProductos.DataSource = listaProductos;
            GridVenta1.DataSource = listaVentas;
        }

        private async void GetAll()
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.Nombre));
            listaVentas.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.Nombre));
        }

        private async void GetAll(string txtBusqueda)
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(filter: c => c.Nombre.Contains(txtBusqueda), orderBy: c => c.OrderBy(c => c.Nombre));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            GetAll(txtBusqueda.Text);
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
            GuardarVenta();
        
            

            //optengo el Ultimo Id generado en la tabla "Ventas"
            //para luego utilizarlo en la tabla "DetalleDeVentas"

            int OptnerIDVenta = GridVenta1.RowCount + 1;
            GetAll();

            //el foreach recorre el DataGridView para optener los datos de los productos.
            foreach (DataGridViewRow row in GridVentas.Rows)
            {
                // se guardan los datos optenidos en la tabla "VentaDetalle"
                VentaDetalle ventaDetalle = new VentaDetalle()
                {
                    IdVenta = OptnerIDVenta,
                    IdProducto = Convert.ToInt32(row.Cells["IdProducto"].Value),
                    Producto = Convert.ToString(row.Cells["Producto"].Value),
                    PrecioVenta = Convert.ToDecimal(row.Cells["PrecioVenta"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value),
                    SubTotal = Convert.ToDecimal(row.Cells["SubTotal"].Value),
                    //datos extras utilizados en los reportes.
                    DNICliente = Convert.ToInt32(NudDNI.Value),
                    NombreCliente = TxtNombre.Text,
                    MontoPago = Convert.ToDecimal(TxtPaga.Text),
                    MontoTotal = Convert.ToDecimal(TxtTotal.Text),
                    MontoCambio = Convert.ToDecimal(TxtCambio.Text),
                    FechaRegistro = Convert.ToDateTime(TxtFecha.Text),
                    
                }; 
                unitOfWork.VentaDetalleRepository.Add(ventaDetalle);

                unitOfWork.Save();

                //limpiamos la pantalla 
                LimpiarCliente();

                GridVentas.Rows.Clear();

                GridVentas.Refresh();

                //if (OptnerIDVenta > 0)
                //{
                //    var result = MessageBox.Show("¿Desea imprimir comproante? ", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                //    if (result == DialogResult.Yes)
                //    {
                //        FrmVerVentas frmVerVentas = new FrmVerVentas();
                //        frmVerVentas.ShowDialog();
                //    }
                //}
                //MessageBox.Show("Venta Completada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

       

        private async void GuardarVenta()
        {
            Venta venta = new Venta()
            {
                IdCliente = Convert.ToInt32(TxtIdCliente.Text),
                DNICliente = Convert.ToInt32(NudDNI.Value),
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
    }
}
