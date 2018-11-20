using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Firebase;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace DeepLinkingApp.Droid
{


    [Activity(Label = "DeepLinkingApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] {
            Intent.ActionView,
            Intent.CategoryDefault,
            Intent.CategoryBrowsable
        },
        DataScheme = "http",
        DataHost = "deeplinkingapp",
        DataPathPrefix = "/",
        AutoVerify = false
        )
    ]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            var options = new FirebaseOptions.Builder() // refer this from firebase JSON
                      .SetApplicationId("") // refer this from firebase JSON
                      .SetApiKey("") // refer this from firebase JSON
                      .SetDatabaseUrl("") // refer this from firebase JSON
                      .SetGcmSenderId("") // refer this from firebase JSON
                      .SetStorageBucket("") // refer this from firebase JSON
                      .Build();

            var apps = FirebaseApp.GetApps(this);
            if (apps.Count == 0)
            {
                FirebaseApp.InitializeApp(this, options);
            }
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            AndroidAppLinks.Init(this);
            LoadApplication(new App());
        }
    }
}