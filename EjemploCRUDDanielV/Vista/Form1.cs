using RestSharp;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo form = new Nuevo();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                cargarProductos();
            }
        }

        private async void cargarProductos()
        {
            RestClient cliente = new RestClient();
            RestRequest peticion = new RestRequest("https://67db76a51fd9e43fe4749f9c.mockapi.io/api/v1/Productos", Method.Get);
            var res = await cliente.ExecuteGetAsync(peticion);

            List<Productos> lista = (List<Productos>)JsonConvert.DeserializeObject(res.Content, typeof(List<Productos>));

            dgvProductos.DataSource = lista;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int fila = dgvProductos.CurrentRow.Index;
            int id = int.Parse(dgvProductos.Rows[fila].Cells[0].Value.ToString());
            // MessageBox.Show(id.ToString());

            RestClient cliente = new RestClient();
            RestRequest peticion = new RestRequest("https://67db76a51fd9e43fe4749f9c.mockapi.io/api/v1/Productos/" + id, Method.Delete);
            var res = await cliente.ExecuteDeleteAsync(peticion);

            if (res.StatusCode == System.Net.HttpStatusCode.OK) {
                MessageBox.Show("Producto eliminado");
                cargarProductos();
            } else {
                MessageBox.Show("Error al eliminar");
                cargarProductos();
            }
        }
    }
}
