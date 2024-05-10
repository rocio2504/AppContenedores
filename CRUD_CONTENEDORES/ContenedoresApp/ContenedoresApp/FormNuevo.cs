using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContenedoresApp
{
    public partial class FormNuevo : Form
    {
        ConexionBD sqlControl = new ConexionBD();

        private int? Id;


        public FormNuevo(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if (this.Id != null)
            {

                cargarDatos();
            }
        }

        private void cargarDatos()
        {
            DataTable tabla = new DataTable();
            tabla = sqlControl.loadData(Id);
            //comboBox1.DataSource = tabla;
            textBox1.Text = tabla.Rows[0][0].ToString();
            comboBox1.Text = tabla.Rows[0][1].ToString();
            comboBox2.Text = tabla.Rows[0][2].ToString();
            textBox2.Text = tabla.Rows[0][3].ToString();
            textBox3.Text = tabla.Rows[0][4].ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //GUARDAR
            // borrarMensajeError();

            if (Id == null)
            {
                if (verificarCampos())
                {
                    try
                    {


                        string r = sqlControl.GuardarContenedor(int.Parse(textBox1.Text), comboBox1.Text, int.Parse(comboBox2.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));

                        MessageBox.Show("Se guardó correctamente");

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Ocurrió un error al guardar: " + exc.Message);
                    }
                    //  MessageBox.Show(r);
                }

                this.Close();

            }
            else
            {
                if (verificarCampos())
                {
                    try
                    {


                        string r = sqlControl.editarContenedor(int.Parse(textBox1.Text), comboBox1.Text, int.Parse(comboBox2.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));

                        MessageBox.Show("Se actualizó correctamente");

                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Ocurrió un error al actualizar: " + exc.Message);
                    }
                    //  MessageBox.Show(r);
                }

                this.Close();



            }


        }

        private bool verificarCampos()
        {
            bool ok = true;
            if (textBox1.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox1, "Ingresar Número");
            }
            if (comboBox1.Text == "")
            {
                ok = false;
                erMessage.SetError(comboBox1, "Ingresar Tipo");
            }
            if (comboBox2.Text == "")
            {
                ok = false;
                erMessage.SetError(comboBox2, "Ingresar Tamaño");
            }

            if (textBox2.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox2, "Ingresar Peso");
            }

            if (textBox3.Text == "")
            {
                ok = false;
                erMessage.SetError(textBox3, "Ingresar Tara");
            }


            return ok;

        }
        private void FormNuevo_Load(object sender, EventArgs e)
        {
            //cargar combo tipo
            cargarComboTipo();
            //cargar combo tamaño
            cargarComboTamanio();
        }

        private void cargarComboTipo()
        {

            DataTable tabla = new DataTable();
            tabla = sqlControl.cargarComboTipo();
            //tabla.Add
            comboBox1.DataSource = tabla;
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "IdTipo";
        }
        private void cargarComboTamanio()
        {

            DataTable tabla = new DataTable();
            tabla = sqlControl.cargarComboTamanio();
            comboBox2.DataSource = tabla;
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "IdTamanio";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
