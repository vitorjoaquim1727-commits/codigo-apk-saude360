namespace Saude360.pastaTreino.TrinoPuxar;

public partial class TrapesioPage : ContentPage
{
	public TrapesioPage()
	{
		InitializeComponent();
	}

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("TrapesioNeutraPeso", peso.Text);
            await SecureStorage.Default.SetAsync("TrapesioNeutraSerie", serie.Text);
            await SecureStorage.Default.SetAsync("TrapesioNeutraRepeticao", repeticao.Text);
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("TrapesioPronadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("TrapesioPronadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("TrapesioPronadaRepeticao", repeticao.Text);
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("TrapesioaSupinadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("TrapesioSupinadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("TrapesioSupinadaRepeticao", repeticao.Text);
        }
        else
        {
            await DisplayAlert("Algo está faltando", "Porfavor escolha o tipo de pegada \n" +
                "antes de salvar os valores", "OK");
        }
    }

    private async  void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("TrapesioNeutraPeso", "");
            await SecureStorage.Default.SetAsync("TrapesioNeutraSerie", "");
            await SecureStorage.Default.SetAsync("TrapesioNeutraRepeticao", "");
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("TrapesioPronadaPeso", "");
            await SecureStorage.Default.SetAsync("TrapesioPronadaSerie", "");
            await SecureStorage.Default.SetAsync("TrapesioPronadaRepeticao", "");
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("TrapesioSupinadaPeso", "");
            await SecureStorage.Default.SetAsync("TrapesioSupinadaSerie", "");
            await SecureStorage.Default.SetAsync("TrapesioSupinadaRepeticao", "");
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
            peso.Text = await SecureStorage.Default.GetAsync("TrapesioNeutraPeso");
            serie.Text = await SecureStorage.Default.GetAsync("TrapesioNeutraSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("TrapesioNeutraRepeticao");
        }
        else if (rbPronada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("TrapesioPronadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("TrapesioPronadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("TrapesioPronadaRepeticao");
        }
        else if (rbSupinada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("TrapesioSupinadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("TrapesioSupinadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("TrapesioSupinadaRepeticao");
        }
    }
}