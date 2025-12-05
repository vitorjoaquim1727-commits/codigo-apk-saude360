namespace Saude360.pastaTreino;

public partial class LegSentadoPade : ContentPage
{
	public LegSentadoPade()
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
		await SecureStorage.Default.SetAsync("LegSentadoPeso", peso.Text);
		await SecureStorage.Default.SetAsync("LegSentadoSerie", serie.Text);
		await SecureStorage.Default.SetAsync("LegSentado", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("LegSentadoPeso", "");
        await SecureStorage.Default.SetAsync("LegSentadoSerie", "");
        await SecureStorage.Default.SetAsync("LegSentado", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("LegSentadoPeso");
        serie.Text = await SecureStorage.Default.GetAsync("LegSentadoSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("LegSentado");
    }
}