using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private string firstOperand, secondOperand, thiedOperand;
        private string operate;
        private string currenttext;
        private bool operacheck;
        private bool modcheck;
        private string [] memberlist = new string [100];
        private int mslist = 0;
        private int num = 0,mum=0;
        private string operatecurrent;
        CalculatorEngine engine = new CalculatorEngine();
        private bool plusss;



        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = true;
            isAfterEqual = false;
            modcheck = false;
            operacheck = true;
            plusss = true;
           
            firstOperand = lblDisplay.Text;
            num = 0;

        }
        public MainForm()
        {
            InitializeComponent();
            resetAll();
            plusss = true;
           
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            
            if (lblDisplay.Text is "Errors")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length is 8)
            {
                lblDisplay.Text = "Errors";
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
            hasDot = true;
            
            
            
            //secondOperand = lblDisplay.Text;
            //lblDisplay.Text = secondOperand;
            //clickdouble = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                   
                case "-":
                   
                case "X":
                    
                case "÷":
                    //string ummmmm = lblDisplay.Text;
                    num = 0;
                    if (plusss)
                    {
                    firstOperand = lblDisplay.Text;
                    operatecurrent = operate;
                    }
                    else
                    {
                        ///firstOperand = lblDisplay.Text;
                        //string ummmmm = lblDisplay.Text;
                        //if(plusss) 
                        
                        secondOperand = lblDisplay.Text;
                        if (operate != operatecurrent)
                        {
                            if (mum < 1)
                            {
                                firstOperand = engine.calculate(operatecurrent, firstOperand, secondOperand);
                                lblDisplay.Text = firstOperand;
                                plusss = true;
                                mum++;
                                //mum = 0;   
                            }
                            
                        }
                        else
                        {
                            firstOperand = engine.calculate(operate, firstOperand, secondOperand);
                            lblDisplay.Text = firstOperand;

                            plusss = true;
                        }
                       
                    }
                    operatecurrent = operate;
                    isAfterOperater = true;
                    plusss = false;
                    isAfterEqual = false;
                    operacheck = true;
                    num = 0;
                    break;
                

            }
           
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            
            isAllowBack = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            num = 0;
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (operacheck)
            {
               
                secondOperand = lblDisplay.Text;
                    
                
                
                string result = engine.calculate(operate, firstOperand, secondOperand);

                if (result is "E" || result.Length > 8)
                {
                 lblDisplay.Text = result;                
                    
                }
                else
                {
                    
                lblDisplay.Text = result;
                }
            }
            else
            {
                if ( currenttext.Length > 8)
                {
                    currenttext = currenttext.Substring(0, 8);
                    lblDisplay.Text = currenttext;
                }
                else
                {
                    lblDisplay.Text = currenttext;
                }
           
            }
            
             isAfterEqual = true;
             operacheck = true;
             //plusss = true;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if( hasDot && num<1)
            {
                lblDisplay.Text += ".";
                hasDot = false;
                num = 0;
            }num++;
           
            
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
      /*    if (isAfterEqual)
            {
                resetAll();
            }*/
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            }
            else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    hasDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            operacheck = false;
            if (lblDisplay.Text is "Error") 
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                double numsqrt;
                lblDisplay.Text = "Sqrt(" + current + ")";
                numsqrt  = Math.Sqrt(Convert.ToDouble(current));
                isAfterOperater = true;
                currenttext = numsqrt.ToString();
                if (currenttext.Length > 8)
                {
                    currenttext = currenttext.Substring(0, 8);
                    lblDisplay.Text = currenttext;
                }
                else
                {
                    lblDisplay.Text = currenttext;
                }
            }

        }

        private void overone_Click(object sender, EventArgs e)
        {
            operacheck = false;
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0") { 
                string current = lblDisplay.Text;
                double numsqrt;
                lblDisplay.Text = "1 /" + current;
                numsqrt = (1 / Convert.ToDouble(current));
                isAfterOperater = true;
                currenttext = numsqrt.ToString();
                if (currenttext.Length > 8)
                {
                    currenttext = currenttext.Substring(0, 8);
                    lblDisplay.Text = currenttext;
                }
                else
                {
                    lblDisplay.Text = currenttext;
                }
                
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int listremove = 0;
            while (listremove < 100)
            {
                memberlist[listremove] = "0";
                listremove++;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            memberlist[mslist - 1] = (Convert.ToDouble(memberlist[mslist - 1]) + Convert.ToDouble(lblDisplay.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(mslist != 0) lblDisplay.Text = memberlist[mslist-1];
           // lblDisplay.Text = "000000000";
        }
        private void button1_Click(object sender, EventArgs e)
        {
          memberlist[mslist - 1] = (Convert.ToDouble(memberlist[mslist - 1])- Convert.ToDouble (lblDisplay.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            memberlist[mslist] = lblDisplay.Text;
            mslist++;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            thiedOperand = lblDisplay.Text;
            //i do it claer
            if (Convert.ToDouble(thiedOperand) > 0 && Convert.ToDouble(thiedOperand) <= 100)
            {

                thiedOperand = ((Convert.ToDouble(thiedOperand) / 100) * Convert.ToDouble(firstOperand)).ToString();
                lblDisplay.Text = thiedOperand;
            }
            operacheck = true;
            modcheck = true;
            isAfterOperater = true;
        }

        private void btnMP_Click(object sender, EventArgs e)
        {

        }
    }
}
