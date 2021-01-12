using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Roles.xaml 的交互逻辑
    /// </summary>
    public partial class Roles : Page
    {
        private readonly RoleServer roleServer;
        private List<JToken> roles;
        private readonly Token token;

        public Roles(Token token)
        {
            InitializeComponent();
            roleServer = new RoleServer(token.login_Token);
            this.token = token;
            InitializeView();
        }

        /// <summary>
        /// Get数据刷新listView
        /// </summary>
        /// <returns></returns>
        public async void InitializeView()
        {

            listView.Items.Clear();
            this.roles = await roleServer.GetAllRequest(Uris.BaseUrl + Uris.Role + "GetAll");
            foreach (var item in this.roles)
            {
                var it = new { ID = item["id"], Name = item["name"] };
                listView.Items.Add(it);
            }
            listView.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            //MessageBox.Show(button.Tag.ToString());
            if (button.Tag.ToString().Equals("1"))
            {
                MessageBox.Show("改角色不允许删除");
                return;
            }
            //MessageBox.Show(button.Tag.ToString());
            if (MessageBox.Show("你是否确实删除此用户", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var result = await roleServer.DeleteRequest(Uris.BaseUrl + Uris.Role + "Delete", new entity<long>
                {
                    id = long.Parse(button.Tag.ToString())
                });
                if (result.Equals(HttpStatusCode.OK.ToString()))
                {
                    InitializeView();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void Updata_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Frame frame = new Frame();
            frame.Content = new RolePage(token, button.Tag.ToString(),"Update");
            this.Content = frame;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            button.Tag = "0";
            Frame frame = new Frame();
            frame.Content = new RolePage(token, button.Tag.ToString(), "Create");
            this.Content = frame;
        }
    }
}
