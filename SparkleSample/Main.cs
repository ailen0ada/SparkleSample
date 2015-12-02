using AppKit;
using System;
using System.IO;
using System.Reflection;
using ObjCRuntime;

namespace SparkleSample
{
    static class MainClass
    {
        static string GetCurrentExecutingDirectory()
        {
            string filePath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }

        static void Main(string[] args)
        {
            if (Dlfcn.dlopen(Path.Combine(GetCurrentExecutingDirectory(), "Sparkle.framework", "Sparkle"), 0) == IntPtr.Zero)
            {
                Console.Error.WriteLine("Unable to load the dynamic library.");
                Environment.Exit(1);
            }
            NSApplication.Init();
            NSApplication.Main(args);
        }
    }
}