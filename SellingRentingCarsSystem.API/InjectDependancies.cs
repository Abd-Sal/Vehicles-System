namespace SellingRentingCarsSystem.API;

public static class InjectDependancies
{
    public static IServiceCollection InjectServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddOptions<ImagesProperties>()
            .BindConfiguration(ImagesProperties.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddOptions<EmailConfigurationsOptions>()
            .Bind(configuration.GetSection(EmailConfigurationsOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services
            .AddDbContext(configuration)
            .AddGlobalExceptionHandler()
            .AddAutoMapperConfig()
            .AddFluentValidationConfig()
            .AddServicesConfig()
            .AddingCorsConfig(configuration)
            .AddAuthenticationConfig(configuration)
            .AddBackgroundJobsConfig(configuration);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnections") ??
            throw new InvalidOperationException("connection string 'DefaultConnections' not found ");
        services.AddDbContext<AppDbContext>(option =>
            option.UseSqlServer(connectionString));
        return services;
    }
    private static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();
        return services;
    }
    private static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            var profileTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract);

            foreach (var profileType in profileTypes)
            {
                cfg.AddProfile(Activator.CreateInstance(profileType) as Profile);
            }
        });
        return services;
    }
    private static IServiceCollection AddFluentValidationConfig(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
    private static IServiceCollection AddServicesConfig(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped<IAuthServices, AuthServices>();
        services.AddScoped<INotificationSender, NotificationSender>();
        return services;
    }
    private static IServiceCollection AddingCorsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddCors(option =>
        //    option.AddDefaultPolicy(builder =>
        //        builder
        //        .AllowAnyMethod()
        //        .AllowAnyHeader()
        //        .WithOrigins(configuration.GetSection(ConstantStrings.AllowedOrigin).Get<string[]>()!)
        //    )
        //);

        services.AddCors(options =>
        {
            options.AddPolicy(ConstantStrings.AllowedOrigin, policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        return services;
    }
    private static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IJwtProvider, JwtProvider>();

        services.AddOptions<JwtOptions>()
            .BindConfiguration(JwtOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var jwtSettings = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings!.Key)),
                ValidIssuer = jwtSettings.Issure,
                ValidAudience = jwtSettings.Audience,
            };
        });

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        });

        return services;
    }
    private static IServiceCollection AddBackgroundJobsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHangfire(config => config
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("JobsDatabase"))
        );
        services.AddHangfireServer();
        return services;
    }
}
