
namespace WindowsFormsApp8
{
	partial class Form19
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form19));
			this.wplayer = new AxWMPLib.AxWindowsMediaPlayer();
			((System.ComponentModel.ISupportInitialize)(this.wplayer)).BeginInit();
			this.SuspendLayout();
			// 
			// wplayer
			// 
			this.wplayer.Enabled = true;
			this.wplayer.Location = new System.Drawing.Point(0, -1);
			this.wplayer.Name = "wplayer";
			this.wplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wplayer.OcxState")));
			this.wplayer.Size = new System.Drawing.Size(800, 439);
			this.wplayer.TabIndex = 0;
			// 
			// Form19
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.wplayer);
			this.Name = "Form19";
			this.Text = "Form19";
			this.Load += new System.EventHandler(this.Form19_Load);
			((System.ComponentModel.ISupportInitialize)(this.wplayer)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private AxWMPLib.AxWindowsMediaPlayer wplayer;
	}
}