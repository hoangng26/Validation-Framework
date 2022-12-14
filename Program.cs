using System.ComponentModel.DataAnnotations;
using ValidationFramework.Models;
using ValidationFramework.Validations;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello, this is Validation Framework!");

app.MapPost("/api", (User user) =>
{
    Validation validation = Validation.getInstance();
    HashSet<IConstraintViolation> violations = validation.validate(user);

    Dictionary<string, string> notifications = new Dictionary<string, string>()
    {
        { "email", "" },
        { "password", "" },
        { "phone", "" },
        { "dob", "" },
    };

    foreach (IConstraintViolation violation in violations)
    {
        switch (violation.getProperty())
        {
            case "Email":
                notifications["email"] += violation.getMessage() + ", ";
                break;
            case "Password":
                notifications["password"] += violation.getMessage() + ", ";
                break;
            case "Phone":
                notifications["phone"] += violation.getMessage() + ", ";
                break;
            case "DoB":
                notifications["dob"] += violation.getMessage() + ", ";
                break;
        }

        Console.WriteLine($"{violation.getProperty()} -> {violation.getMessage()}");
    }

    return Results.Ok(notifications);
});

app.Run();
