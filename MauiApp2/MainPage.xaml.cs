namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnFotoBtnClicked(object sender, EventArgs e)
        {
            try
            {
                var foto = await MediaPicker.CapturePhotoAsync();
                if (foto != null) 
                {
                    var stream = await foto.OpenReadAsync();
                    await DisplayAlert("Sabelo", "Te sacaste la pic bro", "Vpi");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", "La camara no aguanta tanta facha", "Cerrar");
            }
        }

        private async void OnVideoBtnClicked(object sender, EventArgs e)
        {
            try
            {
                var video = await MediaPicker.CaptureVideoAsync();
                if (video != null)
                {
                    var stream = await video.OpenReadAsync();
                    await DisplayAlert("Si señor", "Basuuuura", "Sisi");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ERROR", "Ojo con lo que filmas sucio", "Cerrar");
            }
        }
    }

}
