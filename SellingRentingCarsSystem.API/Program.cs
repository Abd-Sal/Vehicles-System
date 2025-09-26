var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjectServices(builder.Configuration);
builder.Services.AddOpenApi();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseExceptionHandler();

app.UseHsts();  //only treat with HTPS requests

app.UseHttpsRedirection();

app.UseHangfireDashboard("/jobs", new DashboardOptions
{
    Authorization = [
        new HangfireCustomBasicAuthenticationFilter{
                    User = app.Configuration.GetValue<string>("HangfireSettings:Username"),
                    Pass = app.Configuration.GetValue<string>("HangfireSettings:Password")
                }
    ],
    DashboardTitle = "Eagle For Cars Trading Dashboard"
});

app.UseSerilogRequestLogging();

app.UseCors(ConstantStrings.AllowedOrigin);

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//app.MapHealthChecks("health", new HealthCheckOptions
//{
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

//app.UseRateLimiter();

app.Run();

