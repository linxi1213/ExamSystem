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
using ExamSystem.CustomControl;

namespace ExamSystem.Pages.ExamPage
{
    /// <summary>
    /// PreViewPage.xaml 的交互逻辑
    /// </summary>
    public partial class PreViewPage : Page
    {
        public PreViewPage()
        {
            InitializeComponent();
            Initialize();
            
        }

        private void Initialize()
        {
            TestPaperRule testPaperRule = QuestionBank.testPaperRule;
            var infor = new { choiceCount=testPaperRule.examQuestionIDs.Count, comrletionCount=testPaperRule.examCompletionIDs.Count, 
                saQuestionCount=testPaperRule.examShortAnswerQuestionIDs.Count };
            listView.Items.Add(infor);
        }


    }
}
