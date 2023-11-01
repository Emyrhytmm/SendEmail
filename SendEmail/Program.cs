using EmailApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EmailService>(sp =>
{
    string smtpHost = "smtp.office365.com";
    int smtpPort = 587;
    string senderEmail = "gönderen kiþinin emaili";
    string senderPassword = "gönderen kiþinin þifresi";

    return new EmailService(smtpHost, smtpPort, senderEmail, senderPassword);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
