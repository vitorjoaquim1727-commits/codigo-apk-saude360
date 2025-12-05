using System.Globalization;

namespace Saude360.NovaPasta;

public partial class PercentualDeGordura : ContentPage
{
    
	public PercentualDeGordura()
	{
		InitializeComponent();
	}

    private async  void btnCalcular_Clicked(object sender, EventArgs e)
    {
        var cultura = new CultureInfo("pt-BR");

        if (!double.TryParse(txtIMC.Text, out double imc) ||
    !double.TryParse(txtIdade.Text, out double idade))
        {
            await DisplayAlert("Erro", "Digite valores válidos para IMC e idade.", "OK");
            return;
        }

        double sexo;

        // validação do sexo
        if (rbtnHomem.IsChecked)
        {
            sexo = 1;
        }
        else if (rbtnMulher.IsChecked)
        {
            sexo = 0;
        }
        else
        {
            await DisplayAlert("Erro", "Você não selecionou o seu sexo.", "OK");
            return; // ❗ necessário
        }

        double gordura = 1.2 * imc + 0.23 * idade - 10.8 * sexo - 5.4;

        
        // Classificação
        string classificacao;

        // CLASSIFICAÇÃO PARA HOMENS
        if (sexo == 1)
        {
            if (gordura < 8)
                classificacao = "Muito baixo – pode indicar baixo peso ou pouca massa muscular.";
            else if (gordura < 20)
                classificacao = "Ideal – dentro do percentual saudável.";
            else if (gordura < 25)
                classificacao = "Elevado – acima do recomendado.";
            else
                classificacao = "Muito alto – risco cardiovascular aumentado.";
        }
        // CLASSIFICAÇÃO PARA MULHERES
        else
        {
            if (gordura < 21)
                classificacao = "Muito baixo – pode indicar baixo peso ou pouca massa muscular.";
            else if (gordura < 34)
                classificacao = "Ideal – dentro do percentual saudável.";
            else if (gordura < 40)
                classificacao = "Elevado – acima do recomendado.";
            else
                classificacao = "Muito alto – risco cardiovascular aumentado.";
        }

        Resultado.Text = $"Percentual estimado de gordura corporal: {gordura:F1}%\n{classificacao}";



    }

    private void btnApagar_Clicked(object sender, EventArgs e)
    {
        txtIMC.Text = null;
        txtIdade.Text = null;
        Resultado.Text = null;
        rbtnHomem.IsChecked = false;
        rbtnMulher.IsChecked = false;
    }

    private async void btnStatys_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Status());
    }
}