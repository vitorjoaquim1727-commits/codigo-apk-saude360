
namespace Saude360.pastaTreino;

public partial class RoscaPage : ContentPage
{
	public RoscaPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await RedirecionarDados();
    }

    private async  void btnSalvar_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("RoscaPeso", peso.Text);
        await SecureStorage.Default.SetAsync("RoscaSerie", serie.Text);
        await SecureStorage.Default.SetAsync("RoscaRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("RoscaPeso", "");
        await SecureStorage.Default.SetAsync("RoscaSerie", "");
        await SecureStorage.Default.SetAsync("RoscaRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("RoscaPeso");
        serie.Text = await SecureStorage.Default.GetAsync("RoscaSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("RoscaRepeticao");
    }
}