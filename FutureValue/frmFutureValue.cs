using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Patrick McKee                      *
 * CIS123 - OOP                       *
 * May 16, 2022                       *
 * Ex. 7-2: Enhance Future Value app  */

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //try
            {
                if (!IsValidData())
                {
                    MessageBox.Show("Error. Invalid data.");
                }

                decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                int years = Convert.ToInt32(txtYears.Text);

                int months = years * 12;
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                decimal futureValue = this.CalculateFutureValue(
                    monthlyInvestment, monthlyInterestRate, months);
                txtFutureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();
            }
            /* Commenting the following out, in order to prevent additional error messages */
            //catch (OverflowException)
            //{
            //    MessageBox.Show("One of the entries is too large or too small.", "Overflow Error.");
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("A format error occurred. Check your entries.", "Entry Error!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, ex.GetType().ToString());
            //}
        }
        /* Patrick McKee
         * Ex. 7-2
         * The code below is for the error message that will present when triggered
         */
        private bool IsValidData()
        {
            bool IsValidData = true;
            string errorMessage = IsDecimal(txtMonthlyInvestment.Text, "Monthly investment");
            errorMessage += IsInt32(txtInterestRate.Text, "Monthly interest rate");
            errorMessage += IsInt32(txtYears.Text, "Number of years");
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage);
                IsValidData = false;
            }
            return IsValidData;
        }
        private decimal CalculateFutureValue(decimal monthlyInvestment,
            decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                            * (1 + monthlyInterestRate);
            }
            return futureValue;
        }
        /* Patrick McKee
         * Ex. 7-2
         * Below, I have created the validation methods that return for both decimal 
         * and integers. I wasn't entirely sure how to get the "withinrange" method
         * set up correctly. I left the code commented out for any feedback you might have.
         * It's the same code from the book, but I went about this with the help of a 
         * YouTube video and my code is pretty different from the actual solution. */
        private string IsDecimal(string value, string name)
        {
            string msg = "";
            if (!Decimal.TryParse(value, out _))
            {
                msg = name + " must be a valid decimal.\n";
            }
            return msg;
        }
        private string IsInt32(string value, string name)
        {
            string msg = "";
            if (!Int32.TryParse(value, out _))
            {
                msg = name + " must be a valid integer.\n";
            }
            return msg;
        }
        //private string IsWithinRange(string value, string name, decimal min, decimal max)
        //{
        //    string msg = "";
        //    if (Decimal.TryParse(value, out decimal number))
        //    {
        //        if (number < min || number > max)
        //        {
        //            msg += Name + " must be between " + min + " and " + max + ".\n";
        //        }
        //    }
        //    return msg;
        //}
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
