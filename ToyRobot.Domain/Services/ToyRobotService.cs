﻿using ToyRobot.Domain.Factories;
using ToyRobot.Domain.Models;

namespace ToyRobot.Domain.Services
{
    public sealed class ToyRobotService : IToyRobotService
    {
        private readonly IParseStringCommandService _parseStringCommandService;
        private readonly ICommandFactory _commandHandlerFactory;        

        public ToyRobotService(
            IParseStringCommandService parseStringCommandService,
            ICommandFactory commandHandlerFactory)
        {
            _parseStringCommandService = parseStringCommandService;
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void ProcessCommand(string[] commandStrings)
        {            
            var table = Table.Default();

            foreach (var commandString in commandStrings)
            {
                if (string.IsNullOrEmpty(commandString))
                    continue;

                var commandPayload = _parseStringCommandService.Parse(commandString, table);

                var commandHandler = _commandHandlerFactory.Create(commandPayload.Command);
               
                table = commandHandler.Execute(commandPayload);
            }
        }
    }
}
