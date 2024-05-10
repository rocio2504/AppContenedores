using System.Data;
using System.Data.SqlClient;

namespace ContenedoresApp
{
    public partial class Form1 : Form
    {

        ConexionBD sqlControl = new ConexionBD();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            // ConexionBD cont = new ConexionBD();

            //  dataGridView1.DataSource = cont.Get();

            DataTable tabla = new DataTable();
            tabla = sqlControl.mostrarContent();
            dataGridView1.DataSource = tabla;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nuevo
            FormNuevo formNuevo = new FormNuevo();
            formNuevo.ShowDialog();
            Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //actualizar

            try
            {
                int? Id = GetId();
                if (Id != null)
                {
                    FormNuevo frmedit = new FormNuevo(Id);
                    frmedit.ShowDialog();
                    Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        #region HELPER
        private int? GetId()
        {
            try
            {
                return int.Parse(
                    // dataGridView1.CurrentRow.Cells["NÚMERO"].Value.ToString());

                dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                 );

            }
            catch (Exception ex)
            {
                MessageBox.Show("es nulo" + ex.Message + dataGridView1.CurrentRow.Cells["NÚMERO"].Value.ToString());
                return null;
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            //eliminar

            try
            {


                int? Id = GetId();
                if (Id != null)
                {
                   

                  if(  MessageBox.Show("¿Desea eliminar el registro?","Atención",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
                    {

                        return;
                    }
                   
                    ConexionBD cn = new ConexionBD();
                    cn.eliminarContenedor((int)Id);
                    //
                    MessageBox.Show("Se eliminó correctamente");
                    Refresh();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al eliminar. "+ex.Message);
            }
        }
    }
}
