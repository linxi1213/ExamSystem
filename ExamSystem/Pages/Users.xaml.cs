using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
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



namespace ExamSystem.Pages
{
    /// <summary>
    /// Users.xaml 的交互逻辑
    /// </summary>
    public partial class Users : Page
    {
        private readonly UserServer userRequest;
        private List<JToken> users;
        private readonly Token token;

        public Users(Token token)
        {
            InitializeComponent();
            userRequest = new UserServer(token.login_Token);
            this.token = token;
            InitializeView();
        }

        /// <summary>
        /// 更新数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Updata_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Frame frame = new Frame();
            frame.Content = new UpdateUserPage(token,button.Tag.ToString());
            this.Content = frame;
        }
        
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();
            frame.Content = new CreateUserPage(token);
            this.Content = frame;
        }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            //MessageBox.Show(button.Tag.ToString());
            if(button.Tag.ToString().Equals(token.login_Id))
            {
                MessageBox.Show("不能删除自己");
                return;
            }
            //MessageBox.Show(button.Tag.ToString());
            if(MessageBox.Show("你是否确实删除此用户", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var result = await userRequest.DeleteRequest(Uris.BaseUrl + Uris.User + "Delete",new entity<long> 
                { 
                    id =long.Parse(button.Tag.ToString())
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

        /// <summary>
        /// Get数据刷新listView
        /// </summary>
        /// <returns></returns>
        public async void InitializeView()
        {
          
            listView.Items.Clear();
            this.users = await userRequest.GetAllRequest(Uris.BaseUrl + Uris.User + "GetAll");
            foreach(var item in this.users)
            {
                var it = new { ID = item["id"],Name = item["name"], CreatTime = item["creationTime"],fullName = item["fullName"] };
                listView.Items.Add(it);
            }
            listView.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
        }

       
            
    }
}
