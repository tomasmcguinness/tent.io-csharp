# TentClient  - a C# client library for tent.io

TentClient is a library written in C# that provides a simple API for the tent.io protocol.

## Technical Bits

To get started, you must first register an application. Registering an application is outlined in the Tent.io documentation [http://tent.io/docs/app-auth](http://tent.io/docs/app-auth). Performing this step is necssary.

## Registering a new application

To begin the registration process, first get an instance of TentClient using the name of the Tent server.

	TentClient client = await TentClient.Connect("tomasmcguinness.tent.is");

First, prepare a registration request.

    RegistrationRequest request = new RegistrationRequest()
    {
        Name = "My Super Duper Client",
        Description = "Most amazing tent.io client ever!",
        Icon = "http://example.com/icon.png",
        Uri = "http://example.com"
    };

Give a redirection url. If you're creating a web application, this will be your site. If you're creating a native application, you'll need to intercept calls to this URL later.

    request.AddRedirectUri("https://example.com/callback");

Ask for the permissions your application needs, giving the reasons.

    request.AddPermissionScope("read_posts", "Need to read posts so they can be displayed.");
    request.AddPermissionScope("write_posts", "Lets you share the cool stuff you do.");
    request.AddPermissionScope("read_followers", "Used to list all your followers");

Finally, send your request. If successful, this will return you an authorization url. 

    string authorizationRedirectUrl = await client.Register(request);

Open this URL in a browser, either by redirecting to it (if a web app) or by opening an embedded browser if it's a native application. This will request the user to authenticate and then authorize your app.

The Tent server will redirect back to your callback Url. Pass this Url into your TentClient instance to complete authorization.

	AppAuthenticationDetails authDetails = await client.ProcessRegisterCallback(calledUrl);

Having obtained the AppAuthenticationDetails, you should persist these values as one of them is the AccessToken needed to perform any actions against.

## Accessing data after registering

Using the AppAuthenticationDetails that you obtained during registration, you can re-create a TentClient at any point

    AppAuthenticationDetails auth = new AppAuthenticationDetails()
    {
        AccessToken = "u:xxxxxx",
        MacAlgorithm = "hmac-sha-256",
        MacKey = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
        TokenType = "mac"
    };

    TentClient client = await TentClient.Connect("tomasmcguinness.tent.is", auth);

Using the AppAuthenticationDetails means this client can perform all of the actions that you requested when the application was registered e.g. read_posts, write_posts etc.

To read posts

    var posts = await client.GetPosts();

At present, this a list of posts, but the data contained is only the ID.