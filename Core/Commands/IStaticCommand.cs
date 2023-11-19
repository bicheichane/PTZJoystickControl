﻿using PtzJoystickControl.Core.Devices;
using PtzJoystickControl.Core.Model;
using PtzJoystickControl.Core.Services;

namespace PtzJoystickControl.Core.Commands
{
    public abstract class IStaticCommand : ICommand
    {
        private IGamepad gamepad = null!;
        private IBitfocusCompanionService companionService = null!;
        public IStaticCommand(IGamepad gamepad, IBitfocusCompanionService companionService)
        {
            Gamepad = gamepad;
            CompanionService = companionService;
        }

        public IGamepad Gamepad { get => gamepad; private set => gamepad = value ?? throw new ArgumentNullException("Gamepad cannot be Null!"); }
        public IBitfocusCompanionService CompanionService { get => companionService; private set => companionService = value ?? throw new ArgumentNullException("CompanionService cannot be Null!"); }

        public abstract string CommandName { get; }
        public abstract string AxisParameterName { get; }
        public abstract string ButtonParameterName { get; }
        public abstract IEnumerable<CommandValueOption> Options { get; }

        public abstract void Execute(int value);
        public void Execute(CommandValueOption value)
        {
            if (value != null!)
                Execute(value.Value);
        }
    }
}
