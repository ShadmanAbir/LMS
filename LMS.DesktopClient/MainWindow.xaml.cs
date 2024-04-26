using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LMS.Core;
using LMS.Core.ViewModels;
using Newtonsoft.Json;

namespace LMS.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int AuthorID;
        private string Url = "https://localhost:7080/api/";
        public MainWindow()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private void Login_btn_Click_1(object sender, RoutedEventArgs e)
        {
            Login_pan.Visibility = Visibility.Hidden;
            Dashboard_pan.Visibility = Visibility.Visible;
        }

        private void ClearAuthor_btn_Click(object sender, RoutedEventArgs e)
        {
            AuthorID = 0;
            AuthorName_txt.Text = null;
            AuthorBio_txt.Text = null;
        }

        private async void LoadDataAsync()
        {
            try
            {
                // Initialize HttpClient
                using (HttpClient client = new HttpClient())
                {
                    
                    // Send GET request
                    HttpResponseMessage response = await client.GetAsync(Url+"Author");

                    // Check if request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content
                        string data = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON response to a list of objects
                        List<AuthorsViewModel> dataList = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(data);

                        // Bind data to DataGrid
                        Author_dtg.ItemsSource = dataList;
                    }
                    else
                    {
                        MessageBox.Show("Failed to retrieve data from the API.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}