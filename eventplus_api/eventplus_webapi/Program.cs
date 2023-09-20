using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Adiciona serviço de Jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

})

.AddJwtBearer("JwtBearer", options =>
{
    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //Valida quem esta recebendo
        ValidateAudience = true,

        //define se o tempo de expiração sera validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai-eventplus-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do audience (para onde está indo)
        ValidIssuer = "eventplus_webapi",

        ValidAudience = "eventplus_webapi"
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//adiciona o gerador do swagger á coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API EventPlus",
        Description = "Uma WEB API para o gerenciamento do site de eventos EventPlus",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Sousa Oliveira",
            Url = new Uri("https://github.com/GSolivier")
        }
    });

    //Configura o swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
           {
               Reference = new OpenApiReference
                {
                  Type = ReferenceType.SecurityScheme,
                   Id = "Bearer"
                }
          },
            new string[] {}
        }
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
app.UseAuthentication();

app.MapControllers();

app.Run();
