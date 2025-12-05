using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class ElipticoPage : ContentPage
{
	public ElipticoPage()
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
        await SecureStorage.Default.SetAsync("ElipticoVelocidade", velocidade.Text);
        await SecureStorage.Default.SetAsync("ElipticoMinutos", minutos.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        velocidade.Text = "";
        minutos.Text = "";

        await SecureStorage.Default.SetAsync("ElipticoVelocidade","");
        await SecureStorage.Default.SetAsync("ElipticoMinutos", "");
    }

    private async Task RedirecionarDados()
    {
        velocidade.Text = await SecureStorage.Default.GetAsync("ElipticoVelocidade");
        minutos.Text = await SecureStorage.Default.GetAsync("ElipticoMinutos");
    }
}