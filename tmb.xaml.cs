using System.Globalization;

namespace Saude360.NovaPasta;

public partial class tmb : ContentPage
{
    string verificaSexo;
	public tmb()
	{
		InitializeComponent();
	}

    private void btnApagar_Clicked(object sender, EventArgs e)
    {
        txtPeso.Text = null;
        txtAltura.Text = null;
        txtIdade.Text = null;
        Resultado.Text = null;
        rbtnHomem.IsChecked = false;
        rbtnMulher.IsChecked = false;
        
    }

    private  void VerificaSexo(object sender, EventArgs e)
    {
        if (rbtnHomem.IsChecked) { verificaSexo = rbtnHomem.Content.ToString(); }
        else if (rbtnMulher.IsChecked) { verificaSexo = rbtnMulher.Content.ToString(); }
        
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        var cultura = new CultureInfo("pt-BR");

        if (double.TryParse(txtPeso.Text, NumberStyles.Float, cultura, out double peso) &&
            double.TryParse(txtAltura.Text, NumberStyles.Float, cultura, out double altura) &&
            double.TryParse(txtIdade.Text, NumberStyles.Float, cultura, out double idade))
        {

            if(verificaSexo == "Homem")
            {
                double calHomem = 88.36 + (13.4 * peso) + (4.8 * altura) - (5.7 * idade);
                Resultado.Text = $"TMB Homem: {calHomem:F0} kcal/dia";

                // Verifica homem
                if (calHomem < 1400)
                {
                    TMBMuitoBaixa();
                }
                else if (calHomem <= 2000)
                {
                    TMBNormal();
                }
                else
                {
                    TMBMuitoAlta();
                }
            }
            else if (verificaSexo == "Mulher")
            {
                double calMulher = 447.6 + (9.2 * peso) + (3.1 * altura) - (4.3 * idade);
                Resultado.Text = $"TMB Mulher: {calMulher:F0} kcal/dia";
                // Verifica mulher
                if (calMulher < 1200)
                {
                    TMBMuitoBaixa();
                }
                else if (calMulher <= 1700)
                {
                    TMBNormal();
                }
                else
                {
                    TMBMuitoAlta();
                }
            }
            else
            { DisplayAlert("Alerta", "Você não selacionou o seu sexo", "OK"); }

        }

    }

    public async void TMBMuitoBaixa()
    {
        DisplayAlert("Alerta", "TMB muito baixa.", "OK");
        if (verificaSexo == "Homem")
        { Resultado.Text += " TMB muito baixa:\r\nPode indicar baixo peso, perda de massa muscular, metabolismo lento (ex: dietas muito restritivas ou hipotireoidismo).\r\n→ A pessoa tende a gastar poucas calorias em repouso."; }
        else { Resultado.Text += " TMB muito baixa:\r\nPode indicar baixo peso, perda de massa muscular, metabolismo lento (ex: dietas muito restritivas ou hipotireoidismo).\r\n→ A pessoa tende a gastar poucas calorias em repouso."; }
        string valor = "25";
        EnviaStatus(valor);
    }
    public void TMBNormal()
    {
        DisplayAlert("Alerta", "TMB normal.", "OK");
        if (verificaSexo == "Homem") { Resultado.Text += " TMB normal:\r\nIndica equilíbrio metabólico, coerente com peso e altura.\r\n→ É o valor esperado para manter o corpo funcionando normalmente."; }
        else { Resultado.Text += " TMB normal:\r\nIndica equilíbrio metabólico, coerente com peso e altura.\r\n→ É o valor esperado para manter o corpo funcionando normalmente."; }
        string valor = "50";
        EnviaStatus(valor);
    }

    public void TMBMuitoAlta()
    {
        DisplayAlert("Alerta", "TMB muito alta.", "OK");
        if (verificaSexo == "Homem") { Resultado.Text += " TMB muito alta:\r\nCostuma ocorrer em pessoas com maior massa muscular, metabolismo acelerado, ou tamanho corporal elevado.\r\n→ O corpo gasta mais energia mesmo em repouso."; }
        else { Resultado.Text += " TMB muito alta:\r\nCostuma ocorrer em pessoas com maior massa muscular, metabolismo acelerado, ou tamanho corporal elevado.\r\n→ O corpo gasta mais energia mesmo em repouso."; }
        string valor = "75";
        EnviaStatus(valor);
    }

    private async void EnviaStatus(string res2)
    {
        string l = await SecureStorage.Default.GetAsync("Logado");
        if (l == "1")
        { await SecureStorage.Default.SetAsync("TMB", res2); }
    }

    private async void btnStatus_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Status());
    }
}