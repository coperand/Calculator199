using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Calculator199
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class RecentActivity : AppCompatActivity
    {       
        private RecyclerView recycle;
        private RecentAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_recent);

            recycle = FindViewById<RecyclerView>(Resource.Id.rec_list);
            recycle.SetLayoutManager(new LinearLayoutManager(this));

            DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(recycle.Context, DividerItemDecoration.Vertical);
            recycle.AddItemDecoration(dividerItemDecoration);

            RecentLab lab = RecentLab.GetLab();
            List<Note> list = lab.list;
            adapter = new RecentAdapter(list);
            recycle.SetAdapter(adapter);
            recycle.ScrollToPosition(list.Count() - 1);
        }

        public class RecentHolder : RecyclerView.ViewHolder
        {
            private Note note;
            private TextView text;

            public RecentHolder(View itemView) : base(itemView)
            {
                itemView.Click += delegate (object sender, EventArgs e) 
                {
                    Intent intent = new Intent(itemView.Context, typeof(MainActivity));
                    intent.AddFlags(ActivityFlags.ClearTop);
                    intent.PutExtra("exp", note.left);
                    intent.PutExtra("hooks", note.hooks);
                    itemView.Context.StartActivity(intent);
                };
                text = itemView.FindViewById<TextView>(Resource.Id.item_text_view);
            }

            public void BindNote(Note note)
            {
                this.note = note;
                text.Text = note.left + "=" + note.right;
            }
        }

        public class RecentAdapter : RecyclerView.Adapter
        {
            private List<Note> notes;

            public RecentAdapter(List<Note> notes)
            {
                this.notes = notes;
            }

            public override int ItemCount => notes.Count();

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                LayoutInflater layoutInflater = LayoutInflater.From(parent.Context);
                View v = layoutInflater.Inflate(Resource.Layout.list_item_recent, parent, false);

                return new RecentHolder(v);
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                RecentHolder rh = holder as RecentHolder;

                Note note = notes.ElementAt(position);
                rh.BindNote(note);
            }
        }
    }
}