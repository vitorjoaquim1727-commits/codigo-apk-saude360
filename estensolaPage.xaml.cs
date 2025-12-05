using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class estensolaPage : ContentPage
{
	public estensolaPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        RedirecionarDados();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
		await SecureStorage.Default.SetAsync("EstensoraPeso", peso.Text);
		await SecureStorage.Default.SetAsync("EstensoraSerie", serie.Text);
		await SecureStorage.Default.SetAsync("EstemspraRepeticao", repetcao.Text);
    }



    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("EstensoraPeso");
        serie.Text = await SecureStorage.Default.GetAsync("EstensoraSerie");
        repetcao.Text = await SecureStorage.Default.GetAsync("EstemspraRepeticao");
    }

    private async void btnApagar_Clicked_1(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repetcao.Text = "";

        await SecureStorage.Default.SetAsync("EstensoraPeso", "");
        await SecureStorage.Default.SetAsync("EstensoraSerie", "");
        await SecureStorage.Default.SetAsync("EstemspraRepeticao", "");
    }
}