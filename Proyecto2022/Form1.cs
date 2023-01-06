using Data.Interfaces;
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

namespace Data
{
    public partial class Form1 : Form
    {
        IUnitOfWork unitOfWork = new UnitOfWork();
        BindingSource listaProductos = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            GetAll();
        }

        private async void GetAll()
        {
            listaProductos.DataSource = await unitOfWork.ProductoRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.Nombre));
        }
    }
}
