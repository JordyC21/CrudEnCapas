using CapaNegocio;
namespace CapaPresentacionn
{
    public partial class Form1 : Form
    {
        
        CN_productos objetoCN = new CN_productos();
        private string idproducto = null;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            MostrarProd();

        }

        private void MostrarProd()
        {
            CN_productos objetoCN = new CN_productos();
            dataGridView1.DataSource = objetoCN.MostrarProd();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProd(textNom.Text, textDes.Text, textPrec.Text, textCant.Text, textEsta.Text);
                    MessageBox.Show("Se inserto correctamente");
                    MostrarProd();
                    Limpiar();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar por ", ex.Message);
                }

            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProd(textNom.Text, textDes.Text, textPrec.Text, textCant.Text, textEsta.Text, idproducto);
                    MessageBox.Show("Se editó correctamente");
                    MostrarProd();
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar por "+ ex);
                }
            }
        
           
         

        }

        //BtnEditar
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                textNom.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                textDes.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                textPrec.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                textCant.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                textEsta.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                idproducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();

            }
            else
                MessageBox.Show("Seleccione una fila por favor :) "); 
        }


        //ELIMINAR
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idproducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProd(idproducto);
                MessageBox.Show("Eliminado correctamante");
                MostrarProd();
                
            }
            else
                MessageBox.Show("Seleccione la fila a eliminar");
        }

        private void Limpiar()
        {
            textNom.Clear();
            textDes.Clear();
            textPrec.Clear();
            textCant.Clear();
            textEsta.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}