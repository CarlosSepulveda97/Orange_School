using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarlosSepulveda_OrangeSchool
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 ventanaAgregar = new Form4();
            ventanaAgregar.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using(ColegioEntities col= new ColegioEntities())
            {
                IQueryable<Administradores> admin = from d in col.Administradores
                                                    select d;

                List<Administradores> listado = admin.ToList();

                dataGridView1.DataSource = listado;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Actualizar

        }
    }
}
