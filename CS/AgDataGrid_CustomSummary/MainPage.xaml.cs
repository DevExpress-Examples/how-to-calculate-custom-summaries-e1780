using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Data;

namespace AgDataGrid_CustomSummary {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
        }

        double totalPrice;
        private void grid_CustomSummary(object sender, DevExpress.Data.CustomSummaryEventArgs e) {
            if (e.SummaryProcess == CustomSummaryProcess.Start)
                totalPrice = 0;
            if (e.SummaryProcess == CustomSummaryProcess.Calculate) {
                double price = (double)e.FieldValue;
                int quantity = (int)e.GetValue("Quantity");
                totalPrice += price * quantity;
                e.TotalValue = totalPrice;
            }
        }
    }
}
