using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SmartDeviceProject1
{
    class Beep
    {
        [DllImport("CoreDll.dll")]
        public static extern void MessageBeep(int code);

        public const int ASTERISK = 64;
        public const int QUESTION = 32;
        public const int STOP = 16;
        public const int OK = 0;
    }
}
