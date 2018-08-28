using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace basededatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string connectionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_connection=True";

                SqlConnection conexion;

                conexion = new SqlConnection(connectionString);

                SqlCommand comando;

                string query = "INSERT INTO Alumnos " +
                    "(no_control, nombre, apaterno, amaterno)" + "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";


                try
                {
                    conexion.Open();

                    comando = new SqlCommand(query, conexion);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Registro Guardado");

                    comando.Dispose();

                    conexion.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                Load_Datagrid();
                Limpiar();
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_connection=True";

            SqlConnection conexion;

            conexion = new SqlConnection(connectionString);

            SqlCommand comando;

            string query = "INSERT INTO Alumnos VALUES (152050, 'Alejandro' , 'Castanon', 'Cardona')";

            try
            {
                conexion.Open();

                comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Guardado");

                comando.Dispose();

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Load_Datagrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string conexionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_connection=True";

            SqlConnection conexion;

            conexion = new SqlConnection(conexionString);

            SqlCommand comando;



            string query = "select * from Alumnos where nombre='" + textBox2.Text + "'";

            try
            {
                conexion.Open();

                comando = new SqlCommand(query, conexion);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataTable dataTable = new DataTable();

                da.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                dataTable.Columns[0].ColumnName = "no_control";
                dataTable.Columns[1].ColumnName = "Nombre";
                dataTable.Columns[2].ColumnName = "A_Paterno";
                dataTable.Columns[3].ColumnName = "A_Materno";


                comando.Dispose();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Limpiar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_connection=True";

            SqlConnection conexion;

            conexion = new SqlConnection(connectionString);

            SqlCommand comando;

            string query = "Delete from Alumnos where nombre='" + textBox2.Text + "'";
            try
            {
                conexion.Open();

                comando = new SqlCommand(query, conexion);

                comando.ExecuteNonQuery();

                MessageBox.Show("Registro Eliminado");

                comando.Dispose();

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Load_Datagrid();
            Limpiar();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Load_Datagrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
        public void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    
        public void Load_Datagrid()
        {
            string conexionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_connection=True";

            SqlConnection conexion;

            conexion = new SqlConnection(conexionString);

            SqlCommand comando;

            string query;

            query = "SELECT * FROM Alumnos";



            try
            {
                conexion.Open();

                comando = new SqlCommand(query, conexion);

                SqlDataAdapter da = new SqlDataAdapter(comando);

                DataTable datatable = new DataTable();

                da.Fill(datatable);

                dataGridView1.DataSource = datatable;

                datatable.Columns[0].ColumnName = "No_Control";
                datatable.Columns[1].ColumnName = "Nombre";
                datatable.Columns[2].ColumnName = "A_Paterno";
                datatable.Columns[3].ColumnName = "A_Materno";

                comando.Dispose();

                conexion.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                Load_Datagrid();
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string conexionString = "Server=localhost\\SQLEXPRESS;Database=Escuela;Trusted_connection=True";

            SqlConnection conexion;

            conexion = new SqlConnection(conexionString);

            SqlCommand comando;

            SqlDataReader dataReader;

            string query = "UPDATE Alumnos set nombre='" + textBox2.Text + "',apaterno='" + textBox3.Text + "',amaterno='" + textBox4.Text + "' where no_control=" + textBox1.Text;
            MessageBox.Show("Registro actualizado");
            string datos = "...";

            try
            {
                conexion.Open();

                comando = new SqlCommand(query, conexion);

                dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    //MessageBox.Show("no_Control " + dataReader.GetValue(0) + " Nombre " + dataReader.GetValue(1));

                    datos += ("no_Control " + dataReader.GetValue(0) + " nombre " + dataReader.GetValue(1) + "\n");
                }

                MessageBox.Show(datos);

                comando.Dispose();

                conexion.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Load_Datagrid();
            Limpiar();
        }
    }
    }
    

