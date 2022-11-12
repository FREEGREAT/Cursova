using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Delete_client.xaml
    /// </summary>
    public partial class Delete_client : Window
    {
        public Delete_client()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Phone = Phonebox.Text;
            try
            {
                con.Open();
                cmd = new MySqlCommand("delete from clients where Phone='" + Phone + "'", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успішно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }
    }
}
