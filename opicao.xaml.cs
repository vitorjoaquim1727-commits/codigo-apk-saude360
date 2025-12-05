using Microsoft.VisualBasic;
using System.Threading.Tasks;


namespace Saude360.NovaPasta;

public partial class opicao : ContentPage
{
	public opicao()
	{
		InitializeComponent();

    }

    private async void btnSaude_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new escolha());
    }


    private async void btnEscolhaTreino_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new escolhatreino());
       

    }
}