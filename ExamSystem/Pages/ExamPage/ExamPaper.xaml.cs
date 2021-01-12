using ExamSystem.WebApi;
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
using ExamSystem.WebApi.Server;
using ExamSystem.WebApi.entities.TestPapers;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using ExamSystem.WebApi.entities;
using System.Net;

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// ExamPaper.xaml 的交互逻辑
    /// </summary>
    public partial class ExamPaper : Page
    {
        private readonly TestpaperServer testpaperServer;
        private Token token;
        private List<JToken> testpapers;

        public ExamPaper(Token token)
        {
            InitializeComponent();
            this.token = token;
            testpaperServer = new TestpaperServer(token.login_Token);
            Initialize();
        }

        private async void Initialize()
        {
            listView.Items.Clear();
           // if (testpapers == null)
            //{ 
                this.testpapers = await testpaperServer.GetAllRequest(Uris.BaseUrl + Uris.TestPage + "GetAll"); 
        //d}
            foreach (var item in this.testpapers)
            {
                
                var it = new { Name = item["examTestPaperName"], IsActive = item["isActive"], ChoiceName = item["examQuestionIDs"].ToString().Split(',').Length,
                    ComletionName = item["examCompletionIDs"].ToString().Split(',').Length, SAQName=item["examShortAnswerQuestionIDs"].ToString().Split(',').Length
                };
                listView.Items.Add(it);
            }
            listView.Items.SortDescriptions.Add(new SortDescription("ID", ListSortDirection.Ascending));
        }

        private async void Updata_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var result = await testpaperServer.UpdataTestActive(Uris.BaseUrl + Uris.TestPage + "UpdataTestPageActive", new entity<long>()
            {
                id = int.Parse(button.Tag.ToString())
            });
            if ((bool)result["success"])
            {
                Initialize();
            }
            else
            {
                MessageBox.Show(result["error"]["message"].ToString());
            }

        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (MessageBox.Show("你是否确实删除此用户", "删除", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var result = await testpaperServer.DeleteRequest(Uris.BaseUrl + Uris.TestPage + "Delete", new entity<long>
                {
                    id = int.Parse(button.Tag.ToString())
                });
                if (result.Equals(HttpStatusCode.OK.ToString()))
                {
                    Initialize();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }
      
        private void CreatePage_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();
            frame.Content = new CreatePages(token);
            this.Content = frame;
        }
    }
}
