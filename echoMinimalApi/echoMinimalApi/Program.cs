var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/echo", (string? message) =>
{
    if (string.IsNullOrEmpty(message)) return "...";
    if (message.Length == 1) return message.ToUpper();
    return char.ToUpper(message[0]) + message.Substring(1);
})
.WithName("EchoReceivedMessage");

app.Run();