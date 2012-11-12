using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TentIo.Client;
using TentIo.Client.Data;
using TentIo.Client.PostTypes;

namespace SampleWPFClient.ViewModels
{
    public class MainViewModel
    {
        private Dispatcher dispatcher;
        private TentClient client;

        public MainViewModel(Dispatcher currentDispatcher)
        {
            this.dispatcher = currentDispatcher;
            this.StatusUpdates = new ObservableCollection<Post>();
            this.Followings = new ObservableCollection<Follower>();
        }

        public ObservableCollection<Post> StatusUpdates { get; set; }
        public ObservableCollection<Follower> Followings { get; set; }

        public async void Load()
        {
            AppAuthenticationDetails authDetails = new AppAuthenticationDetails()
            {
                AccessToken = "u:2eed4d61",
                MacAlgorithm = "hmac-sha-256",
                MacKey = "46832ba535c87f3ac4e2a5d8d7b98ae0",
                TokenType = "mac"
            };

            client = await TentClient.Connect("tomasmcguinness.tent.is", authDetails);

            foreach (var follower in await client.GetFollowers())
            {
                Followings.Add(follower);
            }

            foreach (var post in await client.GetPosts())
            {
                StatusUpdates.Add(post);
            }
        }
    }
}
