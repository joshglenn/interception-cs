
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace InterceptionCS
{
    public class NativeFunctions {
        // P/Invoke:
        private const uint CTLCODE = 0xdaf52480;

        private const uint FILE_DEVICE_UNKNOWN = 0x00000022;
        private const uint METHOD_BUFFERED = 0;
        private const uint FILE_ANY_ACCESS = 0;

        private const uint IOCTL_SET_PRECEDENCE  = 0x801;
        private const uint IOCTL_GET_PRECEDENCE  = 0x802;
        private const uint IOCTL_SET_FILTER      = 0x803;
        private const uint IOCTL_GET_FILTER      = 0x804;
        private const uint IOCTL_SET_EVENT       = 0x805;
        private const uint IOCTL_WRITE           = 0x806;
        private const uint IOCTL_READ            = 0x807;
        private const uint IOCTL_GET_HARDWARE_ID = 0x808;
        
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CreateFile(string filename, FileAccess access, FileShare sharing,
              IntPtr SecurityAttributes, FileMode mode, FileOptions options, IntPtr template
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool DeviceIoControl(IntPtr device, uint ctlcode,
            ref byte inbuffer, int inbuffersize,
            IntPtr outbuffer, int outbufferSize,
            IntPtr bytesreturned, IntPtr overlapped
        );

        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hdl);
    }
    public class _KEYBOARD_INPUT_DATA
    {
        public ushort UnitId;
        public ushort MakeCode;
        public ushort Flags;
        public ushort Reserved;
        public uint ExtraInformation;
    }
    public class _MOUSE_INPUT_DATA
    {
        public ushort UnitId;
        public ushort Flags;
        public ushort ButtonFlags;
        public ushort ButtonData;
        public uint RawButtons;
        public int LastX;
        public int LastY;
        public uint ExtraInformation;
    }

    public class Interception {
        public void CreateContext() { 
        
        }
    }

}
