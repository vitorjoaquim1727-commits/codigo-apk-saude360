using System.Threading.Tasks;

namespace Saude360.pastaTreino;

public partial class LegInclinadoPage : ContentPage
{
	public LegInclinadoPage()
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
        await SecureStorage.Default.SetAsync("LegInclinadoPeso", peso.Text);
        await SecureStorage.Default.SetAsync("LegInclinadoSerie", serie.Text);
        await SecureStorage.Default.SetAsync("legInclinadoRepeticao", repeticao.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        await SecureStorage.Default.SetAsync("LegInclinadoPeso", "");
        await SecureStorage.Default.SetAsync("LegInclinadoSerie", "");
        await SecureStorage.Default.SetAsync("legInclinadoRepeticao", "");
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("LegInclinadoPeso");
        serie.Text =  await SecureStorage.Default.GetAsync("LegInclinadoSerie");
        repeticao.Text =  await SecureStorage.Default.GetAsync("legInclinadoRepeticao");
    }
}