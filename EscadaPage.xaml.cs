namespace Saude360.pastaTreino;

public partial class EscadaPage : ContentPage
{
	public EscadaPage()
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
		await SecureStorage.Default.SetAsync("EscadaVelocidade", velocidade.Text);
		await SecureStorage.Default.SetAsync("EscadaMinutos", minutos.Text);
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        velocidade.Text = "";
        minutos.Text = "";

        await SecureStorage.Default.SetAsync("EscadaVelocidade", "");
        await SecureStorage.Default.SetAsync("EscadaMinutos", "");
    }

    private async Task RedirecionarDados()
    {
        velocidade.Text = await SecureStorage.Default.GetAsync("EscadaVelocidade");
        minutos.Text = await SecureStorage.Default.GetAsync("EscadaMinutos");
    }
}