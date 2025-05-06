// File: Helpers/ServiceHelper.cs
using Microsoft.Extensions.DependencyInjection;

namespace MyMauiApp;

public static class ServiceHelper
{
    public static IServiceProvider Services { get; set; }

    public static T GetService<T>() where T : class =>
        Services.GetService<T>()!;
}