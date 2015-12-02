using AppKit;
using Foundation;
using Sparkle;
using System;

namespace SparkleSample
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            var updater = SUUpdater.SharedUpdater;
            updater.FeedURL = new NSUrl();
            updater.AutomaticallyChecksForUpdates = true;
            updater.UpdateCheckInterval = TimeSpan.FromDays(1).TotalSeconds;
            updater.CheckForUpdates(this);
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}

