using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MouseScreenSelector
{
    class ShutdownScreen
    {
        const int HWND_BROADCAST = 0xffff;
        //the message is sent to all 
        //top-level windows in the system

        const int HWND_TOPMOST = -1;
        //the message is sent to one 
        //top-level window in the system

        int HWND_TOP = 0;        //
        int HWND_BOTTOM = 1;        //limited use
        int HWND_NOTOPMOST = -2;       //

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg,
                      IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //Or 
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
               IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        const int SC_MONITORPOWER = 0xF170;
        const uint WM_SYSCOMMAND = 0x0112;

        const int MONITOR_ON = -1;
        const int MONITOR_OFF = 2;
        const int MONITOR_STANBY = 1;


        public static void shutdownScreen()
        {
            SendMessage((IntPtr)HWND_TOPMOST, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)MONITOR_OFF);
        }


    }
}
