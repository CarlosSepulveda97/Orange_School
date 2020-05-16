using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosSepulveda_OrangeSchool
{
    public partial class Form4 : Form
    {
        public DataGridView data;
        public Form4(DataGridView data)
        {
            InitializeComponent();
            this.data = data;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColegioEntities col = new ColegioEntities())
            {
                Administradores admin = new Administradores
                {
                    nombre = textBox1.Text,
                    apellido = textBox2.Text,
                    contrasena = textBox3.Text,
                };

                col.Administradores.Add(admin);
                col.SaveChanges();
                this.Hide();
                MessageBox.Show("Se ha guardado con exito");
                actualizarTabla();

            }


        }

        private void actualizarTabla()
        {
            using (ColegioEntities col = new ColegioEntities())
            {
                IQueryable<Administradores> admin = from d in col.Administradores
                                                    select d;

                List<Administradores> listado = admin.ToList();

                data.DataSource = listado;
            }

        }
    }
}
