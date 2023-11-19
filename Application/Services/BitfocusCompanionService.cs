using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PtzJoystickControl.Core.Services;

namespace PtzJoystickControl.Application.Services
{
    public class BitfocusCompanionService : IBitfocusCompanionService
    {
        private readonly HttpClient _client;
        public BitfocusCompanionService(string url, int port)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri($"{url}:{port}/");
        }

        public async void PressButton(int? pageNumber, int? buttonNumber)
        {
            if (pageNumber == null || buttonNumber == null)
                return;

            var reply = await _client.GetAsync($"press/bank/{pageNumber}/{buttonNumber}");
        }

        public async void SetCustomVariable(string variableName, string value)
        {
            var _ = _client.GetAsync($"set/custom-variable/{variableName}?value={value}");
        }
    }
}
