using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class BicicletaPage : ContentPage
{
	public BicicletaPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await RedirecionarDados();
    }

    private async void btnSalvar_Clicked_1(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("BicicletaVelocidade", velocidade.Text);
        await SecureStorage.Default.SetAsync("BicicletaMinutos", minutos.Text);
    }


    private async Task RedirecionarDados()
    {
        velocidade.Text = await SecureStorage.Default.GetAsync("BicicletaVelocidade");
        minutos.Text = await SecureStorage.Default.GetAsync("BicicletaMinutos");
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        velocidade.Text = "";
        minutos.Text = "";

        await SecureStorage.Default.SetAsync("BicicletaVelocidade", "");
        await SecureStorage.Default.SetAsync("BicicletaMinutos", "");
    }
}