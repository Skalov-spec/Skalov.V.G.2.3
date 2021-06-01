using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace UserFormsExample
{
	public partial class MainForm : Form
	{
		List<medecine> recordList;//cfvcgbcjr
		medecine currentRecord;//Поточний запис зі списку буде відображатись у формі 
		int totalRecords=0;
		int currentRecordIndex=-1;
		public MainForm()
		{
			InitializeComponent();
			recordList=new List<medecine>();
			
		}
		private void BindToForm()
		{
			personAge.Text=currentRecord.code.ToString();
			personFirstName.Text=currentRecord.name_of_drug;
			personName.Text=currentRecord.group;
			personLastName.Text=currentRecord.category;
		}
		private void BindToObject()
		{
			currentRecord.code = SByte.Parse(personAge.Text);
			currentRecord.name_of_drug = personFirstName.Text;
			currentRecord.group = personName.Text;
			currentRecord.category = personLastName.Text;
		}
		void AddRecordButtonClick(object sender, EventArgs e)
		{
			if(currentRecord!=null)
				BindToObject();
            totalRecords++;
            currentRecord=new medecine();
            BindToForm();
            recordList.Add(currentRecord);
            currentRecordIndex=totalRecords-1;
            totalObjects.Text=totalRecords.ToString();
		}
		void PreviousRecordbuttonClick(object sender, EventArgs e)
		{
			if(currentRecord!=null)
				BindToObject();
			if(currentRecordIndex>0)
		    {
				currentRecordIndex--;
                currentRecord=recordList[currentRecordIndex];
                BindToForm();
            }
		}

		void NextRecordButtonClick(object sender, EventArgs e)
		{
			if(currentRecord!=null)
				BindToObject();
            if(currentRecordIndex<totalRecords-1)
            {
            	currentRecordIndex++;
                currentRecord=recordList[currentRecordIndex];
                BindToForm();
            }
		}
		void SaveListButtonClick(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.DefaultExt = ".fw";
			saveFileDialog.Filter = "fw data file (*.fw) *fw|";
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
				StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
				streamWriter.Write(personFirstName.Text+""+ personLastName.Text+""+ personName.Text+""+ personAge.Text);
				streamWriter.Close();
            }
	
		}
	}
}
