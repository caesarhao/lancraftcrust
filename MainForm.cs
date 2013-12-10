/*
 * Created by SharpDevelop.
 * User: SereneG
 * Date: 2013/12/10
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace lancraftcrust
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private const int SWP_NOOWNERZORDER = 0x200;
        private const int SWP_NOREDRAW = 0x8;
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int WS_EX_MDICHILD = 0x40;
        private const int SWP_FRAMECHANGED = 0x20;
        private const int SWP_NOACTIVATE = 0x10;
        private const int SWP_ASYNCWINDOWPOS = 0x4000;
        private const int SWP_NOMOVE = 0x2;
        private const int SWP_NOSIZE = 0x1;
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;
        private const int WS_CHILD = 0x40000000;

        private const int  SW_HIDE            = 0; //{隐藏, 并且任务栏也没有最小化图标}
        private const int  SW_SHOWNORMAL      = 1; //{用最近的大小和位置显示, 激活}
        private const int  SW_NORMAL          = 1; //{同 SW_SHOWNORMAL}
        private const int  SW_SHOWMINIMIZED   = 2; //{最小化, 激活}
        private const int  SW_SHOWMAXIMIZED   = 3; //{最大化, 激活}
        private const int  SW_MAXIMIZE        = 3; //{同 SW_SHOWMAXIMIZED}
        private const int  SW_SHOWNOACTIVATE  = 4; //{用最近的大小和位置显示, 不激活}
        private const int  SW_SHOW            = 5; //{同 SW_SHOWNORMAL}
        private const int  SW_MINIMIZE        = 6; //{最小化, 不激活}
        private const int  SW_SHOWMINNOACTIVE = 7; //{同 SW_MINIMIZE}
        private const int  SW_SHOWNA          = 8; //{同 SW_SHOWNOACTIVATE}
        private const int  SW_RESTORE         = 9; //{同 SW_SHOWNORMAL}
        private const int  SW_SHOWDEFAULT     = 10; //{同 SW_SHOWNORMAL}
        private const int  SW_MAX             = 10; //{同 SW_SHOWNORMAL}
        
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
 
		[DllImport("User32.dll", EntryPoint = "SendMessage")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
 
		[DllImport("User32.dll ")]
		public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr childe, string strclass, string FrmText);

		[DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true,
             CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern long GetWindowLong(IntPtr hwnd, int nIndex);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr32(IntPtr hWnd, int nIndex, int dwNewLong);
        
        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, int dwNewLong);
 
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, uint wParam, uint lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetParent(IntPtr hwnd);
        
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
		const int WM_SETTEXT = 0x000C;
		
		const string LancraftName = "lancraft.exe";
		
		const string ConfFile = "lancraftcrust.ini";
		
		private lancraftcrust.Configure conf;
		
		private System.Diagnostics.Process pLancraft;
		
		private System.IntPtr hLancraft;
		
		private System.IntPtr heditPort;
		
		private System.IntPtr heditIp;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			conf = new Configure(ConfFile);
			
			// create the inform.
			pLancraft = Process.Start(LancraftName);
			if (null == pLancraft){
				this.Dispose();
				return;
			}
			pLancraft.WaitForInputIdle();
			
			hLancraft = FindWindow(null, "Lancraft 1.01b");
			SetParent(hLancraft, this.pnlCraft.Handle);
			SetWindowLong(hLancraft, GWL_STYLE, WS_VISIBLE);
			MoveWindow(hLancraft, 0, 0, this.pnlCraft.Width, this.pnlCraft.Height, true);
			
			heditPort = FindWindowEx(hLancraft, IntPtr.Zero, "TEdit", null);
			heditIp = FindWindowEx(hLancraft, heditPort, "TEdit", null);
			//------------------------------------
			//load data into the list.
			foreach(string user in conf.getConf().Keys){
				listServer.Items.Add(user);
			}
			if (listServer.Items.Count > 0){
				listServer.SetSelected(0, true);
			}
		}
		
		protected override void OnHandleDestroyed(EventArgs e)
		{
		  // Stop the application
		  if (pLancraft != null)
		  {
		  	pLancraft.Kill();
		  }
		  base.OnHandleDestroyed (e);
		}
		void ListServerSelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (sender == this.listServer){
				string name = (string)listServer.SelectedItem;
				string ip = conf.getConf()[name];
				if (null != ip){
					SendMessage(heditIp, WM_SETTEXT, IntPtr.Zero, ip);
				}
			}
		}
		void LblBlogClick(object sender, System.EventArgs e)
		{
			Process.Start(this.lblBlog.Text);
		}
	}
}
