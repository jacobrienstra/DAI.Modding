using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DAI.ModMaker.DAI.ModMaker
{
    public class FrmException : Form
    {
        private IContainer components;

        private TextBox txtException;

        private Label label1;

        public FrmException()
        {
            InitializeComponent();
        }

        public FrmException(Exception ex, bool willExit = true)
            : this()
        {
            string message = "  Please copy the text below and send it to daimoddevteam@gmail.com along with a short description of how the error occured.  Thanks!";
            if (willExit)
            {
                label1.Text = "It seems the Mod Maker has crashed and will now close." + message;
            }
            else
            {
                label1.Text = "A background task has failed." + message;
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"DAIModMaker version:    {Application.ProductVersion}");
            builder.AppendLine($"Timestamp (UTC):        {DateTime.Now.ToUniversalTime()}");
            builder.AppendLine("");
            builder.AppendLine($"Exception message:      {ex.Message}");
            builder.AppendLine($"Source:                 {ex.Source}");
            builder.AppendLine($"Target:                 {ex.TargetSite.ToString()}");
            builder.AppendLine("");
            builder.AppendLine("StrackTrace:");
            builder.AppendLine(ex.StackTrace);
            txtException.Text = builder.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtException = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            txtException.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtException.BackColor = System.Drawing.Color.White;
            txtException.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtException.Location = new System.Drawing.Point(16, 91);
            txtException.Multiline = true;
            txtException.Name = "txtException";
            txtException.ReadOnly = true;
            txtException.Size = new System.Drawing.Size(648, 511);
            txtException.TabIndex = 1;
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(651, 75);
            label1.TabIndex = 2;
            label1.Text = "It seems the Mod Maker has crashed.  Please copy the text below and send it to daimoddevteam@gmail.com along with a short description of how the crash occured.  Thanks!";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(685, 614);
            base.Controls.Add(label1);
            base.Controls.Add(txtException);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            base.Name = "FrmException";
            Text = "Well... shit.";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
