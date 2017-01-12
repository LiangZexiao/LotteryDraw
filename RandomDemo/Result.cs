using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RandomDemo
{
    public partial class Result : Form
    {

        int[] result;
        public Result(int[] Result)
        {
            InitializeComponent();
            result = Result;
            
          
        }

        private void Result_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < result.Length; i++)
            {
                listBox1.Items.Add(result[i].ToString());
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
