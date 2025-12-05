using System.Globalization;
using System.Xml.Linq;
using Saude360.Informacoes;

namespace Saude360.NovaPasta;

public partial class imc : ContentPage
{
    string res2;

    public imc()
	{
		InitializeComponent();
	}

    private void btnApagar_Clicked(object sender, EventArgs e)
    {
        entPeso.Text = null;
        entAltura.Text = null;
    }

    public void Muito_abaixo_do_peso()
    {
        DisplayAlert("Alerta", "Muito abaixo do peso.", "OK");
        resultado.Text += " Procure orientação médica e nutricional para verificar possíveis deficiências nutricionais e aumentar a ingestão de calorias de forma saudável.";
    }
    public void Abaixo_do_peso()
    {
        DisplayAlert("Alerta", "Abaixo do peso.", "OK");
        resultado.Text += " Inclua proteínas, grãos integrais e gorduras saudáveis; monitore peso regularmente e faça refeições equilibradas.";
    }
    public void Peso_normal()
    {
        DisplayAlert("Alerta", "Peso normal.", "OK");
        resultado.Text += " Mantenha hábitos saudáveis: alimentação balanceada, atividade física regular e sono adequado.";
    }
    public void Sobrepeso()
    {
        DisplayAlert("Alerta", "Sobrepeso.", "OK");
        resultado.Text += " Reduza alimentos ultraprocessados, aumente atividades físicas e monitore a circunferência da cintura para reduzir riscos de doenças.'";
    }
    public void Obesidade_grau_I()
    {
        DisplayAlert("Alerta", "Obesidade grau I.", "OK");
        resultado.Text += " Procure acompanhamento médico ou nutricional, adote mudanças no estilo de vida e comece um programa de exercícios adequado.";
    }
    public void Obesidade_grau_II()
    {
        DisplayAlert("Alerta", "Obesidade grau II.", "OK");
        resultado.Text += " Avalie riscos cardiovasculares e metabólicos, siga orientação profissional rigorosa e considere intervenções médicas se necessário.";
    }
    public void Obesidade_grau_III()
    {
        DisplayAlert("Alerta", "Obesidade grau III.", "OK");
        resultado.Text += " Necessita acompanhamento médico intensivo; o tratamento pode incluir mudanças alimentares, atividades físicas e, em alguns casos, procedimentos médicos ou cirúrgicos.";
    }

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        var cultura = new CultureInfo("pt-BR");

        if (double.TryParse(entPeso.Text, NumberStyles.Float, cultura, out double peso) &&
            double.TryParse(entAltura.Text, NumberStyles.Float, cultura, out double altura))
        {
            double imc = peso / (altura * altura);
            resultado.Text = $"IMC: {imc:F2}";

            double res;

            if (imc < 17)
            {
                Muito_abaixo_do_peso();

                res = 16.66;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else if (imc >= 17 && imc <= 18.4)
            {
                Abaixo_do_peso();

                res = 33.32;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else if (imc > 18.4 && imc <= 24.9) {
                Peso_normal();

                res = 49.98;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else if (imc > 24.9 && imc <= 29.9)
            {
                Sobrepeso();

                res = 66.64;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else if (imc > 29.9 && imc <= 34.9)
            {
                Obesidade_grau_I();

                res = 83.3;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else if (imc > 34.9 && imc <= 39.9)
            {
                Obesidade_grau_II();

                res = 99.90;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else if (imc >= 40)
            {
                Obesidade_grau_III();

                res = 100.00;

                res2 = Convert.ToString(res);

                EnviaStatus(res2);
            }
            else {
                DisplayAlert("Erro", "Algo deu errado, reveja suas respostas", "OK");
            }

        }
        else
        {
            DisplayAlert("Erro", "Por favor, digite números válidos (use vírgula para decimais, ex: 1,75).", "OK");
        }
    }
    private async void EnviaStatus(string res2)
    {
        string l = await SecureStorage.Default.GetAsync("Logado");
        if(l == "1")
        { await SecureStorage.Default.SetAsync("IMC", res2); }
    }

    private async void btnStatys_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Status());
    }

    private async void btnInformacao_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InformacaoIMCPage());
    }
}
