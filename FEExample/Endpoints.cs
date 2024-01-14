namespace FEExample;

using FastEndpoints;
using FSharpLib;

public class MyEndpoint : Endpoint<MyRequest, MyResponse>
{
    public override void Configure()
    {
        Post("/api/user/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MyRequest req, CancellationToken ct)
    {
        await SendAsync(new()
        {
            FullName = req.FirstName + " " + req.LastName,
            IsOver18 = req.Age > 18
        });
    }
}

public class MyResponse
{
    public string FullName { get; set; }
    public bool IsOver18 { get; set; }
}

// compare with F# version - uncomment to use this class
// public class MyRequest
// {
//     public string FirstName { get; set; }
//     public string LastName { get; set; }
//     public int Age { get; set; }
// }