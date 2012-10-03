# TentClient  - a C# client library for tent.io

TentClient is a library written in C# that provides a simple API for the tent.io protocol.

## Technical Bits

To get started, you must create an instance of the client by performing basic discovery

    TentClient client = await TentClient.Discover("tomasmcguinness.tent.is");

## Registering a new application

According to the tent.io documentation, all applications must first be registered before they can authenticate and be granted permission to a user's tent server. 

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