using System;
using Foundation;
using AppKit;
using Sparkle;
using System.Globalization;

namespace SparkleSample
{
    public partial class MainWindowController : NSWindowController
    {
        public MainWindowController(IntPtr handle)
            : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder)
            : base(coder)
        {
        }

        public MainWindowController()
            : base("MainWindow")
        {
        }

        private static DateTime nsRef = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
            updater = new SUUpdater();
            updater.AutomaticallyChecksForUpdates = false;
            UpdateDateLabel();
        }

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }

        SUUpdater updater;

        partial void CheckUpdates(NSObject sender)
        {
            updater.CheckForUpdates(new NSObject());
            UpdateDateLabel();
        }

        void UpdateDateLabel()
        {
            var lastUpdated = nsRef.AddSeconds(updater.LastUpdateCheckDate?.SecondsSinceReferenceDate ?? 0);
            DateLabel.StringValue = TimeZoneInfo.ConvertTimeFromUtc(lastUpdated, TimeZoneInfo.Local).ToString("u");
        }
    }
}
