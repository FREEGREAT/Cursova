using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using System.Data;
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable table;
        public Client()
        {
            //при відкритті вікна відбувається ініціалізація компонентів, та вивід записів в таблицю
            InitializeComponent();
            select_data();
        }

        public void select_data()
        {
            //команда для виводу записів з таблиці
            string select_sql = "select * from clients";

            cmd = new MySqlCommand(select_sql, con);
            cmd.Connection = con;
            cmd.CommandText = select_sql;
            da = new MySqlDataAdapter(cmd);
            table = new DataTable();
            da.Fill(table);
            Data_Grid_clients.ItemsSource = table.DefaultView;
            con.Close();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Client cli = new Add_Client();
            cli.Show();

        }

        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            Delete_client dlt = new Delete_client();
            dlt.Show();
        }

        private void Update_Click_1(object sender, RoutedEventArgs e)
        {
            Client_Update upd = new Client_Update();
            upd.Show();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            select_data();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string select_sql = "select * from clients where Phone like '%" + searchBOX.Text + "%' or First_n like '%" + searchBOX.Text + "%' or Second_n like '%" + searchBOX.Text + "%'  or Email like '%" + searchBOX.Text + "%' or Card like '%" + searchBOX.Text + "%';";
                cmd = new MySqlCommand(select_sql, con);
                cmd.Connection = con;
                cmd.CommandText = select_sql;
                da = new MySqlDataAdapter(cmd);
                table = new DataTable();
                da.Fill(table);
                Data_Grid_clients.ItemsSource = table.DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
