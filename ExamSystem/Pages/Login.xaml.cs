using Abp;
using ExamSystem.Pages;
using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Security.Policy;
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

namespace ExamSystem
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        private Token login_token; // 登录Token

        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //if(!PingIp())
            //{
            //    MessageBox.Show("服务器未开启!");
            //    return;
            // }    
            login_token = new Token();
            user us = new user();
            //us.UsernameOrEmailAddress = UserID.Text;
            //us.Password = UserPassword.Password;
            us.UsernameOrEmailAddress = "admin";
            us.Password = "123qwe";
            try
            {
                string re = await login_token.GetToken(us);

                if (login_token.login_Token == null)
                    MessageBox.Show(re);
                else
                {
                    Application.Current.MainWindow.Content = new Home(login_token);
                    //MessageBox.Show("登录成功"); 
                    //Text();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Register();
        }

        /// <summary>
        /// 人脸识别认证登录
        /// </summary>
        public void FaceDiscen()
        {

        }

        /// <summary>
        /// Ping服务器是否开始
        /// </summary>
        /// <returns></returns>
        private bool PingIp()
        {
            bool bRet = false;
            try
            {
                Ping pingSend = new Ping();
                PingReply reply = pingSend.Send(Uris.BaseUrl, 3000);
                if (reply.Status == IPStatus.Success)
                    bRet = true;
            }
            catch (Exception)
            {
                bRet = false;
            }
            return bRet;
        }

        /// <summary>
        /// GetAll测试
        /// </summary>
        public async void Text()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + login_token.login_Token);
                var result = await client.GetAsync(Uris.BaseUrl + "/api/services/app/User/GetAll");

                string st = await result.Content.ReadAsStringAsync();

                JToken s = JToken.Parse(st);

                List<JToken> a = s["result"]["items"].ToList<JToken>();

                foreach (var i in a)
                {
                    MessageBox.Show(i.ToString());
                }

            }
        }



        #region 测试
        //public async Task CookieBasedAuth()
        //{
        //    Uri uri = new Uri(baseUrl + loginUrl);
        //    var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None, UseCookies = true };
        //    using(var client = new HttpClient(handler))
        //    {
        //        client.BaseAddress = uri;
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));

        //        var content = new FormUrlEncodedContent(new Dictionary<string, string>()
        //        {
        //            {"TenancyName", "Default"},
        //            {"UsernameOrEmailAddress", user},
        //            {"Password", pwd }
        //        });

        //        var result = await client.PostAsync(uri, content);

        //        HttpStatusCode state = result.StatusCode;
        //        MessageBox.Show(state.ToString());

        //        string loginResult = await result.Content.ReadAsStringAsync();

        //        MessageBox.Show(loginResult);
        //        var getCookies = handler.CookieContainer.GetCookies(uri);

        //        foreach(Cookie cookie in getCookies)
        //        {
        //            _abpWebApiClient.Cookies.Add(cookie);

        //        }

        //    }
        //}

        //public async Task<string> GetAbpToken()
        //{
        //    Uri uri = new Uri(baseUrl);
        //    var tokenResult = await _abpWebApiClient.PostAsync<string>(baseUrl + abpTokenUrl, new
        //    {
        //        TenancyName = "Default",
        //        UsernameOrEmailAddress = user,
        //        Password = pwd
        //    });
        //    //Application.SetCookie(uri, tokenResult);
        //    MessageBox.Show(tokenResult);
        //    return tokenResult;
        //}

        //public async void GetExamineesCount()
        //{  var uri = baseUrl + "/api/services/app/Examinee/GetExamineesCount";
        //    //_abpWebApiClient.RequestHeaders.Add(new Abp.NameValue("Authorization","Bearer " +_abpWebApiClient.Cookies.First() ));
        //   using(var httpclient = new HttpClient())
        //    {
        //        httpclient.DefaultRequestHeaders.Add("Authorization", "Bearer " + login_token.login_Token);
        //        var re = await httpclient.GetAsync(uri);

        //        var result = await re.Content.ReadAsStringAsync();
        //        var obj = JToken.Parse(result);
        //        MessageBox.Show(obj.ToString());
        //    }



        //   // var result = await _abpWebApiClient.PostAsync<string>(uri);


        //}

        #endregion

    }
}
