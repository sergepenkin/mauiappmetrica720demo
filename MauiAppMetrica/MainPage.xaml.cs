using IO.Appmetrica.Analytics;

namespace MauiAppMetrica
{
    public partial class MainPage : ContentPage
    {        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            AppMetrica.ReportEvent("test_event");
        }
    }

}
