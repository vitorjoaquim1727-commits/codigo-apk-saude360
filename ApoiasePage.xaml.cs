namespace Saude360.Informacoes;

public partial class ApoiasePage : ContentPage
{
	public ApoiasePage()
	{
		InitializeComponent();
	}

    private async void btnApoiar_Clicked(object sender, EventArgs e)
    {
		await Launcher.OpenAsync("https://link.infinitepay.io/vitor_hugo_joaquim_da/VC01LTUtSQ-6oX6naaJm9-5,00");
    }

    private async void btnApoiarPix_Clicked(object sender, EventArgs e)
    {
        string chavePix = "vitor_hugo_joaquim_da@jim.com"; // coloque seu número ou chave PIX
        await Clipboard.SetTextAsync(chavePix);
    }
}