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

namespace Epic_Click_Game
{
    [Activity(Label = "Login", MainLauncher = true, Icon = "@drawable/icon")]
    public class Login : Activity
    {
        public static string playerName { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            EditText name = FindViewById<EditText>(Resource.Id.nameEdit);
            Button startButton = FindViewById<Button>(Resource.Id.startButton);

            startButton.Click += delegate 
            {
                playerName = name.Text;
                if( playerName == "admin")
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