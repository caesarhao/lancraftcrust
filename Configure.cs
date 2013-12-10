/*
 * Created by SharpDevelop.
 * User: SereneG
 * Date: 2013/12/10
 * Time: 16:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lancraftcrust
{
	/// <summary>
	/// Description of Configure.
	/// </summary>
	
	public class Configure
	{
		protected string fConf;
		protected Dictionary<string, string> data;
		public Configure(string fileName)
		{	
			fConf = fileName;
			data = new Dictionary<string, string>();
			// if the file exists, read it.
			if (File.Exists(fConf)){
				readConf();
			}
			else{
				data.Add("浩叔", "172.16.126.137");
				data.Add("陈竟宇", "172.16.121.13");
				saveConf();
			}
		}
		
		public Dictionary<string, string> getConf(){
			return data;
		}
		
		public void addItem(string name, string ip){
			data.Add(name, ip);
		}
		
		public void removeItem(string name){
			data.Remove(name);
		}
		
		public void saveConf(){
			File.Delete(fConf);
			FileStream fs = File.OpenWrite(fConf);
			string str = "";
			foreach (string key in data.Keys){
				str = "";
				str += "["+key+"]=";
				str += data[key];
				str += "\r\n";
				byte [] bys =new UTF8Encoding().GetBytes(str);
				fs.Write(bys, 0, bys.Length);
			}
			fs.Flush();
			fs.Close();
		}
		
		public void readConf(){
			FileStream fs = File.OpenRead(fConf);
			data.Clear();
			StreamReader sr = new StreamReader(fs);
			string str;
			string splits = "[]=";
			while(null != (str = sr.ReadLine())){
				Match m = Regex.Match(str, @"^\[\b(\w+)\b\]=\b([\.\w]+)\b");
				if (m.Success){
					string[] tmp;
					tmp = str.Split(splits.ToCharArray());
					if(tmp.Length > 3){
						data.Add(tmp[1], tmp[3]);
					}
				}
			}
			sr.Close();
			fs.Close();
		}
	}
}
