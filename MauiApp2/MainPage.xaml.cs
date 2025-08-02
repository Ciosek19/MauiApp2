using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System.Threading.Tasks;

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

        private async void OnHuellaBtnClicked(object sender, EventArgs e)
        {
            // Huella para android
            var request = new AuthenticationRequestConfiguration("Cabezon", "Mete el dedo ahi");

            try
            {
                var result = await CrossFingerprint.Current.AuthenticateAsync(request);
                if (result.Authenticated)
                {
                    await DisplayAlert("Si señor", "So de la manada", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "Ni idea quien sos", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "Algo salio mal compa", "Cerrar");
            }
        }

        private async void OnUbicacionBtnClicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    await DisplayAlert("Ubicacion", $"Latitud: {location.Latitude}, Longitud: {location.Longitude}", "OK");
                }
                else
                {
                    await DisplayAlert("Ubicacion", "No se pudo obtener la ubicacion", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("ERROR", "No se pudo obtener la ubicacion", "OK");
                throw;
            }
        }
    }

}
