using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp1
{

    public partial class Realization : Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=store");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable table;
        public Realization()
        {
            InitializeComponent();
            select_data();
        }

        public void select_data()
        {
            //команда для виводу записів з таблиці
            string select_sql = "select * from realization";

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
            //insert click відкриває вікно в якому ми додаємо запис в таблицю
            Realization_ADD radd = new Realization_ADD();
            radd.Show();
        }
        private void DELETE_Click(object sender, RoutedEventArgs e)
        {
            Realization_Delete delete = new Realization_Delete();
            delete.Show();
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //подія , яка оновляє таблицю
            select_data();
        }

        private void Update_Click_1(object sender, RoutedEventArgs e)
        {
            //update click, відкриває вікно в якому ми можемо оновити запис в таблиці 
            Realization_Update qwind = new Realization_Update();
            qwind.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //повернення до вибору таблиці
            NavigationService.GoBack();
        }
        private void search_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string select_sql = "select * from realization where ID ='" + searchBOX.Text + "' or Item_ID=" + searchBOX.Text + " or Phone_num like '%" + searchBOX.Text + "%'or Price = " + searchBOX.Text + " or Email like '%" + searchBOX.Text + "%';";
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
                con.Close();
            }
        }


    }
}




