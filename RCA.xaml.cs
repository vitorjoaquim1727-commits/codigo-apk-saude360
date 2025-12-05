using System.Globalization;

namespace Saude360.NovaPasta;

public partial class RCA : ContentPage
{
	public RCA()
	{
		InitializeComponent();
	}

    private async void btnStatus_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Status());
    }

   

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        var cultura = new CultureInfo("pt-BR");

        if (!double.TryParse(txtAltura.Text, out double altura) ||
            !double.TryParse(txtCintura.Text, out double cintura))
        {
            DisplayAlert("Erro", "Digite valores válidos para altura e cintura.", "OK");
            return;
        }

        double novaAltura = altura * 100;
        // cálculo da RCA
        double cal = cintura / novaAltura;

        if (cal < 0.40)
        {
            Resposta.Text = $"Muito baixo – pode indicar baixo peso ou pouca massa muscular\nValor: {cal:F2}";
        }
        else if (cal < 0.50)
        {
            Resposta.Text = $"Ideal – baixo risco cardiovascular\nValor: {cal:F2}";
        }
        else
        {
            Resposta.Text = $"Aumentado – risco cardiovascular maior\nValor: {cal:F2}";
        }


    }

    private void btnApagar_Clicked(object sender, EventArgs e)
    {
        txtAltura.Text = null;
        txtCintura.Text = null;
        Resposta.Text = null;
    }
}