using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Realization_ADD.xaml
    /// </summary>
    public partial class Realization_ADD : Window
    {
        public Realization_ADD()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PhoneBox.Text == string.Empty | ItemIDBox.Text == string.Empty | PriceBox.Text == string.Empty | EmailBox.Text == string.Empty)
            {
                MessageBox.Show("Будь ласка, заповніть всі рядки!!!");
            }
            else
            {
                try
                {
                    string Phone = PhoneBox.Text;
                    string Price = PriceBox.Text;
                    string Email = EmailBox.Text;
                    string ID = ItemIDBox.Text;
                    con.Open();
                    cmd = new MySqlCommand("Insert into realization(Item_ID, Phone_num, Price, Email) values(\"" + ID + "\",\"" + Phone + "\",\"" + Price + "\",\""+ Email +"\");", con);
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
