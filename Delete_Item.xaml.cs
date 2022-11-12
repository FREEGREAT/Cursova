using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApp1
{

    public partial class Delete_Item : Window
    {
        public Delete_Item()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string ID = IDbox.Text;
            try
            {
                con.Open();
                cmd = new MySqlCommand("delete from item where ID='"+ ID +"'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успішно!");

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
