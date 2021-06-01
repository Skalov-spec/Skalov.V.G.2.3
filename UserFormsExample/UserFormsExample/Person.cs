using System;
using System.IO;

namespace UserFormsExample
{
	public class medecine
	{
		public string name_of_drug { get;set;}		
		public string group { get;set;}
		public string category { get;set;}
		public sbyte code { get;set;}
		public medecine()
		{
			
		}
		
		public medecine(string nfg, string gr,string cate,sbyte cd)
		{
			name_of_drug = nfg;
			group = gr;
			category = cate;
			code = cd;
		}		
		
		public override string  ToString()
		{
			return name_of_drug + ' '+ group + ' '+ category + ' '+ code.ToString();
		}
		
		public void Write(BinaryWriter stream)
		{
			stream.Write(name_of_drug);
			stream.Write(group);
			stream.Write(category);
			stream.Write(code);
		}
		
		public void Read(BinaryReader stream)
		{
			name_of_drug = stream.ReadString();
			group = stream.ReadString();
			category = stream.ReadString();
			code = stream.ReadSByte();
			//stream.
		}		
		
	}
}
