using Android.App;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using Android.Content.PM;
using Android.Views;

namespace Epic_Click_Game
{
    [Activity(Label = "Epic_Click_Game", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        private int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.button1);
            Button StopButton = FindViewById<Button>(Resource.Id.button2);

            // Main Click Button to Run the Game
            button.Click += delegate { button.Text = string.Format("{0} clicks. Keep Going!", count++); };

            // Button Used to Save Score and Quit
            StopButton.Click += delegate 
            {
                AddNewUser(Login.PlayerName, count);
                StartActivity(typeof(Login));
            };

            DisplayTopFiveUsers();
            
        }

        // Adds Another User to the Database
        public void AddNewUser(string name, int score)
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();
            User userTemp = new User(name, score);
            db.Insert(userTemp);
        }

        // Runs the Logic for the High Scores List
        public void DisplayTopFiveUsers()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbTest.db3");
            var db = new SQLiteConnection(dbPath);
            TextView displayText = FindViewById<TextView>(Resource.Id.ThisTextView1);
            var table = db.Table<User>();

            int score1 = 0;
            string name1 = null;
            int score2 = 0;
            string name2 = null;
            int score3 = 0;
            string name3 = null;
            int score4 = 0;
            string name4 = null;
            int score5 = 0;
            string name5 = null;

            for (int i = 0; i < 5; i++)
            {
                foreach (var item in table)
                {
                    if (item.Score > score1 && item.Score > score2 && item.Score > score3 && item.Score > score4 && item.Score > score5)
                    {
                        score1 = item.Score;
                        name1 = item.Name;
                    }
                    else if (score1 > item.Score && item.Score > score2 && item.Score > score3 && item.Score > score4 && item.Score > score5)
                    {
                        score2 = item.Score;
                        name2 = item.Name;
                    }
                    else if (score1 > item.Score && score2 > item.Score && item.Score > score3 && item.Score > score4 && item.Score > score5)
                    {
                        score3 = item.Score;
                        name3 = item.Name;
                    }
                    else if (score1 > item.Score && score2 > item.Score && score3 > item.Score && item.Score > score4 && item.Score > score5)
                    {
                        score4 = item.Score;
                        name4 = item.Name;
                    }
                    else if (score1 > item.Score && score2 > item.Score && score3 > item.Score && score4 > item.Score && item.Score > score5)
                    {
                        score5 = item.Score;
                        name5 = item.Name;
                    }
                }
            }

            User user1 = new User(name1, score1);
            displayText.Text += user1 + "\n\n";
            User user2 = new User(name2, score2);
            displayText.Text += user2 + "\n\n";
            User user3 = new User(name3, score3);
            displayText.Text += user3 + "\n\n";
            User user4 = new User(name4, score4);
            displayText.Text += user4 + "\n\n";
            User user5 = new User(name5, score5);
            displayText.Text += user5 + "\n\n";

        }
    }
}

