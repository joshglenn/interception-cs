using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;


namespace TestInterceptionCS
{

    public partial class NativeMethods
    {
        public enum InterceptionKeyState {
            INTERCEPTION_KEY_DOWN = 0x00,
            INTERCEPTION_KEY_UP = 0x01,
            INTERCEPTION_KEY_E0 = 0x02,
            INTERCEPTION_KEY_E1 = 0x04,
            INTERCEPTION_KEY_TERMSRV_SET_LED = 0x08,
            INTERCEPTION_KEY_TERMSRV_SHADOW = 0x10,
            INTERCEPTION_KEY_TERMSRV_VKPACKET = 0x20
        }

        public enum InterceptionFilterKeyState {
            INTERCEPTION_FILTER_KEY_NONE = 0x0000,
            INTERCEPTION_FILTER_KEY_ALL = 0xFFFF,
            INTERCEPTION_FILTER_KEY_DOWN = InterceptionKeyState.INTERCEPTION_KEY_UP,
            INTERCEPTION_FILTER_KEY_UP = InterceptionKeyState.INTERCEPTION_KEY_UP << 1,
            INTERCEPTION_FILTER_KEY_E0 = InterceptionKeyState.INTERCEPTION_KEY_E0 << 1,
            INTERCEPTION_FILTER_KEY_E1 = InterceptionKeyState.INTERCEPTION_KEY_E1 << 1,
            INTERCEPTION_FILTER_KEY_TERMSRV_SET_LED = InterceptionKeyState.INTERCEPTION_KEY_TERMSRV_SET_LED << 1,
            INTERCEPTION_FILTER_KEY_TERMSRV_SHADOW = InterceptionKeyState.INTERCEPTION_KEY_TERMSRV_SHADOW << 1,
            INTERCEPTION_FILTER_KEY_TERMSRV_VKPACKET = InterceptionKeyState.INTERCEPTION_KEY_TERMSRV_VKPACKET << 1
        }

        /// Return Type: int
        ///device: InterceptionDevice->int
        //public delegate int InterceptionPredicate(int device);


        /// <summary>
        /// The callback function.
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int InterceptionPredicate(int device);

        //[UnmanagedFunctionPointer(CallingConvention.StdCall)]
        //delegate void ProgressCallback(int value);

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct InterceptionMouseStroke
        {

            /// unsigned short
            public ushort state;

            /// unsigned short
            public ushort flags;

            /// short
            public short rolling;

            /// int
            public int x;

            /// int
            public int y;

            /// unsigned int
            public uint information;
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        public struct InterceptionKeyStroke
        {

            /// unsigned short
            public ushort code;

            /// unsigned short
            public ushort state;

            /// unsigned int
            public uint information;
        }

        /// Return Type: void*
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_create_context")]
        public static extern System.IntPtr interception_create_context();


        /// Return Type: void
        ///context: InterceptionContext->void*
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_destroy_context")]
        public static extern void interception_destroy_context(System.IntPtr context);

        /// Return Type: int
        ///context: InterceptionContext->void*
        ///device: InterceptionDevice->int
        ///stroke: Void pointer to a char array char[]*
        ///nstroke: unsigned int
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_receive")]
        public static extern int interception_receive(System.IntPtr context, int device, ref byte[] stroke, uint nstroke);

        /// Return Type: InterceptionDevice->int
        ///context: InterceptionContext->void*
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_wait")]
        public static extern int interception_wait(System.IntPtr context);

        /// Return Type: InterceptionDevice->int
        ///context: InterceptionContext->void*
        ///milliseconds: unsigned int
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_wait_with_timeout")]
        public static extern int interception_wait_with_timeout(System.IntPtr context, uint milliseconds);

        /// Return Type: void
        ///context: InterceptionContext->void*
        ///predicate: InterceptionPredicate
        ///filter: InterceptionFilter->unsigned short
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_set_filter")]
        public static extern void interception_set_filter(System.IntPtr context, System.IntPtr predicate, ushort filter);

        /// Return Type: int
        ///device: InterceptionDevice->int
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_is_keyboard")]
        public static extern System.IntPtr interception_is_keyboard(int device);
        
        /// Return Type: int
        ///device: InterceptionDevice->int
        [System.Runtime.InteropServices.DllImportAttribute("interception.dll", EntryPoint = "interception_is_keyboard")]
        public static extern int interception_is_keyboard();
    }

    public partial class Form1 : Form
    {
        public Form1()
        {

            // Set up the context
            System.IntPtr context;
            context = NativeMethods.interception_create_context();

            int device = 0;

            // Initialize stroke variable
            NativeMethods.InterceptionMouseStroke InterceptionMouseStroke = new NativeMethods.InterceptionMouseStroke();
            byte[] stroke = new byte[System.Runtime.InteropServices.Marshal.SizeOf(InterceptionMouseStroke)];
            //char[] stroke = new char[System.Runtime.InteropServices.Marshal.SizeOf(InterceptionMouseStroke)];

            // Raise process priority
            Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
            myProcess.PriorityClass = ProcessPriorityClass.High;

            context = NativeMethods.interception_create_context();

            Console.WriteLine("");
            //NativeMethods.interception_set_filter(
            //    context, NativeMethods.interception_is_keyboard(device),
            //    NativeMethods.InterceptionFilterKeyState.INTERCEPTION_FILTER_KEY_DOWN | NativeMethods.InterceptionFilterKeyState.INTERCEPTION_FILTER_KEY_UP);

            //ProgressCallback callback =
            //(value) =>
            //{
            //    Console.WriteLine("Progress = {0}", value);
            //};

            //NativeMethods.InterceptionPredicate predicate =
            //    (value) =>
            //    {
            //        //
            //    };

            //NativeMethods.InterceptionPredicate = new NativeMethods.InterceptionPredicate(0);

           

            //NativeMethods.interception_set_filter(
            //    context, NativeMethods.interception_is_keyboard,
            //    0x00 | 0x00 << 1);


            //device = NativeMethods.interception_wait(context);
            //int i2 = NativeMethods.interception_receive(context, device = NativeMethods.interception_wait(context), ref stroke, 1);


            //int dd = NativeMethods.interception_is_keyboard();


            //while (NativeMethods.interception_receive(context, device = NativeMethods.interception_wait(context), ref stroke, 1) > 0)
            //{ 
            //    Console.WriteLine("Bob");
            //}

            // Normal windows forms processing
            InitializeComponent();

        }
    }
}
