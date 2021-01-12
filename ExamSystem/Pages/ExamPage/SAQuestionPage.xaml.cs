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
using ExamSystem.WebApi.entities.SAQuestions;

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// SAQuestionPage.xaml 的交互逻辑
    /// </summary>
    public partial class SAQuestionPage : Page
    {
        private readonly SAQuestionServer sAQuestion;

        public SAQuestionPage(Token token)
        {
            InitializeComponent();
            sAQuestion = new SAQuestionServer(token.login_Token);
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            SAQuestionRule sAQuestionRule = new SAQuestionRule()
            {
                Question = question.Text,
                Answer = answer.Text,
                branch = int.Parse(branch.Text)
            };
            var result = await sAQuestion.CreateRequest(Uris.BaseUrl + Uris.SAQuestion + "Create", sAQuestionRule);
            //MessageBox.Show(result.ToString());
            if ((bool)result["success"])
            {
                QuestionBank.testPaperRule.examShortAnswerQuestionIDs.Add(int.Parse(result["result"]["id"].ToString()));
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
