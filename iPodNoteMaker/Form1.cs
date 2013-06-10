using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace iPodNoteMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static Char Drive = '!';
        StreamReader SR;

        private void Note_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (Note.Text != "")
                {
                    e.Handled = true;
                    if(!Note.Text.Contains("ToDo:") && !Note.Text.Contains("Done:"))
                        Notes.Items.Insert(0,Note.Text);
                    Note.Text = "";
                }            
            }
        }
        private void Notes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46)
            {
                for (int i = 0; i < Notes.SelectedItems.Count; i++)
                {
                    Notes.SelectedItems[i].Remove();
                    i--;
                }
                WriteList();
            }else
                if(e.KeyValue == 113)
                    Notes.SelectedItems[0].BeginEdit();
                else
                    if (e.KeyValue == 87)//w
                    {
                        bool needsWrite = false;
                        for (int i = 0; i < Notes.SelectedItems.Count; i++)
                        {
                            ListViewItem abc = Notes.SelectedItems[i];
                            if (!abc.Checked && !needsWrite)
                                needsWrite = true;
                            if (abc.Index != 0)
                            {
                                if (Notes.Items[abc.Index - 1].Checked == abc.Checked)
                                {
                                    Notes.SelectedItems[i].Selected = false;
                                    int index = abc.Index;
                                    Notes.Items[abc.Index].Remove();
                                    abc.Tag = abc.Checked;
                                    Notes.Items.Insert(index - 1, abc);
                                    Notes.Items[index - 1].Tag = null;
                                    Notes.Items[index - 1].Selected = true;
                                }
                            }
                        }
                        if (needsWrite)
                            WriteList();
                    }else
                        if (e.KeyValue == 83)
                        {
                            bool needsWrite = false;
                            for (int i = Notes.SelectedItems.Count-1; i > -1; i--)
                            {
                                ListViewItem abc = Notes.SelectedItems[i];
                                if (!abc.Checked && !needsWrite)
                                    needsWrite = true;
                                if (abc.Index != Notes.Items.Count - 1)
                                {
                                    if (Notes.Items[abc.Index + 1].Checked == abc.Checked)
                                    {
                                        Notes.SelectedItems[i].Selected = false;
                                        int index = abc.Index;
                                        Notes.Items[abc.Index].Remove();
                                        abc.Tag = abc.Checked;
                                        Notes.Items.Insert(index + 1, abc);
                                        Notes.Items[index + 1].Tag = null;
                                        Notes.Items[index + 1].Selected = true;
                                    }
                                }
                            }
                            if (needsWrite)
                                WriteList();
                        }
            e.Handled = true;
        }
        private void Notes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (SR == null)
            {
                if (e.Item.Tag != null)
                    e.Item.Checked = ((bool)e.Item.Tag);

                if (!e.Item.Checked)
                {
                    if (e.Item.Index != 0)
                    {
                        e.Item.BackColor = Color.White;
                        ListViewItem abc = e.Item;
                        e.Item.Remove();
                        Notes.Items.Insert(0, abc);
                    }
                }
                else
                {
                    e.Item.BackColor = Color.WhiteSmoke;
                    Console.WriteLine(Notes.Sorting.ToString());
                    Notes.ListViewItemSorter = new ListViewItemComparer();
                    Notes.Sort();
                    Notes.ListViewItemSorter = null;
                }

                WriteList();
            }
        }

        private void WriteList()
        {
            File.Delete(Drive+":\\Notes\\ToDo.txt");
            bool Done = false;
            StreamWriter SW = File.CreateText(Drive+":\\Notes\\ToDo.txt");
            SW.WriteLine("<title>ToDo</title>ToDo:");
            for (int i = 0; i < Notes.Items.Count; i++)
            {
                if (!Done && Notes.Items[i].Checked)
                {
                    SW.WriteLine("\r\nDone:");
                    Done = true;
                }
                SW.WriteLine(Notes.Items[i].Text);
            }
            SW.Close();
        }
        class ListViewItemComparer : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                if (((ListViewItem)y).Index != -1)
                {
                    if (((ListViewItem)y).Checked)
                        return -1;
                    else
                         return 1;
                }
                return 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Detect the ipod.
            bool crash = true;
            for (int i = 65; i < 65+26; i++)
            {
                Drive = ((char)i);
                if (Directory.Exists(Drive + ":\\Notes"))
                {
                    crash = false;
                    break;
                }
            }
            if (crash)
            {
                MessageBox.Show("iPod not detected");
                Application.Exit();
            }
            else
            {
                SR = File.OpenText(Drive + ":\\Notes\\ToDo.txt");
                string line = "";
                bool ToDo = true;
                SR.ReadLine();
                while ((line = SR.ReadLine()) != null)
                {
                    if (line.Contains("Done:"))
                        ToDo = false;
                    else
                        if (line != "")
                            if (ToDo)
                            {
                                ListViewItem abc = new ListViewItem();
                                abc.Text = line;
                                abc.Checked = false;
                                Notes.Items.Add(abc);
                            }
                            else
                            {
                                ListViewItem abc = new ListViewItem();
                                abc.Text = line;
                                abc.Checked = true;
                                abc.BackColor = Color.WhiteSmoke;
                                Notes.Items.Add(abc);
                            }

                }
                SR.Close();
                SR = null;
                Notes.ListViewItemSorter = new ListViewItemComparer();
                Notes.Sort();
                Notes.ListViewItemSorter = null;
                Notes.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void Notes_SizeChanged(object sender, EventArgs e)
        {
            Notes.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void Notes_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            WriteList();
        }

        private void Notes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;

        }
        private void Note_Enter(object sender, EventArgs e)
        {
            Note.Text = "";
            Note.ForeColor = SystemColors.WindowText;
        }

        private void Note_Leave(object sender, EventArgs e)
        {
            Note.Text = "F2.rename  DEL.delete  W.up  S.down";
            Note.ForeColor = SystemColors.GrayText;
        }
    }
}