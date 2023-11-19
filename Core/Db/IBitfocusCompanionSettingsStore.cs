using PtzJoystickControl.Core.Model;

namespace PtzJoystickControl.Core.Db
{
    public interface IBitfocusCompanionSettingsStore
    {
        List<GamepadSettings> GetAllSettings();
        GamepadSettings? GetGamepadSettingsById(string id);
        bool SaveGamepadSettings(GamepadSettings GamepadSettings);
    }
}