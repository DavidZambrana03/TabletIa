using Android.Content;
using Android.App;

namespace WhiteFlexo.Platforms.Android
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == Intent.ActionBootCompleted)
            {
                Intent launchIntent = new Intent(context, typeof(MainActivity));
                launchIntent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(launchIntent);
            }
        }
    }

}
