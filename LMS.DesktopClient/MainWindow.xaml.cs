using System.Data;
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
using LMS.Domain.Models;
using Newtonsoft.Json;

namespace LMS.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _authorID = 0;
        private int _bookID = 0;
        private int _memberID = 0;
        private string Url = "https://localhost:7080/api/";
        public MainWindow()
        {
            InitializeComponent();
            LoadAuthorDataAsync();
            LoadBookDataAsync();
            LoadMemberDataAsync();
        }

        private void Login_btn_Click_1(object sender, RoutedEventArgs e)
        {
            Login_pan.Visibility = Visibility.Hidden;
            Dashboard_pan.Visibility = Visibility.Visible;
        }

        private void ClearAuthor_btn_Click(object sender, RoutedEventArgs e)
        {
            _authorID = 0;
            AuthorName_txt.Text = null;
            AuthorBio_txt.Text = null;
        }

        private async void LoadAuthorDataAsync()
        {
            try
            {
                // Initialize HttpClient
                using (HttpClient client = new HttpClient())
                {
                    
                    HttpResponseMessage response = await client.GetAsync(Url+"Author");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        List<AuthorsViewModel> dataList = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(data);
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
        private async void LoadBookDataAsync()
        {
            try
            {
                // Initialize HttpClient
                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync(Url + "Book");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        List<BooksViewModel> dataList = JsonConvert.DeserializeObject<List<BooksViewModel>>(data);
                        Book_dtg.ItemsSource = dataList;
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
        private async void LoadMemberDataAsync()
        {
            try
            {
                // Initialize HttpClient
                using (HttpClient client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync(Url + "Member");

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        List<MembersViewModel> dataList = JsonConvert.DeserializeObject<List<MembersViewModel>>(data);
                        Member_dtg.ItemsSource = dataList;
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

        private void UpdateAuthor_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Author_dtg.SelectedItem != null)
            {
                var selectedValue = (AuthorsViewModel)Author_dtg.SelectedItem;
                AuthorName_txt.Text = selectedValue.AuthorName;
                AuthorBio_txt.Text = selectedValue.AuthorBio;
                _authorID = selectedValue.AuthorID;
            }
            else
            {
                MessageBox.Show("Please select an item first.");
            }
        }

        private void UpdateBook_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Book_dtg.SelectedItem != null)
            {
                var selectedValue = (BooksViewModel)Book_dtg.SelectedItem;
                BookTitle_txt.Text = selectedValue.Title;
                BookISBN_txt.Text = selectedValue.ISBN;
                BookPublishDate_dp.SelectedDate = selectedValue.PublishedDate;
                BookAuthor_cb.SelectedItem = selectedValue;
                _bookID = selectedValue.BookID;
            }
            else
            {
                MessageBox.Show("Please select an item first.");
            }
        }

        private void UpdateMember_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Member_dtg.SelectedItem != null)
            {
                var selectedValue = (MembersViewModel)Member_dtg.SelectedItem;
                MemberFirstName_txt.Text = selectedValue.FirstName;
                MemberLastName_txt.Text = selectedValue.LastName;
                MemberEmail_txt.Text = selectedValue.Email;
                MemberPhone_txt.Text = selectedValue.PhoneNumber;
                _memberID = selectedValue.MemberID;
            }
            else
            {
                MessageBox.Show("Please select an item first.");
            }
        }

        private void DeleteAuthor_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void SaveAuthor_btn_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var Authordata = new AuthorsViewModel
                    {
                        AuthorID = _authorID,
                        AuthorName = AuthorName_txt.Text,
                        AuthorBio = AuthorBio_txt.Text
                    };

                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(Authordata);

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");


                    if (_authorID == 0)
                    {
                        HttpResponseMessage response = await client.PostAsync(Url + "Author", content);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("PUT request successful");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to send PUT request. Status Code: {response.StatusCode}");
                        }
                    }
                    else
                    {
                        HttpResponseMessage response = await client.PutAsync(Url + "Author", content);

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("PUT request successful");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to send PUT request. Status Code: {response.StatusCode}");
                        }
                    }
                    _authorID = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}