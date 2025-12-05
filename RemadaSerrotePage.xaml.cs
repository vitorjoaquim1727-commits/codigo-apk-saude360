namespace Saude360.pastaTreino.TrinoPuxar;

public partial class RemadaSerrotePage : ContentPage
{
	public RemadaSerrotePage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await RedirecionarDados();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("RemadaSerrotePeso", peso.Text);
        await SecureStorage.Default.SetAsync("RemadaSerroteSerie", serie.Text);
        await SecureStorage.Default.SetAsync("RemadaSerroteRepeticao", repeticao.Text);
  
    }

    private async void btnApagar_Clicked(object sender, EventArgs e)
    {
        peso.Text = "";
        serie.Text = "";
        repeticao.Text = "";

 

         await SecureStorage.Default.SetAsync("RemadaSerrotePeso", "");
         await SecureStorage.Default.SetAsync("RemadaSerroteSerie", "");
         await SecureStorage.Default.SetAsync("RemadaSerroteRepeticao", "");
       
    }

    private async Task RedirecionarDados()
    {
        peso.Text = await SecureStorage.Default.GetAsync("RemadaSerrotePeso");
        serie.Text = await SecureStorage.Default.GetAsync("RemadaSerroteSerie");
        repeticao.Text = await SecureStorage.Default.GetAsync("RemadaSerroteRepeticao");
    }


}