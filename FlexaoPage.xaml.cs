namespace Saude360.pastaTreino;

public partial class FlexaoPage : ContentPage
{
	public FlexaoPage()
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
        await SecureStorage.Default.SetAsync("FlexaoPeso", peso.Text);
        await SecureStorage.Default.SetAsync("FlexaoSerie", serie.Text);
        await SecureStorage.Default.SetAsync("FlexaoRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("FlexaoPeso", "");
        await SecureStorage.Default.SetAsync("FlexaoSerie", "");
        await SecureStorage.Default.SetAsync("FlexaoRepeticao", "");
    }
    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("FlexaoPeso");
        serie.Text = await SecureStorage.Default.GetAsync("FlexaoSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("FlexaoRepeticao");
    }
}