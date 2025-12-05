using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class FlexaoPernasDeitadoPage : ContentPage
{
	public FlexaoPernasDeitadoPage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await RedirecionarDados();
    }

    private async void btnSalvar_Clicked_1(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("FlexaoPernaPeso", peso.Text);
        await SecureStorage.Default.SetAsync("FlexaoPernaSerie", serie.Text);
        await SecureStorage.Default.SetAsync("FlexapPernaRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("FlexaoPernaPeso", peso.Text);
        await SecureStorage.Default.SetAsync("FlexaoPernaSerie", serie.Text);
        await SecureStorage.Default.SetAsync("FlexapPernaRepeticao", repeticao.Text);
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("FlexaoPernaPeso");
        serie.Text = await SecureStorage.Default.GetAsync("FlexaoPernaSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("FlexapPernaRepeticao");
    }
}