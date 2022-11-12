using System;
using System.Windows;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{

    public partial class insert_item : Window
    {
        public insert_item()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text == string.Empty | LicenseBox.Text == string.Empty | PriceBox.Text == string.Empty)
            {
                MessageBox.Show("Будь ласка, заповніть всі рядки!!!");
            }
            else
            {
                try
                {
                    string ItemName = NameBox.Text;
                    string Price = PriceBox.Text;
                    string License = LicenseBox.Text;
                    con.Open();
                    cmd = new MySqlCommand("Insert into item(Name, Price, License) values(\"" + ItemName + "\",\"" + Price + "\",\"" + License + "\");", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Успішно!");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}