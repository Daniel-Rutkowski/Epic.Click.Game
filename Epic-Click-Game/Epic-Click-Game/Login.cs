using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace Epic_Click_Game
{
    [Activity(Label = "Epic Click Game", MainLauncher = true, Icon = "@drawable/AppIcon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Login : Activity
    {
        public static string PlayerName { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Login);
            EditText name = FindViewById<EditText>(Resource.Id.nameEdit);
            Button startButton = FindViewById<Button>(Resource.Id.startButton);

            // Sends a User to Main Activity or Admin Page if they insert "admin"
            startButton.Click += delegate 
            {
                PlayerName = name.Text;
                if(PlayerName == "admin")
                {
                    StartActivity(typeof(Admin));
                }else
                {
                    StartActivity(typeof(MainActivity));
                }
            };
        }
        
    }
    
}