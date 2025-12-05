using System.Runtime.CompilerServices;


namespace Saude360;

public partial class Status : ContentPage
{
	public Status()
	{
		InitializeComponent();

	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await CarregarBarraIMC();
        await CarregarBarraTMB();
    }

    public async Task CarregarBarraIMC()
    {
        double resIMC = Convert.ToDouble(await SecureStorage.Default.GetAsync("IMC"));
        double resImc = resIMC / 100;


        if (resIMC == 16.66)
        {
            barraProgressoIMC.ProgressColor = Colors.Red;
        }
        else if (resIMC == 33.32)
        {
            barraProgressoIMC.ProgressColor = Colors.Yellow;
        }
        else if (resIMC == 49.98)
        {
            barraProgressoIMC.ProgressColor = Colors.Green;
            
        }
        else if (resIMC == 66.64)
        {
            barraProgressoIMC.ProgressColor = Colors.Yellow;
        }
        else if (resIMC == 83.3)
        {
            barraProgressoIMC.ProgressColor = Colors.OrangeRed;
        }
        else if (resIMC == 99.90)
        {
            barraProgressoIMC.ProgressColor = Colors.Red;
        }
        else if (resIMC == 100.00)
        {
            barraProgressoIMC.ProgressColor = Colors.DarkRed;
        }

        await barraProgressoIMC.ProgressTo(resImc, 4000, Easing.Linear);
    }

    public async Task CarregarBarraTMB()
    {
        double resTMB = Convert.ToDouble(await SecureStorage.Default.GetAsync("TBM"));
        double res = resTMB / 100;

        // Corrige a cor
        int valor = (int)Math.Round(resTMB);

        if (valor <= 25)
            barraPrograssoTMB.ProgressColor = Colors.Yellow;
        else if (valor <= 50)
            barraPrograssoTMB.ProgressColor = Colors.Green;
        else if (valor <= 75)
            barraPrograssoTMB.ProgressColor = Colors.OrangeRed;
        else
            barraPrograssoTMB.ProgressColor = Colors.Red;

        // Inicia animação

        await barraPrograssoTMB.ProgressTo(res, 4000, Easing.Linear);

    }
}