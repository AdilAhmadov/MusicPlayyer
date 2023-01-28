using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer_Crestron.UI
{
    internal interface IUi
    {
        ushort GetAnalogJoin(uint join);
        bool GetDigitalJoin(uint join);
        string GetSerialJoin(uint join);
        void PulseDigitalJoin(uint number);
        void SetAnalogJoin(uint number, ushort value);
        void SetDigitalJoin(uint number, bool value);
        void SetSerialJoin(uint number, string value);
        void ToggleDigitalJoin(uint number);
    }
}
