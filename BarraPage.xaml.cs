namespace Saude360.pastaTreino.TrinoPuxar;

public partial class BarraPage : ContentPage
{
    public BarraPage()
    {
        InitializeComponent();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (rbNeutra.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraNeutraPeso", peso.Text);
            await SecureStorage.Default.SetAsync("BarraNeutraSerie", serie.Text);
            await SecureStorage.Default.SetAsync("BarraNeutraRepeticao", repeticao.Text);
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraPronadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("BarraPronadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("BarraPronadaRepeticao", repeticao.Text);
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraSupinadaPeso", peso.Text);
            await SecureStorage.Default.SetAsync("BarraSupinadaSerie", serie.Text);
            await SecureStorage.Default.SetAsync("BarraSupinadaRepeticao", repeticao.Text);
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
            await SecureStorage.Default.SetAsync("BarraNeutraPeso", "");
            await SecureStorage.Default.SetAsync("BarraNeutraSerie", "");
            await SecureStorage.Default.SetAsync("BarraNeutraRepeticao", "");
        }
        else if (rbPronada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraPronadaPeso", "");
            await SecureStorage.Default.SetAsync("BarraPronadaSerie", "");
            await SecureStorage.Default.SetAsync("RemadaAltaPronadaRepeticao", "");
        }
        else if (rbSupinada.IsChecked)
        {
            await SecureStorage.Default.SetAsync("BarraSupinadaPeso", "");
            await SecureStorage.Default.SetAsync("BarraSupinadaSerie", "");
            await SecureStorage.Default.SetAsync("BarraSupinadaRepeticao", "");
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
            peso.Text = await SecureStorage.Default.GetAsync("BarraNeutraPeso");
            serie.Text = await SecureStorage.Default.GetAsync("BarraNeutraSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("BarraNeutraRepeticao");
        }
        else if (rbPronada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("BarraPronadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("BarraPronadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("BarraPronadaRepeticao");
        }
        else if (rbSupinada.IsChecked)
        {
            peso.Text = await SecureStorage.Default.GetAsync("BarraSupinadaPeso");
            serie.Text = await SecureStorage.Default.GetAsync("BarraSupinadaSerie");
            repeticao.Text = await SecureStorage.Default.GetAsync("BarraSupinadaRepeticao");
        }
    }
}