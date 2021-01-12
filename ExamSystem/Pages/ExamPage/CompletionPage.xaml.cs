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
using ExamSystem.WebApi.entities.Completions;

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// CompletionPage.xaml 的交互逻辑
    /// </summary>
    public partial class CompletionPage : Page
    {
        private readonly CompletionServer completionServer;

        public CompletionPage(Token token)
        {
            InitializeComponent();
            completionServer = new CompletionServer(token.login_Token);
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(question.Text.IndexOf("??")==-1)
            {
                MessageBox.Show("输入格式有错！");
                return;
            }
            CompletionRule completion = new CompletionRule()
            {
               Question = question.Text,
               Answer = answer.Text,
               branch =int.Parse(branch.Text)
            };

            var result = await completionServer.CreateRequest(Uris.BaseUrl + Uris.Completion + "Create", completion);
            if ((bool)result["success"])
            {
                QuestionBank.testPaperRule.examCompletionIDs.Add(int.Parse(result["result"]["id"].ToString()));
                GoBack();
            }
            else
            {
                MessageBox.Show(result["error"]["message"].ToString());
            }
        }

        public void GoBack()
        {
            Frame frame = new Frame();
            frame.Content = new PreViewPage();
            this.Content = frame;
        }
    }
}
