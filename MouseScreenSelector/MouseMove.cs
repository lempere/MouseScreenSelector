using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseScreenSelector
{
    class MouseMove
    {
        static int position = 0;
        static int max_pos = 0;
        static Point[] centers;


        //Mouse 

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;


        public static void initCenterOfScreens()
        {
            int index;
            int upperBound; 
            Screen [] screens = Screen.AllScreens;
            upperBound = screens.GetUpperBound(0);
            
            max_pos = screens.Length;
            centers = new Point[max_pos];
            
            for(index = 0; index <= upperBound; index++)
            {
                // For each screen, add the screen properties to a list box.
                Console.WriteLine("Device Name: " + screens[index].DeviceName);
                Console.WriteLine("Bounds: " + screens[index].Bounds.ToString());
                Console.WriteLine("Type: " + screens[index].GetType().ToString());
                Console.WriteLine("Working Area: " + screens[index].WorkingArea.ToString());
                Console.WriteLine("Primary Screen: " + screens[index].Primary.ToString());

                //Calculate the center of screen
                centers[index] = new Point(screens[index].Bounds.Width / 2 + screens[index].Bounds.X ,
                                           screens[index].Bounds.Height / 2 + screens[index].Bounds.Y);
                
                Console.WriteLine("Center of screen absolute " + centers[index].ToString() );
            }
        }

        public static void mouseMoveNextScreen()
        {
            position++;
            if(position>=max_pos) position=0;

            Cursor.Position = centers[position]; 

        }
    }
    class Vector2
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
