/*
 * Created by SharpDevelop.
 * User: SereneG
 * Date: 2013/12/10
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace lancraftcrust
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label lblBlog;
		private System.Windows.Forms.ListBox listServer;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Panel pnlCraft;
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pnlCraft = new System.Windows.Forms.Panel();
			this.listServer = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lblBlog = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pnlCraft
			// 
			this.pnlCraft.Location = new System.Drawing.Point(1, 0);
			this.pnlCraft.Name = "pnlCraft";
			this.pnlCraft.Size = new System.Drawing.Size(496, 359);
			this.pnlCraft.TabIndex = 0;
			// 
			// listServer
			// 
			this.listServer.FormattingEnabled = true;
			this.listServer.ItemHeight = 12;
			this.listServer.Location = new System.Drawing.Point(534, 58);
			this.listServer.Name = "listServer";
			this.listServer.Size = new System.Drawing.Size(156, 148);
			this.listServer.TabIndex = 1;
			this.listServer.SelectedIndexChanged += new System.EventHandler(this.ListServerSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(534, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(156, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Choose the server";
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(503, 254);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(208, 63);
			this.textBox1.TabIndex = 3;
			this.textBox1.Text = "ZHANG Hao writes for lancraft.\r\n2013-12-10";
			// 
			// lblBlog
			// 
			this.lblBlog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBlog.ForeColor = System.Drawing.Color.Blue;
			this.lblBlog.Location = new System.Drawing.Point(504, 324);
			this.lblBlog.Name = "lblBlog";
			this.lblBlog.Size = new System.Drawing.Size(207, 23);
			this.lblBlog.TabIndex = 4;
			this.lblBlog.Text = "http://caesarhao.blog.com";
			this.lblBlog.Click += new System.EventHandler(this.LblBlogClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(723, 359);
			this.Controls.Add(this.lblBlog);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listServer);
			this.Controls.Add(this.pnlCraft);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "lancraftcrust";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		
	}
}
