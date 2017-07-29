using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;

namespace Epic_Click_Game
{
    [Activity(Label = "Epic Click Game", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
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