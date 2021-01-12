using ExamSystem.WebApi.entities.ChocieQuestions;
using System.Windows;
using System.Windows.Controls;
using ExamSystem.WebApi.Server;
using ExamSystem.WebApi;
using ExamSystem.Pages.ExamPage;
using ExamSystem.WebApi.entities.TestPapers;
using ExamSystem.CustomControl;

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// ChoicePage.xaml 的交互逻辑
    /// </summary>
    public partial class ChoicePage : Page
    {
        private readonly ChocieQuestionServer choiceServer;

        public ChoicePage(Token token)
        {
            InitializeComponent();
            choiceServer = new ChocieQuestionServer(token.login_Token);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ChoiceQuestionRule choice = new ChoiceQuestionRule()
            {
                Question = question.Text,
                TrueAnswer = trueAnswer.Text,
                OrtherAnswerOne = ortherAnswerOne.Text,
                OrtherAnswerThree = ortherAnswerThree.Text,
                OrtherAnswerTwo = ortherAnswerTwo.Text,
                branch = int.Parse(branth.Text)
            };

            var result = await choiceServer.CreateRequest(Uris.BaseUrl + Uris.ChoiceQuestion + "Create", choice);
            //MessageBox.Show(result.ToString());
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

        public void GoBack()
        {
            Frame frame = new Frame();
            frame.Content = new PreViewPage();
            this.Content = frame;
        }
    }
}
