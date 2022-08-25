using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Domain.Commands;
using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Services;

namespace ToyRobot.Domain
{
    public sealed class DiToyRobot
    {
        public static void Configure(IServiceCollection services)
        {
            RegisterCommands(services);
            RegisterFactories(services);
            RegisterServices(services);
        }

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler, PlaceCommandHandler>();
            services.AddScoped<ICommandHandler, MoveCommandHandler>();
            services.AddScoped<ICommandHandler, ReportCommandHandler>();
            services.AddScoped<ICommandHandler, LeftCommandHandler>();
            services.AddScoped<ICommandHandler, RightCommndHandler>();
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<ICommandHandlerFactory, CommandHandlerFactory>();
            services.AddScoped<ICommandPayloadFactory, CommandPayloadFactory>();
            services.AddScoped<IParameterizeCommandPayloadFactory, PlaceCommandPayloadFactory>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IParseStringCommandService, ParseStringCommandService>();
            services.AddScoped<IToyRobotService, ToyRobotService>();
        }
    }
}
