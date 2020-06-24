//using NGU.Border.Controls;
using System;

namespace NGU.App.Client.ViewModels
{
    public class FingerEventArgs : EventArgs
    {
        public FingerEventArgs(string finger, bool isVerified)
        {
            Finger = finger;
            IsVerified = isVerified;
        }

        public string Finger { get; set; }
        public bool IsVerified { get; set; }
    }
}