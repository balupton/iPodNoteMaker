namespace iPodNoteMaker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Note = new System.Windows.Forms.TextBox();
            this.Notes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // Note
            // 
            this.Note.Dock = System.Windows.Forms.DockStyle.Top;
            this.Note.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Note.Location = new System.Drawing.Point(0, 0);
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(219, 20);
            this.Note.TabIndex = 1;
            this.Note.Text = "F2.rename  DEL.delete  W.up  S.down";
            this.Note.Enter += new System.EventHandler(this.Note_Enter);
            this.Note.Leave += new System.EventHandler(this.Note_Leave);
            this.Note.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Note_KeyPress);
            // 
            // Notes
            // 
            this.Notes.AutoArrange = false;
            this.Notes.CheckBoxes = true;
            this.Notes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.Notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Notes.FullRowSelect = true;
            this.Notes.GridLines = true;
            this.Notes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.Notes.LabelEdit = true;
            this.Notes.LabelWrap = false;
            this.Notes.Location = new System.Drawing.Point(0, 20);
            this.Notes.Name = "Notes";
            this.Notes.ShowGroups = false;
            this.Notes.Size = new System.Drawing.Size(219, 222);
            this.Notes.TabIndex = 2;
            this.Notes.View = System.Windows.Forms.View.Details;
            this.Notes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.Notes_ItemChecked);
            this.Notes.SizeChanged += new System.EventHandler(this.Notes_SizeChanged);
            this.Notes.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.Notes_AfterLabelEdit);
            this.Notes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Notes_KeyPress);
            this.Notes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Notes_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Note";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 242);
            this.Controls.Add(this.Notes);
            this.Controls.Add(this.Note);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "iPod ToDo List - BALUPTON";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.ListView Notes;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}

