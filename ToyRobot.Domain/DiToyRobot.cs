using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Domain.Commands;
using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Services;
using ToyRobot.Domain.Specifications;

namespace ToyRobot.Domain
{
    public sealed class DiToyRobot
    {
        public static void Configure(IServiceCollection services)
        {
            RegisterCommands(services);
            RegisterFactories(services);
            RegisterServices(services);
            RegisterSpecifications(services);
        }

        private static void RegisterCommands(IServiceCollection services)
        {
            services.AddScoped<ICommand, PlaceCommand>();
            services.AddScoped<ICommand, MoveCommand>();
            services.AddScoped<ICommand, ReportCommand>();
            services.AddScoped<ICommand, RotateLeftCommand>();
            services.AddScoped<ICommand, RotateRightCommand>();
        }

        private static void RegisterFactories(IServiceCollection services)
        {
            services.AddScoped<ICommandFactory, CommandFactory>();
            services.AddScoped<ICommandPayloadFactory, CommandPayloadFactory>();
            services.AddScoped<IParameterizeCommandPayloadFactory, PlaceCommandPayloadFactory>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IParseStringCommandService, ParseStringCommandService>();
            services.AddScoped<IToyRobotService, ToyRobotService>();
        }

        private static void RegisterSpecifications(IServiceCollection services)
        {
            services.AddScoped<IPlaceCommandSpecification, PlaceCommandSpecification>();
        }
    }
}
