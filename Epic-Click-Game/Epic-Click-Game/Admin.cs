using Android.App;
using Android.OS;
using Android.Widget;
using SQLite;
using System.IO;
using Android.Content.PM;

namespace Epic_Click_Game
{
    [Activity(Label = "Admin Page", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Admin : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Admin);

            // Sets up Database
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();
            TextView displayText = FindViewById<TextView>(Resource.Id.currentDatabaseList);
            var table = db.Table<User>();

            // Populates TextView with All of the Database Entries
            foreach (var item in table)
            {
                User myUser = new User(item.Name, item.Score);
                displayText.Text += myUser + "\n";
            }

            // Displays a Message if the Table is Empty
            if (table.Count() < 1)
            {
                displayText.Text = "No Entries Available";
            }
            
            // Button used to Clear Database
            Button clearButton = FindViewById<Button>(Resource.Id.clearButton);
            clearButton.Click += delegate
            {
                ClearDatabase();
                this.Recreate();
            };

        }

        // Wipes the Databases and Resets High Score List
        public void ClearDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
            var db = new SQLiteConnection(dbPath);
            db.DeleteAll<User>();
        }

    }
}