var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CAP
builder.Services.AddCap(x =>
{
    x.UseRabbitMQ(opt => {
        opt.HostName = "localhost";
        opt.Port = 15672;
        opt.UserName = "guest";
        opt.Password = "guest";
    });

    x.UseSqlServer(opt =>
    {
        opt.ConnectionString = "Data Source=.;Initial Catalog=CAPdemo;Integrated Security=True;TrustServerCertificate=true";
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
