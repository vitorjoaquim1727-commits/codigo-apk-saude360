namespace Saude360.pastaTreino.TrinoPuxar;

public partial class RemadaAltaPage : ContentPage
{
	public RemadaAltaPage()
	{
		InitializeComponent();
	}


    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaAltaNeutraPeso", peso.Text);
            await SecureStorage.Default.SetAsync("RemadaAltaNeutraSerie", serie.Text);
            await SecureStorage.Default.SetAsync("RemadaAltaNeutraRepeticao", repeticao.Text);
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaRepeticao", repeticao.Text);
        }
        else if (rbSupinada.IsChecked) {
            await SecureStorage.Default.SetAsync("RemadaAltaSupinadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("RemadaAltaSupinadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("RemadaAltaSupinadaRepeticao", repeticao.Text);
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
            await SecureStorage.Default.SetAsync("RemadaAltaNeutraPeso", "");
            await SecureStorage.Default.SetAsync("RemadaAltaNeutraSerie", "");
            await SecureStorage.Default.SetAsync("RemadaAltaNeutraRepeticao", "");
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaPeso", "");
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaSerie", "");
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaRepeticao", "");
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaAltaSupinadaPeso", "");
            await SecureStorage.Default.SetAsync("RemadaAltaSupinadaSerie", "");
            await SecureStorage.Default.SetAsync("RemadaAltaSupinadaRepeticao", "");
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
            peso.Text = await SecureStorage.Default.GetAsync("RemadaAltaNeutraPeso");
            serie.Text = await SecureStorage.Default.GetAsync("RemadaAltaNeutraSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("RemadaAltaNeutraRepeticao");
        }
        else if (rbPronada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("RemadaAltaPronadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("RemadaAltaPronadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("RemadaAltaPronadaRepeticao");
        }
        else if (rbSupinada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("RemadaAltaSupinadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("RemadaAltaSupinadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("RemadaAltaSupinadaRepeticao");
        }
    }

}