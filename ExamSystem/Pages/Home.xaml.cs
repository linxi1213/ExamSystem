using ExamSystem.WebApi;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
using ExamSystem.WebApi.entities;
using ExamSystem.CustomControl;
using ExamSystem.Pages.ExamPage;

namespace ExamSystem.Pages
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        private Token login_token;
        private UserServer userRequest;
        private List<JToken> users;

        public Home(Token token)
        {
            InitializeComponent();
            login_token = token;
            userRequest = new UserServer(token.login_Token);
            Initialze();
        }
        /// <summary>
        /// 初始权限显示设置
        /// </summary>
        public async void Initialze()
        {
            //foreach(v) 
            //{
            //    item.
            //} 
            string uri = Uris.BaseUrl + Uris.User + "Get";
            var result =await userRequest.GetUserRokes(uri, new entity<long>() { id = int.Parse(login_token.login_Id) });
            foreach(var item in result)
            {
                if(item.Equals("ADMIN"))
                {
                    return;
                }
                else if(item.Equals("EXAMINEES"))
                {
                    listitemsbox.Items.Remove(userItem);
                    listitemsbox.Items.Remove(roleItem);
                    return;
                }  
            }
            //
            listitemsbox.Items.Clear();
        
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            ListBoxItem listBoxItem = sender as ListBoxItem;
           
            string liteName = listBoxItem.Content.ToString();
            foreach (TabItem item in tabControl.Items)
            {
                if (item.Name.Equals(liteName))
                {
                    return;
                }
            }
            CloseTabControl tabItem = new CloseTabControl();
            tabItem.Title = liteName;
            tabItem.Name = liteName;
            Frame frame = new Frame();
            if(liteName.Equals("用户"))
            {
                frame.Content = new Users(login_token);
            }
            else if(liteName.Equals("角色"))
            {
                frame.Content = new Roles(login_token);
            }
            else if(liteName.Equals("考试管理"))
            {
                frame.Content = new ExamPaper(login_token);
            }
            else
            {
                MessageBox.Show(liteName);
                return;
            }
            tabItem.Content = frame;
            tabControl.Items.Add(tabItem);
            tabItem.IsSelected = true;
        }

    }
}
