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
    class User
    {
        public int Score { get; set; }
        public String Name { get; set; }

        public User(String name, int score)
        {
            Name = name;
            Score = score;
        }

        public User() { }

        public override string ToString()
        {
            return Name + " " + Score;
        }

        public string GetName()
        {
            return Name;
        }
    }
}