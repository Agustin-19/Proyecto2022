using FontAwesome.Sharp;
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
    public partial class FrmPaginaPrincipal : Form
    {
        public static Form FormularioActivo = null;
        public static IconMenuItem MenuActivo = null;


        public FrmPaginaPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.DarkOrange;
            }
            menu.BackColor = Color.LightCoral;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.DarkOrange;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }
        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmInicio());
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmInventario());
        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmClientes());
        }
    }
}
