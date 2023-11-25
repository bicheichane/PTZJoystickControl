using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PtzJoystickControl.Core.Model;

namespace PtzJoystickControl.Core.Services
{
    public interface IBitfocusCompanionService
    {
        event EventHandler<BitfocusCompanionEvent>? ReceivedBitfocusCommand;
        public static void SetJoystickButtonCount(int count) => BitfocusCompanionEvent.SetButtonCountOffset(count);
        public void PressButton(int? pageNumber, int? buttonNumber);
        public void SetCustomVariable(string variableName, string value);
        public List<BitfocusCompanionEvent> SupportedEvents { get; }
    }
}
