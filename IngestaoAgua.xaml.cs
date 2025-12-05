namespace Saude360.NovaPasta;

public partial class IngestaoAgua : ContentPage
{
	public IngestaoAgua()
	{
		InitializeComponent();
	}

    private void btnLimpar_Clicked(object sender, EventArgs e)
    {
        txtPeso.Text = null;
        Resultado.Text = null;
    }

    private void btnVerificar_Clicked(object sender, EventArgs e)
    {
        if (!int.TryParse(txtPeso.Text, out int peso))
        {
            DisplayAlert("Erro", "Digite um peso válido.", "OK");
            return;
        }

        decimal cal = (peso * 35m) / 1000m;

        Resultado.Text = $"O ideal para ser ingerido baseado no seu peso é de {cal} L";
    }

    private async void btnStatus_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Status());
    }
}