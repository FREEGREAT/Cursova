using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Table1.xaml
    /// </summary>
    public partial class Table1 : Page
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=post");
        private MySqlCommand cmd;
        private MySqlDataAdapter da;
        private DataTable table;
        private string select_sql = "select * from client";
        public Table1()
        {
            InitializeComponent();
            select_command(select_sql);
        }
        private void select_command(string sql)
        {
            con.Open();
            cmd = new MySqlCommand(sql, con);
            cmd.Connection = con;
            cmd.CommandText = sql;
            da = new MySqlDataAdapter(cmd);
            table = new DataTable();
            da.Fill(table);
            Data_Grid_clients.ItemsSource = table.DefaultView;
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
