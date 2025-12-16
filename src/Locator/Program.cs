using Locator;
using Locator.Features.IpLocation;

var builder = WebApplication.CreateBuilder(args);


builder.AddIpLocationFeature();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddHttpClient();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();


app.MapGet("/",async (string Ip,LocationService locationService) =>
{
    return Results.Ok(await locationService.GetLocationByIp(Ip));
});
app.Run();
