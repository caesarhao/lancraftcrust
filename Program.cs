/*
 * Created by SharpDevelop.
 * User: SereneG
 * Date: 2013/12/10
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace lancraftcrust
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			// kill all lancrafts firstly.
			Process[] ps = Process.GetProcessesByName("lancraft");
			if (ps.Length > 0){
				foreach (Process p in ps){
					p.Kill();
				}
			}
			//---------------------------
			Application.Run(new MainForm());
		}
		
	}
}
