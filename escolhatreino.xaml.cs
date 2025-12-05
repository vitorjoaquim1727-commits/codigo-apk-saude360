using Saude360.pastaTreino;
using Saude360.pastaTreino.TrinoPuxar;
using System.Threading.Tasks;




namespace Saude360.NovaPasta;

public partial class escolhatreino : TabbedPage
{
	public escolhatreino()
	{
		InitializeComponent();
	}

    private async void btnEstensora_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new estensolaPage());
    }

    private async void btnLegSentado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LegSentadoPade());
    }

    private async void btnAgachamento_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgachamentoPage());
    }

    private async void btnBicicleta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BicicletaPage());
    }

    private async void btnPanturrilha_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ElevamentoPanturrilhaPage());
    }

    private async void btnEscada_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EscadaPage());
    }

    private async void btnExtensaoLombar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExtensaoLombarPage());
    }

    private async void btnFlexaoPernaDeitado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FlexaoPernasDeitadoPage());
    }

    private async void btnLegInclinado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LegInclinadoPage());
    }

    private async void btnEliptico_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ElipticoPage());
    }

    private async void btnSupnoEnclinado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SupnoEnclinadoPage());
    }

    private async void btnSupio_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SupinoPage());
    }

    private async void btnRosca_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RoscaPage());
    }

    private async void btnSupinoInclinadoGuiado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SupinoInclinadoGuiagoPage());
    }

    private async void btnSupinoHalteres_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SupinoHalterPage());
    }

    private async void btnParalela_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ParalelaPage());
    }

    private async void btnFlexao_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FlexaoPage());
    }

    private async void btnParalelaAssintente_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ParalelaAssintentePage());
    }

    private async void btnRemadaAlta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RemadaAltaPage());
    }

    private async void btnRemadaBaixa_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RemadaBaixaPage());
    }

    private async void btnBarra_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BarraPage());
    }

    private void Barramento_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnBarraAssistente_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BarraAssistentePage());
    }

    private async void btnTrapezio_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TrapesioPage());
    }

    private async void btnRemadaSerrote_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RemadaSerrotePage());
    }
}