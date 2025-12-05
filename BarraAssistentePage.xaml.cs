namespace Saude360.pastaTreino.TrinoPuxar;

public partial class BarraAssistentePage : ContentPage
{
	public BarraAssistentePage()
	{
		InitializeComponent();
	}

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraAssistenteNeutraPeso", peso.Text);
            await SecureStorage.Default.SetAsync("BarraAssistenteNeutraSerie", serie.Text);
            await SecureStorage.Default.SetAsync("BarraAssistenteNeutraRepeticao", repeticao.Text);
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraAssistentePronadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("BarraAssistentePronadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("BarraAssistentePronadaRepeticao", repeticao.Text);
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraAssistenteSupinadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("BarraAssistenteSupinadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("BarraAssistenteSupinadaRepeticao", repeticao.Text);
        }
        else
        {
            await DisplayAlert("Algo está faltando", "Porfavor escolha o tipo de pegada \n" +
                "antes de salvar os valores", "OK");
        }
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraAssistenteNeutraPeso", "");
            await SecureStorage.Default.SetAsync("BarraAssistenteNeutraSerie", "");
            await SecureStorage.Default.SetAsync("BarraAssistenteNeutraRepeticao", "");
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraAssistentePronadaPeso", "");
            await SecureStorage.Default.SetAsync("BarraAssistentePronadaSerie", "");
            await SecureStorage.Default.SetAsync("BarraAssistentePronadaRepeticao", "");
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraAssistenteSupinadaPeso", "");
            await SecureStorage.Default.SetAsync("BarraAssistenteSupinadaSerie", "");
            await SecureStorage.Default.SetAsync("BarraAssistenteSupinadaRepeticao", "");
        }
        else
        {
            await DisplayAlert("Algo está faltando", "Porfavor escolha o tipo de pegada \n" +
                "antes de apagar os valores", "OK");
        }
    }

    private async void TipoPegada(object sender, EventArgs e)
    {
        if (rbNeutra.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("BarraAssistenteNeutraPeso");
            serie.Text = await SecureStorage.Default.GetAsync("BarraAssistenteNeutraSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("BarraAssistenteNeutraRepeticao");
        }
        else if (rbPronada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("BarraAssistentePronadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("BarraAssistentePronadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("BarraAssistentePronadaRepeticao");
        }
        else if (rbSupinada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("BarraAssistenteSupinadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("BarraAssistenteSupinadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("BarraAssistenteSupinadaRepeticao");
        }
    }
}