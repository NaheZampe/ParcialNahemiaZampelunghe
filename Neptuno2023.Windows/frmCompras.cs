using Neptuno2023.Entidades.ListDto;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }
        private IServicioCompra _servicio;
        private List<ComprasDto> _lista;
        private void frmCompras_Load(object sender, EventArgs e)
        {
            _servicio = new ServicioCompras();
            try
            {
                _lista = _servicio.GetCompras();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var compra in _lista)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, compra);
                GridHelper.AgregarFila(dgvDatos, r);
            }
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
