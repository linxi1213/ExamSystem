using ExamSystem.WebApi;
using ExamSystem.WebApi.entities.TestPapers;
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

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// CreatePages.xaml 的交互逻辑
    /// </summary>
    public partial class CreatePages : Page
    {
        private readonly Token token;
        private readonly TestpaperServer testpaperServer;

        public CreatePages(Token token)
        {
            InitializeComponent();
            this.token = token;
            QuestionBank.testPaperRule = new TestPaperRule();
            questionFram.Content = new PreViewPage();
            testpaperServer = new TestpaperServer(token.login_Token);
        }

        private void CreateChoice_Click(object sender, RoutedEventArgs e)
        {
            questionFram.Content = new ChoicePage(token);
        }

        private void CreateCompletion_Click(object sender, RoutedEventArgs e)
        {
            questionFram.Content = new CompletionPage(token);
        }

        private void CreateASQuestion_Click(object sender, RoutedEventArgs e)
        {
            questionFram.Content = new SAQuestionPage(token);
        }


        private void Revesr_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(textpapaername.Text.Equals(""))
            {
                MessageBox.Show("请输入试卷名称");
                return;
            }
            QuestionBank.testPaperRule.examTestPaperName = textpapaername.Text;
            if(QuestionBank.JudgeIsNull_TestRule())
            {
                var result = await testpaperServer.CreateRequest(Uris.BaseUrl + Uris.TestPage + "Create",QuestionBank.testPaperRule);
                if ((bool)result["success"])
                {
                    QuestionBank.testPaperRule.examQuestionIDs.Add(int.Parse(result["result"]["id"].ToString()));

                    GoBack();
                }
                else
                {
                    MessageBox.Show(result["error"]["message"].ToString());
                }
            }
            else
            {
                MessageBox.Show("当前试卷为空");
            }

        }

        private void GoBack()
        {
            Frame frame = new Frame();
            frame.Content = new ExamPaper(token);
            this.Content = frame;
        }


    }
}
