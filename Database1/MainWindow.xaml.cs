using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Database1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Data.OleDb.OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            cn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\Database.accdb");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select EmployeeID from Assets";
            string query1 = "select AssetID from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            OleDbCommand cmd1 = new OleDbCommand(query1, cn);

            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();
            OleDbDataReader read1 = cmd1.ExecuteReader();
            string data = "";
            string data1 = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\n";
                DatabaseText.Text = data;

                data1 += read1[0].ToString() + "\n";
                DatabaseText.Text = data1;
            }

            cn.Close();
        }
    }
}
