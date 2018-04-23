using System.Windows.Controls;

namespace AgDataGrid_CustomSummary {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
        }

        double totalPrice;
        private void grid_CustomSummary(object sender, DevExpress.AgData.CustomSummaryEventArgs e) {
            if (e.SummaryProcess == DevExpress.AgData.CustomSummaryProcess.Start)
                totalPrice = 0;
                if (e.SummaryProcess == DevExpress.AgData.CustomSummaryProcess.Calculate) {
                    double price = (double)e.FieldValue;
                    int quantity = (int)e.GetValue("Quantity");
                    totalPrice += price * quantity;
                    e.TotalValue = totalPrice;
                }
        }
    }
}
