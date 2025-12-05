using System.Globalization;

namespace Saude360.NovaPasta;

public partial class TDEE : ContentPage
{
	public TDEE()
	{
		InitializeComponent();
		
	}

    private async void btnVerificar_Clicked(object sender, EventArgs e)
    {
        var cultura = new CultureInfo("pt-BR");

        // Validação
        if (!double.TryParse(txtTMB.Text, out double tmb) ||
            !double.TryParse(txtFator.Text, out double fator))
        {
            await DisplayAlert("Erro", "Digite valores válidos para TMB e fator de atividade.", "OK");
            return;
        }

        // Cálculo do TDEE
        double tdee = tmb * fator;

        // Classificação
        string classificacao;

        if (tdee < 1600)
        {
            classificacao = "Muito baixo – abaixo do gasto calórico recomendado.";
        }
        else if (tdee <= 2800)
        {
            classificacao = "Ideal – dentro do gasto calórico saudável.";
        }
        else
        {
            classificacao = "Muito alto – acima do recomendado, possivelmente alta atividade física.";
        }

        // Exibir resultado
        Resultado.Text = $"Seu TDEE estimado é {tdee:F2} kcal/dia\n{classificacao}";


    }

    private void btnApagar_Clicked(object sender, EventArgs e)
    {
        txtTMB.Text = null;
        txtFator.Text = null;
        Resultado.Text = null;
    }
}