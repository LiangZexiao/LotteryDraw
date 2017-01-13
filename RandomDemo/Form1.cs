using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace RandomDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap("logo.jpg");
            pictureBox1.Image = image;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //读取原来记录
            ArrayList records = FileHelper.Read();

            int number = Convert.ToInt32(numericUpDown1.Value);
            int min = Convert.ToInt32(numericUpDown2.Value);
            int max = Convert.ToInt32(numericUpDown3.Value);

            int[] result = new int[number];
      
            //Random random = new Random();
            long tick = DateTime.Now.Ticks;
            Random random = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            //Hashtable table = new Hashtable();
           
            for (int i = 0; i < number; i++)
            {
                if(i==0)
                {
                    result[i] = random.Next(min, max);
                }
                else
                {
                    int temp = random.Next(min,max);
                    if(Array.IndexOf(result,temp) == -1 && records.IndexOf(temp)==-1)
                    {
                        result[i] = temp;
                    }
                    else
                    {
                        i--;
                    }
                }
            }

            /*
            Hashtable hashtable = new Hashtable();
            for (int i = 0; hashtable.Count < number;)
            {
                int nValue = random.Next(min,max);
                if (!hashtable.ContainsValue(nValue) && nValue != 0)
                {
                    hashtable.Add(i,nValue);
                    i++;
                    //Console.WriteLine(nValue.ToString());
                }
            }
            //hashtable.CopyTo(result, 0);
            for (int i = 0; i < number; i++)
            {
                result[i] = (int)hashtable[i];
            }*/
            Form2 form2 = new Form2();
            form2.ShowDialog();
            Result resultForm = new Result(result);
            resultForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

    }
}
