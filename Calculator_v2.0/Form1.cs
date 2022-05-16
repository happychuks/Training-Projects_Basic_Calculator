using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_v2._0
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operand   = "";
        bool isOperationPerformed = false;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //to copy display content to clipboard
            if (string.IsNullOrWhiteSpace(txtDisplay.Text)) return;
            Clipboard.SetText(txtDisplay.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            txtDisplay.Text = "0";
            resultValue = 0;

        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            
            if (txtDisplay.Text.Length > 0)
            {
                                
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }
            if (txtDisplay.Text == "0")
            {
                txtDisplay.Text = "";
            }
        }
        

        private void btn1_Click(object sender, EventArgs e)
        {
            //to clear the default 0 whenever a button is pressed
            //also to clear text when an operand is performed

            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();
                isOperationPerformed = false;

            //this is the button action
            Button bttn = (Button)sender;
            if (bttn.Text == ".") //to format the decimal so it doesnt show everytime
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + bttn.Text;

            }
            else
                txtDisplay.Text = txtDisplay.Text + bttn.Text;
        }

        private void operand_click(object sender, EventArgs e)
        {
            //this is the button action
            Button bttn = (Button)sender;
            if (resultValue != 0)
            {
                btnEql.PerformClick();
                operand = bttn.Text;
                txtDisplayLabel.Text = resultValue + " " + operand;
                isOperationPerformed = true;
            }
            else
            {
                operand = bttn.Text;
                resultValue = Double.Parse(txtDisplay.Text);
                
                txtDisplayLabel.Text = resultValue + " " + operand;
                isOperationPerformed = true;
            }

        }

        private void btnEql_Click(object sender, EventArgs e)
        {
            switch (operand)
            {
                case "+":
                    txtDisplay.Text = (resultValue + Double.Parse(txtDisplay.Text)).ToString();
                    break;

                case "-":
                    txtDisplay.Text = (resultValue - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (resultValue / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                //case "%":
                //    txtDisplay.Text = (resultValue + Double.Parse(txtDisplay.Text)).ToString();
                //    break;
                default: 
                    break;  
            }
            resultValue = Double.Parse(txtDisplay.Text);
            txtDisplayLabel.Text = "";
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
