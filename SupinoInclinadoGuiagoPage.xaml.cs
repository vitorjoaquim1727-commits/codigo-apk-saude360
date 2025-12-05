namespace Saude360.pastaTreino;

public partial class SupinoInclinadoGuiagoPage : ContentPage
{
	public SupinoInclinadoGuiagoPage()
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
        await SecureStorage.Default.SetAsync("SupinoInclinadoGuiadoPeso", peso.Text);
        await SecureStorage.Default.SetAsync("SupinoInclinadoGuiadoSerie", serie.Text);
        await SecureStorage.Default.SetAsync("SupinoInclinadoGuiadoRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("SupinoInclinadoGuiadoPeso", "");
        await SecureStorage.Default.SetAsync("SupinoInclinadoGuiadoSerie", "");
        await SecureStorage.Default.SetAsync("SupinoInclinadoGuiadoRepeticao", "");
    }
    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("SupinoInclinadoGuiadoPeso");
        serie.Text = await SecureStorage.Default.GetAsync("SupinoInclinadoGuiadoSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("SupinoInclinadoGuiadoRepeticao");
    }
}