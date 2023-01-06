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
using System.Windows.Media.Media3D;

namespace Desktop.Views
{
    public partial class FrmInventario : Form
    {
        IUnitOfWork unitOfWork = new UnitOfWork();
        BindingSource listaProductos = new BindingSource();
        bool editando;
        public FrmInventario()
        {
            InitializeComponent();
            unitOfWork = unitOfWork;
            GetAll();
            gridProductos.DataSource = listaProductos;
        }

        private async void GetAll()
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.Nombre));
        }
        private async void GetAll(string txtBusqueda)
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(filter: c => c.Nombre.Contains(txtBusqueda), orderBy: c => c.OrderBy(c => c.Nombre));
        }


       

        private void LimpiarControles()
        {
            nudId.Value= 0;
            NudPrecio.Value = 0;
            TxtNombre.Text = "";
            TxtCodigo.Text = "codigo";
            TxtMarca.Text = "";
            TxtDetalle.Text = "";
        }

        private void gridProductos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn columna in gridProductos.Columns)
            {
                if (columna.Name == "Nombre")
                    columna.HeaderText = "Producto";
                if (columna.Name == "Id")
                    columna.Width = 40;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            IrAPestañaEditar();
            LimpiarControles();
            editando = false;
        }

        private void IrAPestañaEditar()
        {

            InventarioTab.Enabled = false;

            //cambiar de pestaña
            EditarTab.Enabled = true;
            TabControl.SelectedIndex = 1;
            
        }

        private void IrAPestañaInventario()
        {
            EditarTab.Enabled = false;

            InventarioTab.Enabled = true;
            TabControl.SelectedIndex = 0;
            LimpiarControles();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            IrAPestañaInventario();
        }

       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            RecuperarParaEditar();
            IrAPestañaEditar();
            editando = true;
        }

        private void RecuperarParaEditar()
        {
            var producto = (Producto)listaProductos.Current;

            nudId.Value = producto.Id;
            TxtNombre.Text = producto.Nombre;
            TxtCodigo.Text = producto.Codigo;
            TxtMarca.Text = producto.Marca;
            TxtDetalle.Text = producto.Detalle;
            NudPrecio.Value = producto.Precio;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto()
            {
                Id = (int)nudId.Value,
                Nombre = TxtNombre.Text,
                Marca = TxtMarca.Text,
                Detalle = TxtDetalle.Text,
                Codigo = TxtCodigo.Text,
                Precio = (decimal)NudPrecio.Value
            };
            if (editando)
                unitOfWork.ProductoRepository.Update(producto);
            else
                unitOfWork.ProductoRepository.Add(producto);


            unitOfWork.Save();
            GetAll();
            LimpiarControles();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var producto = (Producto)listaProductos.Current;
            var result = MessageBox.Show($"¿Está seguro que desea Eliminar el Producto {producto.Nombre}?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                unitOfWork.ProductoRepository.Delete(producto.Id);
                unitOfWork.Save();
                GetAll();
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            GetAll(txtBusqueda.Text);
        }
    }
}
