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

    
    public partial class Actualizar : Form
    {
        private int indice;
        private DataGridView datagridview1;

        public Actualizar(int indice, DataGridView datagridview1)
        {
            InitializeComponent();
            this.indice = indice;
            this.datagridview1 = datagridview1;
        }

        private void Actualizar_Load(object sender, EventArgs e)
        {
            textBox1.Text= datagridview1.Rows[indice].Cells[1].Value.ToString();
            textBox2.Text= datagridview1.Rows[indice].Cells[2].Value.ToString();
            textBox3.Text= datagridview1.Rows[indice].Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ColegioEntities col=new ColegioEntities())
            {
                var id =int.Parse(datagridview1.Rows[indice].Cells[0].Value.ToString());
                Administradores admin = col.Administradores.FirstOrDefault(admin1 => admin1.id.Equals(id));

                admin.nombre = textBox1.Text;
                admin.apellido = textBox2.Text;
                admin.contrasena = textBox3.Text;

                col.SaveChanges();

                IQueryable<Administradores> admin2 = from d in col.Administradores
                                                     select d;

                List<Administradores> listado = admin2.ToList();

                datagridview1.DataSource = listado;
                this.Hide();
                MessageBox.Show("Se guardaron los cambios");
                

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
