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
using System.Threading;

namespace Async_and_Await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int CountCharacters()
        {
            int count = 0;
            using (StreamReader reader = new StreamReader("C:\\Users\\Teedo\\Desktop\\data.txt")) //addd your path here
            {
                string content = reader.ReadToEnd();
                count = content.Length;
                Thread.Sleep(5000);
            }

            return count;
        }
        private async void buttonProcess_Click(object sender, EventArgs e)
        {
            Task<int> task = new Task<int>(CountCharacters); //unit of work
            task.Start(); //offload the method to this task 


            labelMsg.Text = "Processing, Please wait...";
            int count = await task;
            labelMsg.Text = count.ToString() + " characters in file";
        }
    }
}
