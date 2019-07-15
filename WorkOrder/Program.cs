using oalib;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace WorkOrder
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int ShowWindow(int hwnd, int nCmdShow);

        //static NotifyIcon nf = new NotifyIcon();
        //static Mutex _syncObject;
        private static readonly string AppPatch = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        [STAThread]
        private static void Main()
        {
            bool crNew = true;
            using (Mutex mutex = new Mutex(true, "WorkOrder", out crNew))
            {
                if (crNew)
                {


                    Application.EnableVisualStyles();
                    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmRunLoad());
                    Application.Run(new Form1());
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    foreach (Process process in Process.GetProcessesByName(AppPatch))
                    {
                        if (process.Id != Process.GetCurrentProcess().Id)
                        {

                            ShowWindow((int)process.MainWindowHandle, 1);
                            SetForegroundWindow(process.MainWindowHandle);
                            //break;

                        }
                    }
                }
            }

        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            new Log(sender.ToString() + " (" + e.ExceptionObject.ToString() + ")");

        }
    }
}
