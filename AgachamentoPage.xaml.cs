namespace Saude360.pastaTreino;

public partial class AgachamentoPage : ContentPage
{
	public AgachamentoPage()
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
		await SecureStorage.Default.SetAsync("AgachamentoPeso", peso.Text);
		await SecureStorage.Default.SetAsync("AgachamentoSeire", serie.Text);
		await SecureStorage.Default.SetAsync("AgachamentoRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("AgachamentoPeso", "");
        await SecureStorage.Default.SetAsync("AgachamentoSeire", "");
        await SecureStorage.Default.SetAsync("AgachamentoRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("AgachamentoPeso");
        serie.Text = await SecureStorage.Default.GetAsync("AgachamentoSeire");
        repeticao.Text = await SecureStorage.Default.GetAsync("AgachamentoRepeticao");
    }
}