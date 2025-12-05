namespace Saude360.pastaTreino;

public partial class ParalelaPage : ContentPage
{
	public ParalelaPage()
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
        await SecureStorage.Default.SetAsync("ParalelaPeso", peso.Text);
        await SecureStorage.Default.SetAsync("ParalelaSerie", serie.Text);
        await SecureStorage.Default.SetAsync("ParalelaRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("ParalelaPeso", "");
        await SecureStorage.Default.SetAsync("ParalelaSerie", "");
        await SecureStorage.Default.SetAsync("ParalelaRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("ParalelaPeso");
        serie.Text = await SecureStorage.Default.GetAsync("ParalelaSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("ParalelaRepeticao");
    }
}