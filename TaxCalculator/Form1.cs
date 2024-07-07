using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaxCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Code By: Patrick-Jnr Zulu
        //email: patrickjunior1010@gmail.com
        //Created to help people calculate their taxes with ease

        // Function to calculate tax payable
            private double CalculateTax(double salary, int age)
            {
                double taxAmount;
                double rebate;

                // Calculate tax amount based on salary using if-else statements
                if (salary <= 237100)
                {
                    taxAmount = salary * 0.18;
                }
                else if (salary <= 370500)
                {
                    taxAmount = 42678 + (salary - 237100) * 0.26;
                }
                else if (salary <= 512800)
                {
                    taxAmount = 77362 + (salary - 370500) * 0.31;
                }
                else if (salary <= 673000)
                {
                    taxAmount = 115762 + (salary - 512800) * 0.36;
                }
                else if (salary <= 857900)
                {
                    taxAmount = 173038 + (salary - 673000) * 0.39;
                }
                else if (salary <= 1817000)
                {
                    taxAmount = 245173 + (salary - 857900) * 0.41;
                }
                else
                {
                    taxAmount = 636765 + (salary - 1817000) * 0.45;
                }

                // Calculate rebate based on age
                if (age < 65)
                {
                    rebate = 17235;
                }
                else if (age < 75)
                {
                    rebate = 17235 + 9444;
                }
                else
                {
                    rebate = 17235 + 9444 + 3145;
                }

                // Calculate final tax payable
                double taxPayable = taxAmount - rebate;

                // Ensure tax payable is not negative
                return Math.Max(taxPayable, 0);
            }

            private void CalculateButton_Click(object sender, EventArgs e)
        {
            double salary;
            int age;

            // Get salary input from user
            if (!double.TryParse(salaryTextBox.Text, out salary) || salary <= 0)
            {
                MessageBox.Show("Please enter a valid salary amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get age input from user
            if (!int.TryParse(ageTextBox.Text, out age) || age <= 0 || age > 120)
            {
                MessageBox.Show("Please enter a valid age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate tax payable using the function
            double taxPayable = CalculateTax(salary, age);

            // Display result to user
            MessageBox.Show($"Tax payable for the 2024 tax year: R{taxPayable:N2}", "Tax Calculation Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
    }
    }
}
