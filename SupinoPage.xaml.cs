using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class SupinoPage : ContentPage
{
	public SupinoPage()
	{
		InitializeComponent();
	}
    protected async override  void OnAppearing()
    {
        base.OnAppearing();
        await RedirecionarDados();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("SupinoPeso", peso.Text);
        await SecureStorage.Default.SetAsync("SupinoSerie", serie.Text);
        await SecureStorage.Default.SetAsync("SupinoRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("SupinoPeso", "");
        await SecureStorage.Default.SetAsync("SupinoSerie", "");
        await SecureStorage.Default.SetAsync("SupinoRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("SupinoPeso");
        serie.Text = await SecureStorage.Default.GetAsync("SupinoSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("SupinoRepeticao");
    }
}