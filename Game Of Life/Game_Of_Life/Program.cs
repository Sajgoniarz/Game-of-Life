using System;

namespace Game_Of_Life
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            var config = new Settings();

            using (Game1 game = config.WallpaperMode ? 
                                    new Game1(config, GetDesktopHandler()) : 
                                    new Game1(config))
            {
                game.Run();
            }
        }

        static IntPtr GetDesktopHandler()
        {
            IntPtr progman = W32.FindWindow("Progman", null);
            IntPtr workerw = IntPtr.Zero;
            IntPtr result = IntPtr.Zero;
            W32.SendMessageTimeout(progman,
                                   0x052C,
                                   new IntPtr(0),
                                   IntPtr.Zero,
                                   W32.SendMessageTimeoutFlags.SMTO_NORMAL,
                                   1000,
                                   out result);

            W32.EnumWindows(new W32.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                IntPtr p = W32.FindWindowEx(tophandle, IntPtr.Zero, "SHELLDLL_DefView", IntPtr.Zero);

                if (p != IntPtr.Zero)
                    workerw = W32.FindWindowEx(IntPtr.Zero, tophandle, "WorkerW", IntPtr.Zero);

                return true;
            }), IntPtr.Zero);

            return workerw;
        }
    }

#endif
}

