using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tp2_Algoritmos
{
    public partial class Form1 : Form
    {
        // se necesita hacer un sistema de turnos para un cosultorio medico,
        //donde se puede ingresar un turno, y tambien borrar 
        //y que a medida que se valla atendiendo a los pacientes se vallan eliminando los turnos

        public Form1()
        {
            InitializeComponent();
            button3.Enabled = false;

        }
        private Lista Listapacientes = new Lista();
        private List<Turno> turnero = new List<Turno>();
        private void button1_Click(object sender, EventArgs e)
        {
            Listapacientes.NuevoTurno(textBox1.Text);

            turnero = Listapacientes.Retornalista();
            listBox1.Items.Clear();
            
            button2.Enabled = true; button3.Enabled = false;
            foreach (var turno in turnero) {
               listBox1.Items.Add(turno.nombre);
               
                          
            }
            button2.Enabled = true; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listapacientes.BorrarTurno("ultimo");

            turnero = Listapacientes.Retornalista();
            listBox1.Items.Clear();
            
            if (turnero.Count == 0) { button2.Enabled = false; button3.Enabled = false; }

            else
            {
                foreach (var turno in turnero)
                {
                    listBox1.Items.Add(turno.nombre);
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          

            Listapacientes.BorrarTurno(listBox1.SelectedItem.ToString());

            turnero = Listapacientes.Retornalista();
            listBox1.Items.Clear();
            

            if (turnero.Count == 0) { button2.Enabled = false; button3.Enabled = false; }
            else
            {
                foreach (var turno in turnero)
                {
                    listBox1.Items.Add(turno.nombre);
                    
                }
            }
            button3.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 1){
                button3.Enabled = true; }
        
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
