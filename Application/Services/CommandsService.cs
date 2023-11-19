using PtzJoystickControl.Application.Commands;
using PtzJoystickControl.Core.Commands;
using PtzJoystickControl.Core.Devices;
using PtzJoystickControl.Core.Services;

namespace PtzJoystickControl.Application.Services;

public class CommandsService : ICommandsService
{
    private IBitfocusCompanionService _bitfocusCompanionService;

    public CommandsService(IBitfocusCompanionService bitfocusCompanionService)
    {
        _bitfocusCompanionService = bitfocusCompanionService;
    }

    public IEnumerable<ICommand> GetCommandsForGamepad(IGamepad gamepad)
    {
        return new ICommand[]
        {
            new PanCommand(gamepad, _bitfocusCompanionService),
            new TiltCommand(gamepad, _bitfocusCompanionService),
            new ZoomCommand(gamepad, _bitfocusCompanionService),
            new FocusMoveCommand(gamepad, _bitfocusCompanionService),
            new FocusModeCommand(gamepad, _bitfocusCompanionService),
            new FocusLockCommand(gamepad, _bitfocusCompanionService),
            new PresetCommand(gamepad, _bitfocusCompanionService),
            new PresetRecallSpeedComamnd(gamepad, _bitfocusCompanionService),
            new SelectCameraCommand(gamepad, _bitfocusCompanionService),
            new PowerCommand(gamepad, _bitfocusCompanionService)
        };
    }
}
