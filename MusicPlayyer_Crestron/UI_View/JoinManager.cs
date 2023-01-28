using Crestron.SimplSharpPro.DeviceSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer_Crestron.UI
{
    internal class JoinManager : IUi
    {
        ISmartObject smartObject;
        public JoinManager(ISmartObject smartObject)
        {
            this.smartObject = smartObject;
        }

        public ushort GetAnalogJoin(uint join)
        {
            throw new NotImplementedException();
        }

        public bool GetDigitalJoin(uint join)
        {
            throw new NotImplementedException();
        }

        public string GetSerialJoin(uint join)
        {
            throw new NotImplementedException();
        }

        public void PulseDigitalJoin(uint number)
        {
            throw new NotImplementedException();
        }

        public void SetAnalogJoin(uint number, ushort value)
        {
            throw new NotImplementedException();
        }

        public void SetDigitalJoin(uint number, bool value)
        {
            throw new NotImplementedException();
        }

        public void SetSerialJoin(uint number, string value)
        {
            throw new NotImplementedException();
        }

        public void ToggleDigitalJoin(uint number)
        {
            throw new NotImplementedException();
        }
    }
}
