using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kchordr
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

        private static void GetHardwareID()
        {
            //size_t length = interception_get_hardware_id(context, device, hardware_id, sizeof(hardware_id));

            IntPtr context;
            int device;
            Interception.Stroke stroke = new Interception.Stroke();

            context = Interception.CreateContext();

            Interception.SetFilter(context, Interception.IsKeyboard, Interception.Filter.All);

            StringBuilder sb = new StringBuilder(500);

            while (Interception.Receive(context, device = Interception.Wait(context), ref stroke, 1) > 0)
            {
                Console.WriteLine("SCAN CODE: {0}/{1}", stroke.key.code, stroke.key.state);

                
                //byte[] hwid = new byte[500];
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
                //sb = null;
                
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

        private void monitorWithHardwareIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetHardwareID();
        }

        private void InterceptionDemoForm_Load(object sender, EventArgs e)
        {
            
        }

    }
}
