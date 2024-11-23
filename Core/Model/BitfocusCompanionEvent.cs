using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PtzJoystickControl.Core.Model.InboundBitfocusCompanionEventEnum;

namespace PtzJoystickControl.Core.Model
{
    public enum InboundBitfocusCompanionEventEnum
    {
        SetCameraPreview
    }

    public class BitfocusCompanionEvent
    {

        #region Static Members
        public static List<BitfocusCompanionEvent> SupportedEvents = new()
        {
            new BitfocusCompanionEvent(SetCameraPreview, "1"),
            new BitfocusCompanionEvent(SetCameraPreview, "2")
        };

        private static int _buttonCounter = 0;
        private static int _joystickButtonCountOffset = 0;

        public static BitfocusCompanionEvent? FindMatchingEvent(string param, string? value)
        {
            var inboundEvent = Enum.Parse<InboundBitfocusCompanionEventEnum>(param);

            var match = SupportedEvents.FindAll(e => e.EventType == inboundEvent && e.Value == value);

            if (match.Count != 1)
                return null;

            return match[0];
        }

        public static void SetButtonCountOffset(int offset) => _joystickButtonCountOffset = offset;

#endregion


private int _button;
        public InboundBitfocusCompanionEventEnum EventType { get; set; }
        public string Value { get; set; }

        public int Button
        {
            get => _button + _joystickButtonCountOffset;
            private set => _button = value;
        }

        public string EventNameFormatString
        {
            get
            {
                switch (EventType)
                {
                    case SetCameraPreview:
                        return $"Vmix Cam {Value} Preview";
                    default:
                        throw new Exception($"Unsupported name format string for event: {EventType}");
                }
            }
        }

        public BitfocusCompanionEvent(InboundBitfocusCompanionEventEnum type, string value)
        {
            Button = ++_buttonCounter;
            Value = value;
            EventType = type;
        }
    }
}
