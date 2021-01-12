using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
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

namespace ExamSystem.Pages
{
    /// <summary>
    /// UpdateUserPage.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateUserPage : Page
    {
        private readonly UserServer userRequest;
        private readonly Token token;
        private readonly string ID;

        public UpdateUserPage(Token token,string ID)
        {
            InitializeComponent();
            userRequest = new UserServer(token.login_Token);
            this.token = token;
            this.ID = ID;
            InitializeUser();
        }

        /// <summary>
        /// 初始显示数据
        /// </summary>
        public async void InitializeUser()
        {
            JToken roles = await userRequest.GetRequest(Uris.BaseUrl + Uris.User + "GetRoles");
            JToken result = await userRequest.GetRequest(Uris.BaseUrl + Uris.User + "Get", new entity<long>() { id = long.Parse(ID) });
            userName.Text = result["userName"].ToString();
            name.Text = result["name"].ToString();
            surname.Text = result["surname"].ToString();
            emailAddress.Text = result["emailAddress"].ToString();
            fullname.Text = result["fullName"].ToString();
            if (result["isActive"].ToString().Equals("true"))
                isActive.IsChecked = true;
            else
                isActive.IsChecked = false;
            foreach (var item in roles["items"])
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = item["name"];
           
                foreach (var i in result["roleNames"])
                {
                    if(i.ToString().ToLower().Equals(item["name"].ToString().ToLower()))
                    {
                        checkBox.IsChecked = true;
                    }
                }
                roleNames.Children.Add(checkBox);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            List<string> roles = new List<string>();
            foreach (CheckBox item in roleNames.Children)
            {
                if (item.IsChecked == true)
                {
                    roles.Add(item.Content.ToString());
                }
            }
            UpdateUserRule user = new UpdateUserRule()
            {
                id = ID,
                emailAddress = emailAddress.Text,
                userName = userName.Text,
                name = name.Text,
                surname = surname.Text,
                roleNames = roles.ToArray(),
                fullName = fullname.Text,
                isActive = isActive.IsChecked.ToString()
            };


            var result = await userRequest.UpdateRequest(Uris.BaseUrl + Uris.User +"Update",user);

            if (!result.Equals(HttpStatusCode.OK.ToString()))
            { MessageBox.Show(result); }
            else
            {
                Goback();
            }
        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            Goback();
        }
        
        public void Goback()
       {
            Frame frame = new Frame();
            frame.Content = new Users(token);
            this.Content = frame;
         }
    }
}
