using ProjetoLivros_Home.Context;

var builder = WebApplication.CreateBuilder(args);

//avisa que a aplicação usa controllers
builder.Services.AddControllers();

//adiciono o Gerador de Swagger
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddRazorPages();

// dotnet ef migrations add Inicial
// dotnet ef database update
builder.Services.AddDbContext<LivrosContext>();

//builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
//builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//builder.Services.AddScoped<ILivroRepository, LivroRepository>();
//builder.Services.AddScoped<IAssinaturaRepository, AssinaturaRepository>();
//builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();*/

app.Run();
