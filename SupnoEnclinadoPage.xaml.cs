namespace Saude360.pastaTreino;

public partial class SupnoEnclinadoPage : ContentPage
{
	public SupnoEnclinadoPage()
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
        await SecureStorage.Default.SetAsync("SupinoInclinadoPeso", peso.Text);
        await SecureStorage.Default.SetAsync("SupinoInclinadoSerie", serie.Text);
        await SecureStorage.Default.SetAsync("SupineInclinadoRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("SupinoInclinadoPeso", "");
        await SecureStorage.Default.SetAsync("SupinoInclinadoSerie", "");
        await SecureStorage.Default.SetAsync("SupineInclinadoRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("SupinoInclinadoPeso");
        serie.Text = await SecureStorage.Default.GetAsync("SupinoInclinadoSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("SupineInclinadoRepeticao");
    }
}