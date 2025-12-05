using System.Threading.Tasks;

namespace Saude360.NovaPasta;

public partial class escolha : ContentPage
{
	public escolha()
	{
        InitializeComponent();
    }

    private async void btnIMC_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new imc());
    }

    private async void btnTMB_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new tmb());
    }

    private async void btnTDEE_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TDEE());
    }

    private async void btnPesoIdeal_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PesoIdeal());
    }

    private async void PercentualDeGorduraCorporal_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PercentualDeGordura());
    }

    private async void btnSCM_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FCM());
    }

    private async void btnRCA_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RCA());
    }

    private async void btnIngestaoDiariaDeAgua_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new IngestaoAgua());
    }
}