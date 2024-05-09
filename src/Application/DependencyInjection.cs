using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection Services { get; private set; } = new ServiceCollection();
    }
}
