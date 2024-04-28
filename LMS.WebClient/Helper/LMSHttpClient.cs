using LMS.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LMS.WebClient.Helper
{
    public class LMSHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string api_Url = "https://localhost:7080/api/"; //API URL goes Here

        public LMSHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        //Author API START

        public async Task<List<AuthorsViewModel>> GetAuthors()
        {

            var response = await _httpClient.GetAsync(api_Url+"Author");
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var AuthorList = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(responseData);

            return AuthorList;
        }

        public async Task<AuthorsViewModel> GetAuthorByID(int ID)
        {

            var response = await _httpClient.GetAsync(api_Url + "Author" +"/"+ ID);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var Author = JsonConvert.DeserializeObject<AuthorsViewModel>(responseData);

            return Author;
        }

        public async Task<string> PostAuthorAsync(AuthorsViewModel authorVM)
        {
            var jsonData = JsonConvert.SerializeObject(authorVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(api_Url + "Author", content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> PuttAuthorAsync(AuthorsViewModel authorVM)
        {
            var jsonData = JsonConvert.SerializeObject(authorVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(api_Url + "Author", content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> DeleteAuthorAsync(int ID)
        {

            var response = await _httpClient.DeleteAsync(api_Url + "Author" + "/" + ID);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        //Author API START

        //Book API START

        public async Task<List<AuthorsViewModel>> GetBooks()
        {

            var response = await _httpClient.GetAsync(api_Url + "Book");
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var AuthorList = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(responseData);

            return AuthorList;
        }

        public async Task<AuthorsViewModel> GetBookByID(int ID)
        {

            var response = await _httpClient.GetAsync(api_Url + "Book" + "/" + ID);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var Author = JsonConvert.DeserializeObject<AuthorsViewModel>(responseData);

            return Author;
        }

        public async Task<string> PostBookAsync(AuthorsViewModel authorVM)
        {
            var jsonData = JsonConvert.SerializeObject(authorVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(api_Url + "Book", content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> PuttBookAsync(AuthorsViewModel authorVM)
        {
            var jsonData = JsonConvert.SerializeObject(authorVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(api_Url + "Book", content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> DeleteBookAsync(int ID)
        {

            var response = await _httpClient.DeleteAsync(api_Url + "Book" + "/" + ID);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        //Book API END

        //Member API START

        public async Task<List<AuthorsViewModel>> GetMembers()
        {

            var response = await _httpClient.GetAsync(api_Url + "Member");
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var AuthorList = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(responseData);

            return AuthorList;
        }

        public async Task<AuthorsViewModel> GetMemberByID(int ID)
        {

            var response = await _httpClient.GetAsync(api_Url + "Member" + "/" + ID);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            var Author = JsonConvert.DeserializeObject<AuthorsViewModel>(responseData);

            return Author;
        }

        public async Task<string> PostMemberAsync(AuthorsViewModel authorVM)
        {
            var jsonData = JsonConvert.SerializeObject(authorVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(api_Url + "Member", content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> PuttMemberAsync(AuthorsViewModel authorVM)
        {
            var jsonData = JsonConvert.SerializeObject(authorVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(api_Url + "Member", content);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        public async Task<string> DeleteMemberAsync(int ID)
        {

            var response = await _httpClient.DeleteAsync(api_Url + "Member" + "/" + ID);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return responseData;
        }

        //Member API END
    }
}