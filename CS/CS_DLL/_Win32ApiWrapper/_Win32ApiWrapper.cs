using System;
using Microsoft.Win32.SafeHandles;

using System.Runtime.InteropServices;

namespace Util
{
    public class _Win32ApiWrapper
    {
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // 定数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // public関数
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        public static bool RemoveDevice()
        {


            return true;
        }

        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -
        // インポート(Win32 API)
        // - = - = - = - = - = - = - = - = - = - = - = - = - = - = - = -

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeviceIoControl(
            SafeFileHandle hDevice,
            UInt32 dwIoControlCode,
            IntPtr lpInBuffer,
            UInt32 nInBufferSize,
            IntPtr lpOutBuffer,
            UInt32 nOutBufferSize,
            [Out]out UInt32 lpBytesReturned,
            IntPtr lpOverlapped);
    }
}
