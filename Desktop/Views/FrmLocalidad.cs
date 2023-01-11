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
    public partial class FrmLocalidad : Form
    {
        IUnitOfWork unitOfWork = new UnitOfWork();
        BindingSource listaLocalidades = new BindingSource();
        public FrmLocalidad()
        {
            InitializeComponent();
            unitOfWork = unitOfWork;
            GetAllLocalidades();
            gridLocalidades.DataSource = listaLocalidades;
        }

        private async void GetAllLocalidades()
        {
            listaLocalidades.DataSource = await unitOfWork.LocalidadRepository.GetAllAsync(orderBy: c => c.OrderBy(c => c.NombreLocalidad));
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Localidad localidad = new Localidad()
            {
                NombreLocalidad = txtAgregar.Text,              
            };
             unitOfWork.LocalidadRepository.Add(localidad);


            unitOfWork.Save();
            GetAllLocalidades();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
