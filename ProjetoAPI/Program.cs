var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();

#pragma warning disable CS8321 // Local function is declared but never used
#pragma warning disable IDE0062 // Make local function 'static'
void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddSwaggerGen();
}
#pragma warning restore IDE0062 // Make local function 'static'
#pragma warning restore CS8321 // Local function is declared but never used

#pragma warning disable CS8321 // Local function is declared but never used
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PackingOptimizationAPI V1");
    });

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
#pragma warning restore CS8321 // Local function is declared but never used

