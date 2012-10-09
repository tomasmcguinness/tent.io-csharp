using SampleWPFClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        public MainWindow()
        {
            this.DataContext = new MainViewModel(Dispatcher);
            this.Loaded += MainWindow_Loaded;
            InitializeComponent();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ((MainViewModel)DataContext).Load();
        }

        //private async void btnAuthorize_Click(object sender, RoutedEventArgs e)
        //{
        //  client = await TentClient.Discover("tomasmcguinness.tent.is");

        //  RegistrationRequest request = new RegistrationRequest()
        //  {
        //    Name = "Amazeballs",
        //    Description = "Most amazing app ever!",
        //    Icon = "http://example.com/icon.png",
        //    Uri = "http://example.com"
        //  };

        //  request.AddRedirectUri("https://example.com/callback");
        //  request.AddPermissionScope("read_posts", "Need this to do amazeballs things");
        //  request.AddPermissionScope("write_posts", "Need this to do amazeballs things");
        //  request.AddPermissionScope("read_followers", "Need this to do amazeballs things");

        //  string redirectUrl = await client.Register(request);

        //  browser.Navigate(redirectUrl);
        //  browser.Visibility = System.Windows.Visibility.Visible;
        //  browser.Navigated += browser_Navigated;
        //}

        //async void browser_Navigated(object sender, NavigationEventArgs e)
        //{
        //  Debug.WriteLine("Connecting to [{0}]", e.Uri.ToString());

        //  if (e.Uri.Host == "example.com")
        //  {
        //    var output = await client.ProcessRegisterCallback(e.Uri.Query);

        //    var settings = new Dictionary<string, object>();
        //    settings.Add("accessToken", output.AccessToken);
        //    settings.Add("macKey", output.MacKey);
        //    settings.Add("macKeyIdentifier", output.MacKeyIdentifier);
        //    settings.Add("tokenType", output.TokenType);

        //    BinaryFormatter formatter = new BinaryFormatter();
        //    var store = IsolatedStorageFile.GetUserStoreForAssembly();

        //    using (var stream = store.OpenFile("authorization.cfg", FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //      formatter.Serialize(stream, settings);
        //    }

        //    browser.Visibility = System.Windows.Visibility.Collapsed;

        //  }
        //}
    }
}
