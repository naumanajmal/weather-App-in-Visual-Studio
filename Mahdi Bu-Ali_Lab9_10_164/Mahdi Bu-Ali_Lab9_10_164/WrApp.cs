using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//Mahdi Bu-Ali
//ECET 16400
namespace Mahdi_Bu_Ali_Lab11_164
{
    public partial class Form1 : Form
    {
        //structure for storing data
        public struct WeatherData
        {//variable declaration
            public DateTime date;
            public double precipitation;
            public double highTemp;
            public double lowTemp;
        }
        //list of structure
        List<WeatherData> weatherDataList = new List<WeatherData>();
        //object instance for structure
        WeatherData myDataStruct = new WeatherData();
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string line = "";//empty string for storing each line
            //try catch block
            try
            {
                //creating object of StramReader class
                StreamReader streamReader = new StreamReader("weather.txt");
                //while is used to read each line from the file
                while ((line = streamReader.ReadLine()) != null)
                {
                    //split line on every (;)
                    string[] tokens = line.Split(';');
                    //parsing each line and add it into structure
                    myDataStruct.date = DateTime.Parse(tokens[0]);
                    myDataStruct.precipitation = double.Parse(tokens[1]);
                    myDataStruct.highTemp = double.Parse(tokens[2]);
                    myDataStruct.lowTemp = double.Parse(tokens[3]);
                    //adding structure to list
                    weatherDataList.Add(myDataStruct);

                }
             streamReader.Close();//close the file
            }
            //catch exception
            catch (Exception ex)
            { //disply exception if any
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            //declarying variables
            int i = 0;
            bool date_Found = false;
            DateTime userSelected = dateTimePicker.Value;//date selected by user
            while ( (i < weatherDataList.Count) && (date_Found == false))//to check valid date 
            {
                var selecteddata = weatherDataList[i];  
                if (selecteddata.date == userSelected)//incase date found in list
                {
                    date_Found = true;//for breaking while loop
                    //display data in labels
                    dateLabel.Text = selecteddata.date.ToString("dd/MM/yyyy");
                    precipitationLabel.Text = selecteddata.precipitation.ToString("");
                    highTempLabel.Text = selecteddata.highTemp.ToString("");
                    lowTempLabel.Text = selecteddata.lowTemp.ToString("");
                }
                //increment value of i
                i++;
                
            }
            if (date_Found == false)//incase date is not found
            {
                //display empty labels
                dateLabel.Text = "";
                precipitationLabel.Text = "";
                highTempLabel.Text = "";
                lowTempLabel.Text = "";

            }

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();//close application
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            //display empty labels
            dateLabel.Text = "";
            precipitationLabel.Text = "";
            highTempLabel.Text = "";
            lowTempLabel.Text = "";
        }

        private void precipitationLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
