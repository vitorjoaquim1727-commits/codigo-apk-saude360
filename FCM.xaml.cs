namespace Saude360.NovaPasta;

public partial class FCM : ContentPage
{
	public FCM()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        if (!int.TryParse(txtIdeade.Text, out int idade))
        {
            DisplayAlert("Erro", "Digite uma idade válida.", "OK");
            return;
        }

        int fcm = 220 - idade;
        double leveMinimo = fcm * 0.50;
        double leveMaxima = fcm * 0.60;

        double moderadoMinimo = fcm * 0.75;

        string textoFinal = $"O ideal para a sua idade seria\nFrequencia leve {leveMinimo:F2} a {leveMaxima:F2} bpm\nFrequancia moderado {leveMaxima:F2} a {moderadoMinimo:F2} bpm" +
            $"Frequencia Máxima {moderadoMinimo:F2} a {fcm:F2} bpm";

        Resultado.Text = textoFinal;
    }

    private void btnLimpar_Clicked(object sender, EventArgs e)
    {
        txtIdeade.Text = null;
        Resultado.Text= null;
    }

    private async void btnStatus_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Status());
    }
}