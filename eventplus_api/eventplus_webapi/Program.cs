using Microsoft.Azure.CognitiveServices.ContentModerator;
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
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem esta solicitando
        ValidateIssuer = true,

        //Valida quem esta recebendo
        ValidateAudience = true,

        //define se o tempo de expiração sera validado
        ValidateLifetime = true,

        //forma de criptografia e valida a chave de autenticação
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai-eventplus-chave-autenticacao-webapi")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //nome do audience (para onde está indo)
        ValidIssuer = "eventplus_webapi",

        ValidAudience = "eventplus_webapi"
    };
});


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

    //Adicionar dentro de AddSwaggerGen
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

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

builder.Services.AddCors(options => {
    options.AddPolicy(name: "MyPolicy",
    policy => {
        policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }   
    );
});

builder.Services.AddSingleton(provider => new ContentModeratorClient(
        new ApiKeyServiceClientCredentials("015a3091484a4f2294aba8db95aaf320"))
{
    Endpoint = "https://eventplusmoderator-guilherme.cognitiveservices.azure.com/"
}
);

var app = builder.Build();

//Alterar dados do Swagger para a seguinte configuração
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(options =>
{
    options.SerializeAsV2 = true;
});

app.UseSwaggerUI();

//Para atender à interface do usuário do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseCors("MyPolicy");

app.UseRouting();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


app.Run();
