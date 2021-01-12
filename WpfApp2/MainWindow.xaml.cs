using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        Capture capture;
        private Bgr f = new Bgr(System.Drawing.Color.Red);

        public void InitCamera()
        {
            //将capture实例化，没有任何参数的实例化将会读取本地摄像头
            capture = new Capture();
            //捕捉图片时调用的事件
            capture.ImageGrabbed += Capture_ImageGrabbed;
        }

        private void Capture_ImageGrabbed(object sender, System.EventArgs e)
        {
            Mat frame = new Mat();
            capture.Retrieve(frame, 0);
            img.Image = frame;
        }

        public MainWindow()
        {
            InitializeComponent();
            InitCamera();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (capture != null)
            {
                if ((string)Start.Content == "暂停摄像头")
                {
                    //stop the capture
                    Start.Content = "开启摄像头";
                    capture.Pause();
                }
                else
                {
                    //start the capture
                    Start.Content = "暂停摄像头";
                    capture.Start();
                }
                TextBox1.Text="开始认证";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string BaseUri = "http://localhost:21021/api/services";
            string uri = "app/TDoc/GetDocs";

            //先根据用户请求的uri构造请求地址
            string serviceUrl = string.Format("{0}/{1}", BaseUri, uri);
            //创建Web访问对  象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Accept = "text/plain";
            myRequest.Headers.Add("Authorization", "null");
            myRequest.Headers.Add("X-XSRF-TOKEN", "CfDJ8FSYY11Lp0xFntrm6gOo_5wauB1uw7AjxJ0zIKoXVMaKa_zuJWyO2F2gj5VAPib_SmAUe6Ny7f9yNP2mpaTs6oayA101NlEyjsZm3wbQ3FYUtvzthWx8clpoTapNVs-gW-wznHLOHSQsZRsiM0yHTCk");

            //通过Web访问对象获取响应内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
            string returnXml = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
            reader.Close();
            myResponse.Close();

            //TextBox1.Text = returnXml;
            TextBox1.Text = "认证成功！";
            System.Windows.MessageBox.Show("即将跳转到登录界面！");
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
