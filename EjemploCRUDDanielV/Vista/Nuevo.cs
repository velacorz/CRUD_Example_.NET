using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RestSharp;

namespace Vista
{
    public partial class Nuevo : Form
    {
        public Nuevo()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Productos pro = new Productos();

            pro.Nombre = txtNombre.Text;
            pro.Descripcion = txtDescripcion.Text;
            pro.Precio = Convert.ToDouble(txtPrecio.Text);
            pro.Fecha = txtFecha.Value;

            RestClient cliente = new RestClient();
            RestRequest peticion = new RestRequest("https://67db76a51fd9e43fe4749f9c.mockapi.io/api/v1/Productos", Method.Post);
            peticion.AddJsonBody(pro);

            var res = await cliente.ExecutePostAsync(peticion);

            if (res.StatusCode == System.Net.HttpStatusCode.Created)
            {
                MessageBox.Show("Producto creado");
                this.DialogResult = DialogResult.OK;
            } else {
                MessageBox.Show("Error al crear");
            }

        }
    }
}
