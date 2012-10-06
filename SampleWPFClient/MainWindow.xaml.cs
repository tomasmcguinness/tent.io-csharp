using System;
using System.Collections.Generic;
using System.Linq;
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
using TentIo.Client;
using TentIo.Client.Data;

namespace SampleWPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TentClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppAuthenticationDetails auth = new AppAuthenticationDetails()
            {
                AccessToken = "u:2eed4d61",
                MacAlgorithm = "hmac-sha-256",
                MacKey = "46832ba535c87f3ac4e2a5d8d7b98ae0",
                TokenType = "mac"
            };

            client = await TentClient.Connect("tomasmcguinness.tent.is", auth);

            var posts = await client.GetPosts();

            //client = await TentClient.Discover("tomasmcguinness.tent.is");

            //RegistrationRequest request = new RegistrationRequest()
            //{
            //    Name = "Amazeballs",
            //    Description = "Most amazing app ever!",
            //    Icon = "http://example.com/icon.png",
            //    Uri = "http://example.com"
            //};

            //request.AddRedirectUri("https://example.com/callback");
            //request.AddPermissionScope("read_posts", "Need this to do amazeballs things");
            //request.AddPermissionScope("write_posts", "Need this to do amazeballs things");
            //request.AddPermissionScope("read_followers", "Need this to do amazeballs things");

            //string redirectUrl = await client.Register(request);

            //url.Text = redirectUrl;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var output = await client.ProcessRegisterCallback(new Uri(code.Text).Query);
            accessToken.Text = output.AccessToken;
        }
    }
}
