namespace Saude360.pastaTreino.TrinoPuxar;

public partial class RemadaBaixaPage : ContentPage
{
	public RemadaBaixaPage()
	{
		InitializeComponent();
	}

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaBaixaNeutraPeso", peso.Text);
            await SecureStorage.Default.SetAsync("RemadaBaixaNeutraSerie", serie.Text);
            await SecureStorage.Default.SetAsync("RemadaBaixaNeutraRepeticao", repeticao.Text);
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaBaixaPronadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("RemadaBaixaPronadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("RemadaBaixaPronadaRepeticao", repeticao.Text);
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaBaixaaSupinadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("RemadaBaixaSupinadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("RemadaBaixaSupinadaRepeticao", repeticao.Text);
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
            await SecureStorage.Default.SetAsync("RemadaBaixaNeutraPeso", "");
            await SecureStorage.Default.SetAsync("RemadaBaixaNeutraSerie", "");
            await SecureStorage.Default.SetAsync("RemadaBaixaNeutraRepeticao", "");
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaBaixaPronadaPeso", "");
            await SecureStorage.Default.SetAsync("RemadaBaixaPronadaSerie", "");
            await SecureStorage.Default.SetAsync("RemadaBaixaPronadaRepeticao", "");
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("RemadaBaixaaSupinadaPeso", "");
            await SecureStorage.Default.SetAsync("RemadaBaixaSupinadaSerie", "");
            await SecureStorage.Default.SetAsync("RemadaBaixaSupinadaRepeticao", "");
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
            peso.Text = await SecureStorage.Default.GetAsync("RemadaBaixaNeutraPeso");
            serie.Text = await SecureStorage.Default.GetAsync("RemadaBaixaNeutraSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("RemadaBaixaNeutraRepeticao");
        }
        else if (rbPronada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("RemadaBaixaPronadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("RemadaBaixaPronadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("RemadaBaixaPronadaRepeticao");
        }
        else if (rbSupinada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("RemadaBaixaaSupinadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("RemadaBaixaSupinadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("RemadaBaixaSupinadaRepeticao");
        }
    }
}
