using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class ExtensaoLombarPage : ContentPage
{
	public ExtensaoLombarPage()
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
        await SecureStorage.Default.SetAsync("LombarPeso", peso.Text);
        await SecureStorage.Default.SetAsync("LombarSerie", serie.Text);
        await SecureStorage.Default.SetAsync("LombarRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

       await SecureStorage.Default.SetAsync("LombarPeso", "");
        await SecureStorage.Default.SetAsync("LombarSerie", "");
        await SecureStorage.Default.SetAsync("LombarRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("LombarPeso");
        serie.Text = await SecureStorage.Default.GetAsync("LombarSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("LombarRepeticao");
    } 
}