using System;
using System.Data;
using Npgsql;

namespace project_alif
{
    public partial class Form1 : Form
    {
        private string connection = "Server=localhost; Port=5432; User Id=postgres; Password=12345678; Database=postgres";
        private NpgsqlConnection connect;
        private string postgresql;
        private NpgsqlCommand command;
        private DataTable table;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect = new NpgsqlConnection(connection);
            Reading();
        }

        private void Reading()
        {
            try
            {
                connect.Open();
                postgresql = @"select laptop_aura.nama_lepi, laptop_aura.harga_lepi, laptop_aura.stok_lepi, nama_pembeli_etty.nama_pembeli, detail_transaksi.laptop_dibeli, detail_transaksi.stok_dibeli from laptop_aura join detail_transaksi on laptop_aura.nama_lepi = detail_transaksi.laptop_dibeli join nama_pembeli_etty ON detail_transaksi.id_detail = nama_pembeli_etty.id_pembeli";
                command = new NpgsqlCommand(postgresql, connect);
                table = new DataTable();
                table.Load(command.ExecuteReader());
                connect.Close();
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                connect.Close();
                MessageBox.Show("Error nih: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            postgresql = @"select laptop_aura.nama_lepi, laptop_aura.harga_lepi, laptop_aura.stok_lepi, nama_pembeli_etty.nama_pembeli, detail_transaksi.laptop_dibeli, detail_transaksi.stok_dibeli from laptop_aura join detail_transaksi on laptop_aura.nama_lepi = detail_transaksi.laptop_dibeli join nama_pembeli_etty ON detail_transaksi.id_detail = nama_pembeli_etty.id_pembeli";
            command = new NpgsqlCommand(postgresql, connect);
            table = new DataTable();
            table.Load(command.ExecuteReader());
            connect.Close();
            dataGridView1.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            string create1 = @"insert into laptop_aura (id_lepi, nama_lepi, harga_lepi, stok_lepi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command = new NpgsqlCommand(create1, connect);
            command.ExecuteNonQuery();
            MessageBox.Show("Data diinput!");
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            string create_transaksi = @"insert into detail_transaksi (id_detail, laptop_dibeli, stok_dibeli) values ('" + textBox10.Text + "','" + textBox9.Text + "','" + textBox6.Text + "')";
            command = new NpgsqlCommand(create_transaksi, connect);
            command.ExecuteNonQuery();
            MessageBox.Show("Data diinput!");
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            string create_nama = @"insert into nama_pembeli_etty (id_pembeli, nama_pembeli) values ('" + textBox8.Text + "','" + textBox7.Text + "')";
            command = new NpgsqlCommand(create_nama, connect);
            command.ExecuteNonQuery();
            MessageBox.Show("Data diinput!");
            connect.Close();
        }
    }
}