namespace katalogMobilny
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterLabel.Text = $"Clicked {count} time";
            else
                CounterLabel.Text = $"Clicked {count} times";
            mikiprent.Source = "lazerdim.jpg";

            SemanticScreenReader.Announce(CounterLabel.Text);
        }


    }
}
