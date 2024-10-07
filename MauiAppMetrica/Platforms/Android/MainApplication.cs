using Android.App;
using Android.Runtime;
using IO.Appmetrica.Analytics;

namespace MauiAppMetrica
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }


        public override void OnCreate()
        {
            base.OnCreate();

            // appmetrica activation
            //MainThread.BeginInvokeOnMainThread(() =>
            {
                if (IsMainProcess())
                {
                    var config = AppMetricaConfig
                    .NewConfigBuilder("put you APIKEY here")
                    .WithCrashReporting(true)
                    .WithLogs()
                    .WithNativeCrashReporting(true)
                    .Build();
                    AppMetrica.Activate(this, config);
                }
                //});
            }
        }        

        private bool IsMainProcess()
        {
            int pid = Android.OS.Process.MyPid();
            ActivityManager manager = (ActivityManager)GetSystemService(ActivityService);
            foreach (ActivityManager.RunningAppProcessInfo processInfo in manager.RunningAppProcesses)
            {
                if (processInfo.Pid == pid)
                {
                    return processInfo.ProcessName == PackageName;
                }
            }
            return false;
        }


        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
