using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Utils
{
    public static class ProcessUtils
    {
        public static Process GetFNProcess()
        {
            for (; ; )
            {
                try
                {
                    var process = Process.GetProcessesByName("FortniteClient-Win64-Shipping")[0];
                    return process;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }
        public static Process GetEACProcess()
        {
            for (; ; )
            {
                try
                {
                    var process = Process.GetProcessesByName("FortniteClient-Win64-Shipping_EAC")[0];
                    return process;
                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }
        public static Process GetBEProcess()
        {
            for (; ; )
            {
                try
                {
                    var process = Process.GetProcessesByName("FortniteClient-Win64-Shipping_BE")[0];
                    return process;

                }
                catch
                {
                    Thread.Sleep(100);
                }
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

        [Flags]
        public enum ThreadAccess
        {
            TERMINATE = 1,
            SUSPEND_RESUME = 2,
            GET_CONTEXT = 8,
            SET_CONTEXT = 16,
            SET_INFORMATION = 32,
            QUERY_INFORMATION = 64,
            SET_THREAD_TOKEN = 128,
            IMPERSONATE = 256,
            DIRECT_IMPERSONATION = 512
        }

        [DllImport("kernel32.dll", CharSet = CharSet.None, ExactSpelling = false)]
        private static extern uint SuspendThread(IntPtr hThread);

        public static void Suspend(this Process process)
        {
            foreach (ProcessThread thread in (ReadOnlyCollectionBase)process.Threads)
            {
                IntPtr intPtr = OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
                if (intPtr == IntPtr.Zero)
                {
                    break;
                }
                else
                {
                    SuspendThread(intPtr);
                }
            }
        }
    }
}
