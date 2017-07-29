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
using SQLite;
using System.IO;
using Android.Database;
using Android.Content.PM;

namespace Epic_Click_Game
{
    [Activity(Label = "Admin", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Admin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Admin);

            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();
            TextView displayText = FindViewById<TextView>(Resource.Id.currentDatabaseList);
            var table = db.Table<User>();
            foreach (var item in table)
            {
                User myUser = new User(item.Name, item.Score);
                displayText.Text += myUser + "\n";
            }

            if (table.Count() < 1)
            {
                displayText.Text = "No Entries Available";
            }




            Button clearButton = FindViewById<Button>(Resource.Id.clearButton);
            clearButton.Click += delegate
            {
                ClearDatabase();
                this.Recreate();
            };

        }

        public void ClearDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
            var db = new SQLiteConnection(dbPath);
            db.DeleteAll<User>();
        }

    }
}