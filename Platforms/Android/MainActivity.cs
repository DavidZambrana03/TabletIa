using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace WhiteFlexo.Platforms.Android
{

    [Activity(Theme = "@style/Maui.SplashTheme", LaunchMode = LaunchMode.SingleTask, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window?.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            EnterImmersiveMode();

            // Listen for UI visibility changes and reapply immersive mode
            Window.DecorView.SystemUiVisibilityChange += (sender, e) =>
            {
                if ((StatusBarVisibility)e.Visibility != (StatusBarVisibility)SystemUiFlags.ImmersiveSticky)
                {
                    EnterImmersiveMode();
                }
            };
        }
        private void EnterImmersiveMode()
        {
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                  SystemUiFlags.ImmersiveSticky
                | SystemUiFlags.Fullscreen
                | SystemUiFlags.HideNavigation
                | SystemUiFlags.LayoutFullscreen
                | SystemUiFlags.LayoutHideNavigation);
        }
    }
}