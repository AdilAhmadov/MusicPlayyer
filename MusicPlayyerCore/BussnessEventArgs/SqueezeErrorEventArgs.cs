using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerCore.BussnessEventArgs
{
    public class SqueezeErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the SqueezeErrorEventArgs class from the
        /// specified instance of the Exception class
        /// </summary>
        /// <param name="ex">The error which occured during the execution of a SqueezeRepository operation</param>
        public SqueezeErrorEventArgs(Exception ex)
        {
            exception = ex;
        }

        private Exception exception;

        /// <summary>
        /// The exception which was raised during execution
        /// </summary>
        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }
        private bool handled = false;

        /// <summary>
        /// If the handled property is set to true, the exception is not reraised
        /// </summary>
        public bool Handled
        {
            get { return handled; }
            set { handled = value; }
        }
    }
}
