using Crestron.SimplSharp;
using Crestron.SimplSharpPro.DeviceSupport;
using Crestron.SimplSharpPro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crestron.SimplSharp.CrestronIO;
using System.Diagnostics;
using System.Xml;

namespace MusicPlayer_Crestron.UI
{
    public class UIManager
    {
        public BasicTriListWithSmartObject currentDevice;
        private ControlSystem _cs;
        private string sgdFilePath = Path.Combine(Directory.GetApplicationDirectory(), "IA873_TSW1070.sgd");
        private CCriticalSection PickerCritical;

        private CCriticalSection LoaderCritical;

        public UIManager(BasicTriListWithSmartObject _currentDevice, ControlSystem cs)
        {
            this.currentDevice = _currentDevice;
            this._cs = cs;
            this.Add();
            this.Register();

            LoaderCritical = new CCriticalSection();
        }
        private void Add()
        {
            this.currentDevice.OnlineStatusChange += new OnlineStatusChangeEventHandler(myPanel_StatusChange);
            this.currentDevice.SigChange += new SigEventHandler(myPanel_SigChange);
        }
        private void Register()
        {
            if (currentDevice.Register() != eDeviceRegistrationUnRegistrationResponse.Success)
            {
                ErrorLog.Error(string.Format("Falied to register the {0}, Reason {1}", currentDevice.Name, currentDevice.RegistrationFailureReason));
            }
            else
            {
                if (File.Exists(sgdFilePath))
                {
                    currentDevice.LoadSmartObjects(sgdFilePath);
                    foreach (KeyValuePair<uint, SmartObject> SO in currentDevice.SmartObjects)
                    {
                        //SO.Value.SigChange += new SmartObjectSigChangeEventHandler(SO_ValueSigChange);
                        //Debug.PrintLine(string.Format("SGD File with Smart graphics ID {0} is Loaded", SO.Value.ID));
                    }
                }
                else
                {
                    ErrorLog.Error("Error while finding SGD File make shure if it is copied to application directory");
                }
                PickerCritical = new CCriticalSection();
            }
        }
        private void myPanel_StatusChange(GenericBase currentDevice, OnlineOfflineEventArgs args)
        {
            try
            {
                if (currentDevice.IsOnline)
                {
                    Debug.PrintLine("Touch Panel Is Registred");
                }
                else
                {
                    Debug.PrintLine("Touch Panel Is Offline");
                }
            }
            catch (Exception ex) { ErrorLog.Exception("Error Ocured on Panel Status Change Event: ", ex); }
        }
        private void myPanel_SigChange(BasicTriList currentDevice, SigEventArgs args)
        {
            try
            {
                var boolValue = args.Sig.BoolValue;
                var sigNumber = args.Sig.Number;
                switch (args.Sig.Type)
                {
                    case eSigType.Bool:
                        if (boolValue == true)
                        {
                           
                        }
                        break;
                    case eSigType.UShort:
                        
                        break;
                    case eSigType.String:
                        
                        break;
                }
            }
            catch (Exception ex) { ErrorLog.Exception("Error in myPanel_SigChange Event: ", ex); }
        }
    }
}
