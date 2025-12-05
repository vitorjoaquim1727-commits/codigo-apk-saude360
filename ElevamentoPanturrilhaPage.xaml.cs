namespace Saude360.pastaTreino;

public partial class ElevamentoPanturrilhaPage : ContentPage
{
	public ElevamentoPanturrilhaPage()
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
		await SecureStorage.Default.SetAsync("PanturrilhaPeso", peso.Text);
		await SecureStorage.Default.SetAsync("PanturrilhaSerie", serie.Text);
		await SecureStorage.Default.SetAsync("PanturrilhaRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("PanturrilhaPeso", "");
        await SecureStorage.Default.SetAsync("PanturrilhaSerie", "");
        await SecureStorage.Default.SetAsync("PanturrilhaRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("PanturrilhaPeso");
        serie.Text = await SecureStorage.Default.GetAsync("PanturrilhaSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("PanturrilhaRepeticao");
    }
}