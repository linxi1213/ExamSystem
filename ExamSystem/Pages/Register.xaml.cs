using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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


namespace ExamSystem
{
    /// <summary>
    /// Register.xaml 的交互逻辑
    /// </summary>
    public partial class Register : Page
    {
        private string baseUrl = "http://localhost:21021";
        public class CreateUser
        {
            
        }


        public Register()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var client =new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));

                var uri = baseUrl + "/api/services/app/User/Create";

                CreateUser createUser = new CreateUser();

                var js = JsonConvert.SerializeObject(createUser);              

                MessageBox.Show(js);

                var input = new StringContent(js);
                input.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json") { CharSet="utf-8"};
                var result =await client.PostAsync(uri,input);

                MessageBox.Show(result.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Login();
    
            

        }
    }
}
