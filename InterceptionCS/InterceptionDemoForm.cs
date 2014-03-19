using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace InterceptionCS
{
    public partial class InterceptionDemoForm : Form
    {

        public InterceptionDemoForm()
        {
            InitializeComponent();
            
        }

        private void monitorKeystrokesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonitorKeystrokes();
        }

        /// <summary>
        /// Starts a loop monitoring all keystrokes entered using any HID attached to the system
        /// </summary>
        private static void MonitorKeystrokes()
        {


            IntPtr context;
            int device;
            Interception.Stroke stroke = new Interception.Stroke();

            context = Interception.CreateContext();

            Interception.SetFilter(context, Interception.IsKeyboard, Interception.Filter.All);

            while (Interception.Receive(context, device = Interception.Wait(context), ref stroke, 1) > 0)
            {
                Console.WriteLine("SCAN CODE: {0}/{1}", stroke.key.code, stroke.key.state);

                if (stroke.key.code == ScanCode.X)
                {
                    stroke.key.code = ScanCode.Y;
                }
                Interception.Send(context, device, ref stroke, 1);

                // Hitting escape terminates the program
                if (stroke.key.code == ScanCode.Escape)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Starts a loop waiting for keyboard events, then writes the 
        /// output to the console. when running this method, the UI will block and it
        /// will appear that the application is frozen. But the keystrokes will still be logged
        /// to the debugging console. To break out of this method and release the block on the
        /// UI, press the Esc key.
        /// </summary>
        private static void GetHardwareID()
        {
            int errorCode = Marshal.GetLastWin32Error();

            IntPtr context;
            int device;
            Interception.Stroke stroke = new Interception.Stroke();

            context = Interception.CreateContext();

            Interception.SetFilter(context, Interception.IsKeyboard, Interception.Filter.All);

            StringBuilder sb = new StringBuilder(500);

            while (Interception.Receive(context, device = Interception.Wait(context), ref stroke, 1) > 0)
            {
                Console.WriteLine("SCAN CODE: {0}/{1}", stroke.key.code, stroke.key.state);

                uint iXX = Interception.interception_get_hardware_id(context, device, sb, (uint)sb.Capacity);
                
                string s = sb.ToString();

                if (iXX > 0)
                {
                    Console.WriteLine(
                    s
                    );
                }
                else
                {
                    Console.WriteLine("Message here");
                }
               
                Interception.Send(context, device, ref stroke, 1);

                // Hitting escape terminates this method 
                // and returns control to windows.
                if (stroke.key.code == ScanCode.Escape)
                {
                    break;
                }
            }
            Interception.DestroyContext(context);
        }

        private void monitorWithHardwareIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetHardwareID();
        }

        private void InterceptionDemoForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
