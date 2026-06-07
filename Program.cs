// Program.cs
// ASP.NET Core replaces Global.asax + WebApiConfig with this single file.
// No duplicate route errors possible here.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Allow Dify cloud servers to call this API (CORS)
builder.Services.AddCors(options =>
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()));

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
