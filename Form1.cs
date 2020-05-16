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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Arastrar formulario---------------

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //----------------------------------





        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();//ME permite cerrar la app
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void button1_Click(object sender, EventArgs e)//Boton registrar
        {

        }




        private void button2_Click(object sender, EventArgs e)//Boton iniciar sesion
        {
            using(ColegioEntities col= new ColegioEntities())
            {
                var admin = from d in col.Administradores
                            where d.nombre == textBox1.Text &&
                            d.contrasena == textBox2.Text
                            select d;

                if (admin.Count() > 0)
                {
                    this.Hide();
                    Form2 menu = new Form2();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas");
                }

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
