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

namespace Calculator199
{
    public struct Note
    {
        public string left, right;
        public int hooks;
    }

    public class RecentLab
    {
        private static RecentLab link;
        public List<Note> list;

        private RecentLab()
        {
            list = new List<Note>();
        }

        public static RecentLab GetLab()
        {
            if(link == null)
            {
                link = new RecentLab();
            }
            return link;
        }
    }
}