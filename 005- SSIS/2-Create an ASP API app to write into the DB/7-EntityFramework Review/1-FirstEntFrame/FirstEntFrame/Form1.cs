using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstEntFrame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PayablesEntities myPayables = new PayablesEntities();
            //A query expression that retrieves invoices over $500
            var highInvoices =
                from eachInvoice in myPayables.Invoices  // entity collection
                where eachInvoice.InvoiceTotal > 5000
                orderby eachInvoice.InvoiceTotal descending
                select new  // new collection
                {
                    eachInvoice.InvoiceNumber,
                    eachInvoice.InvoiceTotal,
                    eachInvoice.InvoiceDate,
                    eachInvoice.Vendor.City
                };

            // display results with ugly string building and a MessageBox
            string displayResult = "Inv No.\tInvoice Total\tDate\t\t\tCity\n";
            foreach (var invoice in highInvoices)
            {
                displayResult += invoice.InvoiceNumber + "\t" +
                    invoice.InvoiceTotal.ToString("c") + "\t\t" +
                    invoice.InvoiceDate.ToString() + "\t" + 
                      invoice.City.ToString() + "\n";
            }
            MessageBox.Show(displayResult, "Invoices Over $5000");

        }
    }
}
