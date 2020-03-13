using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Calculator199
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText text;
        private Button recent;
        private Button ac, exp, demul, x;
        private Button bt7, bt8, bt9, mul;
        private Button bt4, bt5, bt6, sub;
        private Button bt1, bt2, bt3, add;
        private Button bt0, com, hook, opp;

        private int hooks = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            text = FindViewById<EditText>(Resource.Id.text_window);
            text.ShowSoftInputOnFocus = false;

            if (Intent.HasExtra("exp"))
            {
                text.Text = Intent.GetStringExtra("exp");
                text.SetSelection(text.Text.Length);
                hooks = Intent.GetIntExtra("hooks", 0);
            }

            recent = FindViewById<Button>(Resource.Id.button_recent);
            recent.Click += delegate (object sender, EventArgs e)
            {
                Intent intent = new Intent(this, typeof(RecentActivity));
                StartActivity(intent);
            };

            ac = FindViewById<Button>(Resource.Id.button_ac);
            ac.Click += delegate (object sender, EventArgs e)
            {
                text.Text = "";
                hooks = 0;
            };

            exp = FindViewById<Button>(Resource.Id.button_exp);
            exp.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    ChangeOperation();
                    int index = text.SelectionStart;
                    if (index != 0)
                    {
                        text.Text = text.Text.Insert(index, "^");
                        text.SetSelection(index + 1);
                    }
                }
            };

            demul = FindViewById<Button>(Resource.Id.button_demul);
            demul.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    ChangeOperation();
                    int index = text.SelectionStart;
                    if (index != 0)
                    {
                        text.Text = text.Text.Insert(index, "/");
                        text.SetSelection(index + 1);
                    }
                }
            };

            x = FindViewById<Button>(Resource.Id.button_x);
            x.Click += delegate (object sender, EventArgs e)
            {
                SymbolsControl();
                int index = text.SelectionStart;
                if (index > 0)
                {
                    if (text.Text[index - 1] == '(') hooks--;
                    if (text.Text[index - 1] == ')') hooks++;
                    text.Text = text.Text.Remove(index - 1, 1);
                    text.SetSelection(index - 1);
                }
            };

            bt7 = FindViewById<Button>(Resource.Id.button_7);
            bt7.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "7");
                    text.SetSelection(index + 1);
                }
            };

            bt8 = FindViewById<Button>(Resource.Id.button_8);
            bt8.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "8");
                    text.SetSelection(index + 1);
                }
            };

            bt9 = FindViewById<Button>(Resource.Id.button_9);
            bt9.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "9");
                    text.SetSelection(index + 1);
                }
            };

            mul = FindViewById<Button>(Resource.Id.button_mul);
            mul.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    ChangeOperation();
                    int index = text.SelectionStart;
                    if (index != 0)
                    {
                        text.Text = text.Text.Insert(index, "*");
                        text.SetSelection(index + 1);
                    }
                }
            };
            mul.LongClick += delegate (object sender, View.LongClickEventArgs e)
            {
                if (LengthControl())
                {
                    ChangeOperation();
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "!");
                    text.SetSelection(index + 1);
                }
            };


            bt4 = FindViewById<Button>(Resource.Id.button_4);
            bt4.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "4");
                    text.SetSelection(index + 1);
                }
            };

            bt5 = FindViewById<Button>(Resource.Id.button_5);
            bt5.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "5");
                    text.SetSelection(index + 1);
                }
            };

            bt6 = FindViewById<Button>(Resource.Id.button_6);
            bt6.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "6");
                    text.SetSelection(index + 1);
                }
            };

            sub = FindViewById<Button>(Resource.Id.button_sub);
            sub.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    if (!(index > 1 && text.Text[index - 1] == '-' && (text.Text[index - 2] == '+' || text.Text[index - 2] == '-'
                        || text.Text[index - 2] == '*' || text.Text[index - 2] == '/' || text.Text[index - 2] == '^')))
                    {
                        text.Text = text.Text.Insert(index, "-");
                        text.SetSelection(index + 1);
                    }
                }
            };

            bt1 = FindViewById<Button>(Resource.Id.button_1);
            bt1.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "1");
                    text.SetSelection(index + 1);
                }
            };

            bt2 = FindViewById<Button>(Resource.Id.button_2);
            bt2.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "2");
                    text.SetSelection(index + 1);
                }
            };

            bt3 = FindViewById<Button>(Resource.Id.button_3);
            bt3.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "3");
                    text.SetSelection(index + 1);
                }
            };

            add = FindViewById<Button>(Resource.Id.button_add);
            add.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    ChangeOperation();
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "+");
                    text.SetSelection(index + 1);
                }
            };

            bt0 = FindViewById<Button>(Resource.Id.button_0);
            bt0.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    text.Text = text.Text.Insert(index, "0");
                    text.SetSelection(index + 1);
                }
            };

            com = FindViewById<Button>(Resource.Id.button_com);
            com.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    if (index == 0 || text.Text[index - 1] == '+' || text.Text[index - 1] == '-' || text.Text[index - 1] == '*' || text.Text[index - 1] == '/'
                    || text.Text[index - 1] == '^' || text.Text[index - 1] == '(')
                    {
                        text.Text = text.Text.Insert(index, "0");
                        index++;
                    }
                    if (text.Text[index - 1] != ',')
                    {
                        text.Text = text.Text.Insert(index, ",");
                        text.SetSelection(index + 1);
                    }
                }
            };

            hook = FindViewById<Button>(Resource.Id.button_hook);
            hook.Click += delegate (object sender, EventArgs e)
            {
                if (LengthControl())
                {
                    int index = text.SelectionStart;
                    if (index == 0 || text.Text[index - 1] == '+' || text.Text[index - 1] == '-' || text.Text[index - 1] == '*' || text.Text[index - 1] == '/'
                        || text.Text[index - 1] == '^' || text.Text[index - 1] == '(')
                    {
                        text.Text = text.Text.Insert(index, "(");
                        text.SetSelection(index + 1);
                        hooks++;
                    }
                    else if (hooks == 0)
                    {
                        text.Text = text.Text.Insert(index, "*(");
                        text.SetSelection(index + 2);
                        hooks++;
                    }
                    else
                    {
                        text.Text = text.Text.Insert(index, ")");
                        text.SetSelection(index + 1);
                        hooks--;
                    }
                }
            };

            opp = FindViewById<Button>(Resource.Id.button_opp);
            opp.Click += delegate (object sender, EventArgs e)
            {
                SymbolsControl();
                string result = "";
                if (text.Text.Length != 0)
                {
                    result = Calculate(text.Text).ToString();
                    if (result == "" || result == GetString(Resource.String.not_a_number))
                    {
                        Toast.MakeText(this, Resource.String.expression_error, ToastLength.Short).Show();
                    }
                    else
                    {
                        if (result == GetString(Resource.String.infinity))
                        {
                            result = "∞";
                        }
                        else if (result == GetString(Resource.String.not_a_number))
                        {
                            result = "-∞";
                        }

                        if (!String.Equals(text.Text, result))
                        {
                            RecentLab lab = RecentLab.GetLab();
                            if (lab.list.Count() >= 30)
                            {
                                lab.list.RemoveAt(0);
                            }
                            lab.list.Add(new Note { left = text.Text, right = result, hooks = this.hooks });
                        }

                        text.Text = result;
                        text.SetSelection(result.Length);
                        hooks = 0;
                    }                 
                }
            };
        }

        protected string ChangeSigns(string exp)
        {
            string result = "";
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '-' && i != 0 && exp[i - 1] != '-') result += '+';
                else if (exp[i] == '+') result += '-';
                else result += exp[i];
            }
            return result;
        }

        protected double? Calculate(string exp)
        {
            try
            {
                Dictionary<int, char> symbols = new Dictionary<int, char>();
                for (int i = 0; i < exp.Length; i++)
                {
                    if (exp[i] == '+' || exp[i] == '-' || exp[i] == '*' || exp[i] == '/' || exp[i] == '^' || exp[i] == '(' || exp[i] == ')' 
                        || exp[i] == '!') symbols.Add(i, exp[i]);
                }
                // Проверка скобок ...
                {
                    int left = symbols.Where(s => s.Value == '(').Count(), right = symbols.Where(s => s.Value == ')').Count();
                    if (left != right)
                    {
                        if (left > right)
                        {
                            for (int i = 0; i < left - right; i++)
                            {
                                exp = exp.Insert(exp.Length, ")");
                                symbols.Add(exp.Length - 1, ')');
                            }
                            Toast.MakeText(this, Resource.String.missing_hooks, ToastLength.Short).Show();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                // ... Проверка скобок
                foreach (var d in symbols.Where(s => s.Value == '('))
                {
                    int index = d.Key + 1, count = 0, nested = 0;
                    while (index < exp.Length && (exp[index] != ')' || nested != 0) && index != symbols.Where(s => s.Value == '(').ElementAt(symbols.Where(s => s.Value == '(').Count() - 1).Key + 1)
                    {
                        if (exp[index] == '(')
                        {
                            count++;
                            nested++;
                        }
                        if (exp[index] == ')')
                        {
                            nested--;
                        }
                        index++;
                    }
                    int secIndex = symbols.Where(s => s.Value == ')').ElementAt(count).Key;
                    string result = Calculate(exp.Substring(d.Key + 1, secIndex - d.Key - 1)).ToString();
                    exp = exp.Replace(exp.Substring(d.Key, secIndex - d.Key + 1), result);
                    return Calculate(exp);
                }
                foreach (var d in symbols.Where(s => s.Value == '+'))
                {
                    int index = d.Key;
                    if (index != 0 && exp[index - 1] != '+' && exp[index - 1] != '-' && exp[index - 1] != '*'
                        && exp[index - 1] != '/' && exp[index - 1] != '^' && exp[d.Key - 1] != '(' && exp[d.Key - 1] != 'E')
                    {
                        return Calculate(exp.Substring(0, index)) + Calculate(exp.Substring(index + 1, exp.Length - index - 1));
                    }
                }
                foreach (var d in symbols.Where(s => s.Value == '-'))
                {
                    int index = d.Key;
                    if (index != 0 && exp[index - 1] != '+' && exp[index - 1] != '-' && exp[index - 1] != '*'
                        && exp[index - 1] != '/' && exp[index - 1] != '^' && exp[d.Key - 1] != '(' && exp[d.Key - 1] != 'E')
                    {
                        return Calculate(exp.Substring(0, index)) - Calculate((index != exp.Length - 1 && exp[index + 1] == '-') ? exp.Substring(index + 1, exp.Length - index - 1) : ChangeSigns(exp.Substring(index + 1, exp.Length - index - 1)));
                    }
                }
                foreach (var d in symbols.Where(s => s.Value == '*'))
                {
                    int index = d.Key;
                    return Calculate(exp.Substring(0, index)) * Calculate(exp.Substring(index + 1, exp.Length - index - 1));
                }
                foreach (var d in symbols.Where(s => s.Value == '/'))
                {
                    int index = d.Key;
                    return Calculate(exp.Substring(0, index)) / Calculate(exp.Substring(index + 1, exp.Length - index - 1));
                }
                foreach (var d in symbols.Where(s => s.Value == '^'))
                {
                    int index = d.Key;
                    return Math.Pow((double)Calculate(exp.Substring(0, index)), (double)Calculate(exp.Substring(index + 1, exp.Length - index - 1)));
                }
                foreach (var d in symbols.Where(s => s.Value == '!'))
                {
                    int index = d.Key;
                    double number = (double)Calculate(exp.Substring(0, index)), result = 1;
                    if (number < 0)
                    {
                        result *= -1;
                        number *= -1;
                    }
                    for (int i = 1; i <= number; i++)
                    {
                        result *= i;
                    }
                    return Calculate(exp.Replace(exp.Substring(0, index + 1), result.ToString()));
                }

                return double.Parse(exp);
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected bool LengthControl()
        {

            SymbolsControl();

            if (text.Text.Length > 91)
            {
                Toast.MakeText(this, Resource.String.length_toast, ToastLength.Short).Show();
                return false;
            }

            return true;
        }

        protected void SymbolsControl()
        {
            if (text.Text == "∞" || text.Text == "-∞")
            {
                text.Text = "";
                hooks = 0;
            }
        }

        protected void ChangeOperation()
        {
            int index = text.SelectionStart;
            for (int i = 0; i < 2; i++)
            {
                if (index > 0 && (text.Text[index - 1] == '+' || text.Text[index - 1] == '-'
                                || text.Text[index - 1] == '*' || text.Text[index - 1] == '/' || text.Text[index - 1] == '^'))
                {
                    text.Text = text.Text.Remove(index - 1, 1);
                    text.SetSelection(--index);
                }
                else
                {
                    return;
                }
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutString("text", text.Text);
            outState.PutInt("selection", text.SelectionStart);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            text.Text = savedInstanceState.GetString("text");
            text.SetSelection(savedInstanceState.GetInt("selection"));
        }
    }
}

