using System;

namespace ClinicControl.exceptions
{
    public class CheckInException : Exception
    {
        public CheckInException(string message) : base(message)
        {

        }
    }
}
