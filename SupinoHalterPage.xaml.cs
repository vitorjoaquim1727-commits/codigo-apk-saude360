namespace Saude360.pastaTreino;

public partial class SupinoHalterPage : ContentPage
{
	public SupinoHalterPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await RedirecionarDados();
    }
    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("SupinoHalterPeso", peso.Text);
        await SecureStorage.Default.SetAsync("SupinoHalterSerie", serie.Text);
        await SecureStorage.Default.SetAsync("SupinoHalterRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("SupinoHalterPeso", "");
        await SecureStorage.Default.SetAsync("RoSupinoHalterSeriescaSerie", "");
        await SecureStorage.Default.SetAsync("SupinoHalterRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("SupinoHalterPeso");
        serie.Text = await SecureStorage.Default.GetAsync("SupinoHalterSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("SupinoHalterRepeticao");
    }
}
