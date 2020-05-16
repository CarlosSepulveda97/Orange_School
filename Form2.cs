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
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
        }



        //Metodo para abrir formulario en el panel contenedor
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
                Form fh = Formhijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panel3.Controls.Add(fh);
                this.panel3.Tag = fh;
                fh.Show();
                pictureBox2.Visible = false;
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();//ME permite cerrar la app
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Form3());
        }
    }
}
