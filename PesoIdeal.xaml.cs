using System.Globalization;
using System.Reflection;

namespace Saude360.NovaPasta;

public partial class PesoIdeal : ContentPage
{
	public PesoIdeal()
	{
		InitializeComponent();
	}

   

    private void txtApagar_Clicked(object sender, EventArgs e)
    {
        txtAltura.Text = null;
        Resultado.Text = null;
    }

    private void txtCalcular_Clicked(object sender, EventArgs e)
    {
        var cultura = new CultureInfo("pt-BR");
        

        if (double.TryParse(txtAltura.Text, NumberStyles.Float, cultura, out double altura))
        {
            double pesoIdealHomem;
            double pesoIdealMulher;

            altura *= 100;

            pesoIdealHomem = 50 + (2.3 * ((altura - 152.4) / 2.54));

            pesoIdealMulher = 45.5 + (2.3 * ((altura - 152.4) / 2.54));

            Resultado.Text = $"Resultado para Homem: {pesoIdealHomem:F2}\nResultado para Mulher: {pesoIdealMulher:F2}";
        }
        else
        {
            DisplayAlert("Erro", "Por favor, digite números válidos (use vírgula para decimais, ex: 1,75).", "OK");
        }
    }
}