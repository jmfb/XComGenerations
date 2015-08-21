using System;
using System.Drawing;
using System.Windows.Forms;
using SharpGL;
using XCom.Graphics;

namespace XCom
{
	public partial class MainForm : Form
	{
		private readonly GraphicsBuffer graphicsBuffer = new GraphicsBuffer();
		private const int scaleFactor = 3;

		public MainForm()
		{
			InitializeComponent();
			Cursor.Hide();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Application.Idle += OnIdle;
			GameState.Current.OnQuit += Close;
			GameState.Current.SetPointerPositionFunction(() => PointerPosition);
		}

		private void OnIdle(object sender, EventArgs e)
		{
			GameState.Current.Idle();
			openGlControl.DoRender();
		}

		private void openGlControl_OpenGLInitialized(object sender, EventArgs e)
		{
			var gl = openGlControl.OpenGL;
			gl.PixelStore(OpenGL.GL_PACK_ALIGNMENT, 1);
			gl.PixelStore(OpenGL.GL_UNPACK_ALIGNMENT, 1);
		}

		private void openGlControl_OpenGLDraw(object sender, RenderEventArgs args)
		{
			var gl = openGlControl.OpenGL;
			graphicsBuffer.Clear();
			GameState.Current.Render(graphicsBuffer);
			RenderPointer();
			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
			gl.RasterPos(0, 0);
			gl.PixelZoom(scaleFactor, scaleFactor);
			gl.DrawPixels(
				GraphicsBuffer.GameWidth,
				GraphicsBuffer.GameHeight,
				OpenGL.GL_RGB,
				graphicsBuffer.Buffer);
			gl.Flush();
		}

		private Point PointerPosition
		{
			get
			{
				var mousePosition = PointToClient(MousePosition);
				var topRow = mousePosition.Y / scaleFactor;
				var leftColumn = mousePosition.X / scaleFactor;
				return new Point(leftColumn, topRow);
			}
		}

		private void RenderPointer()
		{
			var pointerPosition = PointerPosition;
			Pointer.Render(pointerPosition.Y, pointerPosition.X, graphicsBuffer);
		}

		private void openGlControl_Resized(object sender, EventArgs e)
		{
			var gl = openGlControl.OpenGL;
			gl.Viewport(0, 0, Width, Height);
			gl.LoadIdentity();
			gl.Ortho(0, GraphicsBuffer.GameWidth, 0, GraphicsBuffer.GameHeight, 1, -1);
		}

		private void openGlControl_KeyPress(object sender, KeyPressEventArgs e)
		{
			GameState.Current.Dispatcher.OnKeyPressed(e.KeyChar);
		}

		private void openGlControl_MouseMove(object sender, MouseEventArgs e)
		{
			var row = e.Y / scaleFactor;
			var column = e.X / scaleFactor;
			var leftButton = e.Button == MouseButtons.Left;
			var rightButton = e.Button == MouseButtons.Right;
			GameState.Current.Dispatcher.OnMouseMove(row, column, leftButton, rightButton);
		}

		private void openGlControl_MouseDown(object sender, MouseEventArgs e)
		{
			var row = e.Y / scaleFactor;
			var column = e.X / scaleFactor;
			switch (e.Button)
			{
			case MouseButtons.Left:
				GameState.Current.Dispatcher.OnLeftButtonDown(row, column);
				break;
			case MouseButtons.Right:
				GameState.Current.Dispatcher.OnRightButtonDown(row, column);
				break;
			}
		}

		private void openGlControl_MouseUp(object sender, MouseEventArgs e)
		{
			var row = e.Y / scaleFactor;
			var column = e.X / scaleFactor;
			switch (e.Button)
			{
			case MouseButtons.Left:
				GameState.Current.Dispatcher.OnLeftButtonUp(row, column);
				break;
			case MouseButtons.Right:
				GameState.Current.Dispatcher.OnRightButtonUp(row, column);
				break;
			}
		}
	}
}
