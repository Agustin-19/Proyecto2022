using Data.Interfaces;
using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Views
{
    public partial class FrmClientes : Form
    {
        IUnitOfWork unitOfWork = new UnitOfWork();
        BindingSource listaLocalidades = new BindingSource();
        BindingSource listaClientes = new BindingSource();
        bool editando;
        public FrmClientes()
        {
            InitializeComponent();
            this.unitOfWork = unitOfWork;
            //CargarComboLocalidades();
            
            GetAllClientes();
            gridClientes.DataSource = listaClientes;


            
        }



        private async void GetAllClientes()
        {
            listaClientes.DataSource = await unitOfWork.ClienteRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.Nombre));
        }
        private async void GetAllClientes(string txtBusqueda)
        {
            listaClientes.DataSource = await unitOfWork.ClienteRepository.GetAllAsync(filter: c => c.Nombre.Contains(txtBusqueda), orderBy: c => c.OrderBy(c => c.Nombre));
        }
        private async void CargarComboLocalidades()
        {
            //listaLocalidades.DataSource = await unitOfWork.LocalidadRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.NombreLocalidad));

            //comboBoxLocalidades.DataSource = listaLocalidades;
            //comboBoxLocalidades.DisplayMember = "NombreLocalidad";
            //comboBoxLocalidades.ValueMember = "Id";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarImputs();
            Close();
        }

        private void LimpiarImputs()
        {
            TxtNombre.Text = "";
            TxtApellido.Text = string.Empty;
            TxtDireccion.Text = string.Empty;
            TxtDni.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
            comboBoxLocalidades.SelectedValue = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente()
            {
                Id = (int)nudId.Value,
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                DNI = Convert.ToInt32(TxtDni.Text),
                Email = TxtEmail.Text,
                Telefono = TxtTelefono.Text,
                Dirección = TxtDireccion.Text,
                //LocalidadId = (int)comboBoxLocalidades.SelectedValue,
                //Localidad = comboBoxLocalidades.Text,


            };
            if (editando)
                unitOfWork.ClienteRepository.Update(cliente);
            else
                unitOfWork.ClienteRepository.Add(cliente);


            unitOfWork.Save();
            GetAllClientes();
            LimpiarImputs();
        }

        private void gridClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn columna in gridClientes.Columns)
            {
                if (columna.Name == "NombreCompleto")
                    columna.Visible = false;
                if (columna.Name == "LocalidadId")
                    columna.Visible = false;
                if (columna.Name == "Localidad")
                    columna.Visible = false;
                //if (columna.Name == "Id")
                //    columna.Width = 30;
            }
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            GetAllClientes(txtBusqueda.Text);
        }

        private void TxtEditar_Click(object sender, EventArgs e)
        {
            RecuperarParaEditar();
            IrAPestañaEditar();
            editando = true;
        }

        private void IrAPestañaEditar()
        {
            //cambiar de pestaña
            TabEditarClientes.Enabled = true;
            TabClientes.SelectedIndex = 0;
        }

        private void RecuperarParaEditar()
        {
            var cliente = (Cliente)listaClientes.Current;

            nudId.Value = cliente.Id;
            TxtNombre.Text = cliente.Nombre;
            TxtApellido.Text = cliente.Apellido;
            TxtDni.Text = cliente.DNI.ToString();
            TxtEmail.Text = cliente.Email;
            TxtTelefono.Text = cliente.Telefono;
            TxtDireccion.Text = cliente.Dirección;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            var cliente = (Cliente)listaClientes.Current;
            var result = MessageBox.Show($"¿Está seguro que desea Eliminar a {cliente.NombreCompleto}?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                unitOfWork.ClienteRepository.Delete(cliente.Id);
                unitOfWork.Save();
                GetAllClientes();
            }
        }
    }
}
