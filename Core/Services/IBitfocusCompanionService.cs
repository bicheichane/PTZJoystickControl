using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PtzJoystickControl.Core.Services
{
    public interface IBitfocusCompanionService
    {
        public void PressButton(int? pageNumber, int? buttonNumber);
        public void SetCustomVariable(string variableName, string value);
    }
}
