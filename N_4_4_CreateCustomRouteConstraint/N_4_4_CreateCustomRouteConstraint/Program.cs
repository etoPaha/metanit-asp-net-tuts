using N_4_4_CreateCustomRouteConstraint.MapConstraints;

var builder = WebApplication.CreateBuilder(args);

// Добавляем новое ограничение
builder.Services.Configure<RouteOptions>(options => options.ConstraintMap.Add("secretcode", typeof(SecretCodeConstraint)));

// Второй вариант добавления
builder.Services.AddRouting(options => 
                                options.ConstraintMap.Add("invalidnames", typeof(InvalidNamesConstraint)));

var app = builder.Build();

// Применение первого ограничения
app.Map(
    "/users/{name}/{token:secretcode(123)}/",
    (string name, int token) => $"Name: {name} \nToken: {token}");

// Применение второго ограничения
app.Map(
    "/names/{name:invalidnames}",
    (string name) => $"Name: {name}");

app.Map("/", () => "Index page");

app.Run();