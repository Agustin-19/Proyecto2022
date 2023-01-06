using Data.Interfaces;
using Data.Models;
using Data.Repositories;
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
    public partial class FrmClienteView : Form
    {
        IUnitOfWork unitOfWork = new UnitOfWork();
        BindingSource listaClientes = new BindingSource();

        public Cliente _Cliente { get; set; }

        public FrmClienteView()
        {
            InitializeComponent();
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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            GetAllClientes(txtBusqueda.Text);
        }

        private void gridClientes_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;
            if (iRow >= 0 && iColum >= 0)
            {
                _Cliente = new Cliente()
                {
                    Nombre = gridClientes.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Apellido = gridClientes.Rows[iRow].Cells["Apellido"].Value.ToString(),
                    DNI = Convert.ToInt32(gridClientes.CurrentRow.Cells["DNI"].Value),
                    Id = Convert.ToInt32(gridClientes.CurrentRow.Cells["Id"].Value)
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
               if (columna.Name == "Telefono")
                    columna.Visible = false;
               if (columna.Name == "Email")
                    columna.Visible = false;
               if (columna.Name == "Dirección")
                    columna.Visible = false;
                //if (columna.Name == "Id")
                //    columna.Width = 30;
            }
        }
    }
}
