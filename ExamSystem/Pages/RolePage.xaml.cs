using ExamSystem.WebApi;
using ExamSystem.WebApi.entities;
using ExamSystem.WebApi.entities.Roles;
using ExamSystem.WebApi.Server;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
    /// RolePage.xaml 的交互逻辑
    /// </summary>
    public partial class RolePage : Page
    {
        private RoleServer roleServer;
        private Token token;
        private readonly string ID;
        private JToken permission;
        private readonly string operation;

        public RolePage(Token token,string ID,string operation)
        {
            InitializeComponent();
            this.ID = ID;
            this.token = token;
            this.operation = operation;
            roleServer = new RoleServer(token.login_Token);
            if(operation.Equals("Update"))
            {
                InitializeRole();
            }
            else if(operation.Equals("Create"))
            {
                InitializeRoles();
            }
        }

        /// <summary>
        /// 初始显示数据
        /// </summary>
        public async void InitializeRole()
        {
            permission = await roleServer.GetRequest(Uris.BaseUrl + Uris.Role + "GetAllPermissions");
            JToken result = await roleServer.GetRequest(Uris.BaseUrl + Uris.Role + "Get", new entity<long>() { id = long.Parse(ID) });
            roleName.Text = result["name"].ToString();
            displayName.Text = result["displayName"].ToString();
            description.Text = result["description"].ToString();
            foreach (var item in permission["items"])
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = item["displayName"];
                checkBox.Tag = item["name"].ToString();
                foreach (var i in result["grantedPermissions"])
                {
                    if (i.ToString().ToLower().Equals(item["name"].ToString().ToLower()))
                    {
                        checkBox.IsChecked = true;
                    }
                }
                permissinons.Children.Add(checkBox);
            }
        }

        public async void InitializeRoles()
        {
            JToken result = await roleServer.GetRequest(Uris.BaseUrl + Uris.Role + "GetAllPermissions");
            foreach (var item in result["items"])
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Content = item["displayName"].ToString();
                checkBox.Tag = item["name"].ToString();
                permissinons.Children.Add(checkBox);
            }
        }

        private  void Update_Click(object sender, RoutedEventArgs e)
        {
           if(operation.Equals("Update"))
            {
                UpdateRole();
            }
           else if(operation.Equals("Create"))
            {
                CreateRole();
            }
            
        }


        private async void UpdateRole()
        {
            RoleRule role = GetRule();

            var result = await roleServer.UpdateRequest(Uris.BaseUrl + Uris.Role + "Update", role);

            if (!result.Equals(HttpStatusCode.OK.ToString()))
            { MessageBox.Show(result); }
            else
            {
                Goback();
            }
        }

        private RoleRule GetRule()
        {
            List<string> permission = new List<string>();
            foreach (CheckBox item in permissinons.Children)
            {
                if (item.IsChecked == true)
                {
                    permission.Add(item.Tag.ToString());
                }
            }
            RoleRule role = new RoleRule()
            {
                id = ID,
                description = description.Text,
                displayName = displayName.Text,
                name = roleName.Text,
                grantedPermissions = permission.ToArray(),
                normalizedName = roleName.ToString().ToUpper()
            };
            return role;
        }

        private async void CreateRole()
        {
            RoleRule role = GetRule();
            role.id = null;
           

            var result = await roleServer.CreateRequest(Uris.BaseUrl + Uris.Role + "Create", role);

            if ((bool)result["success"])
            {  Goback();}
            else
            {
                MessageBox.Show(result["error"]["message"].ToString()); 
            }
        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            Goback();
        }

        private void Goback()
        {
            Frame frame = new Frame();
            frame.Content = new Roles(token);
            this.Content = frame;
        }

    }
}
