using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;

namespace ClientRest
{
    public class UserDemo
    {
        HttpClient httpClient=new HttpClient();

        public UserDemo()
        {
            httpClient.BaseAddress = new System.Uri("https://localhost:44322/");
        }

        public int id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public List<UserDemo> GetAllUser()
        {
            string informations = httpClient.GetStringAsync("api/users").Result;

            List<UserDemo> userDemos = JsonConvert.DeserializeObject<List<UserDemo>>(informations);
            return userDemos;
        }

        public void ShowAllUsers(DataGridView dtgList)
        {
            List<UserDemo> userDemosList = GetAllUser();


            if (dtgList.Rows.Count >= 0)
            {
                dtgList.Rows.Clear();
                foreach (var user in userDemosList)
                {
                    dtgList.Rows.Add(user.id, user.Nom, user.Prenom);
                }
            }
            else
            {
                foreach (var user in userDemosList)
                {
                    dtgList.Rows.Add(user.id, user.Nom, user.Prenom);
                }
            }
        }

        public UserDemo ShowUserById(int id)
        {
            string informations = httpClient.GetStringAsync("api/users/" + id).Result;
            UserDemo userDemo = JsonConvert.DeserializeObject<UserDemo>(informations);
            return userDemo;
        }

        public async void CreateUser(UserDemo userDemo)
        {
            var reponse = httpClient.PostAsJsonAsync("api/users", userDemo).Result;
        }

        public async void UpdateUser(int id, UserDemo userDemo)
        {
            var response = httpClient.PutAsJsonAsync("api/users/" + id, userDemo).Result;
        }

        public async void DeleteUser(int id)
        {
            var response = httpClient.DeleteAsync("api/users/" + id);
        }
    }
}