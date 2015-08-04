namespace XCom
{
	partial class MainForm
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
			this.openGlControl = new SharpGL.OpenGLControl();
			((System.ComponentModel.ISupportInitialize)(this.openGlControl)).BeginInit();
			this.SuspendLayout();
			// 
			// openGlControl
			// 
			this.openGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.openGlControl.DrawFPS = false;
			this.openGlControl.FrameRate = 60;
			this.openGlControl.Location = new System.Drawing.Point(0, 0);
			this.openGlControl.Name = "openGlControl";
			this.openGlControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
			this.openGlControl.RenderContextType = SharpGL.RenderContextType.FBO;
			this.openGlControl.RenderTrigger = SharpGL.RenderTrigger.Manual;
			this.openGlControl.Size = new System.Drawing.Size(960, 600);
			this.openGlControl.TabIndex = 0;
			this.openGlControl.OpenGLInitialized += new System.EventHandler(this.openGlControl_OpenGLInitialized);
			this.openGlControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGlControl_OpenGLDraw);
			this.openGlControl.Resized += new System.EventHandler(this.openGlControl_Resized);
			this.openGlControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.openGlControl_KeyPress);
			this.openGlControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGlControl_MouseDown);
			this.openGlControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGlControl_MouseMove);
			this.openGlControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGlControl_MouseUp);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 600);
			this.Controls.Add(this.openGlControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "X-Com Generations";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.openGlControl)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private SharpGL.OpenGLControl openGlControl;
	}
}

