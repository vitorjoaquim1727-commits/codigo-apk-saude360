
using Saude360.NovaPasta;
using Saude360.Informacoes;

namespace Saude360
{
    public partial class MainPage : ContentPage
    {
        string login = null;

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            
            login = await SecureStorage.Default.GetAsync("Login");
            if (login == "sim")
            {
                btnLogin.Text = "Acessar com a aconta";
            }
        }

        private async void btnAcessar_Clicked(object sender, EventArgs e)
        {
            await SecureStorage.Default.SetAsync("Logado", "0");
            await Navigation.PushAsync(new opicao());
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            await SecureStorage.Default.SetAsync("Logado", "1");

            if (login == null || login == "")
            {
                
                await Navigation.PushAsync(new Login());
            }
            else if (login == "sim")
            {
                btnLogin.Text = "Acessar com a aconta";
                bool obs = await DisplayAlert("Observação", "Gostaria de continuar ou alterar dados", "Continuar", "Alterar");

                if (obs)
                {
                    string senha = await DisplayPromptAsync("Senha", "Digite a senha criada na página de login", accept: "Verificar", cancel: "Cancelar", keyboard: Keyboard.Password);

                    if (senha != null)
                    {
                        if (senha == await SecureStorage.Default.GetAsync("Senha"))
                            await Navigation.PushAsync(new opicao());
                        else
                            await DisplayAlert("Erro", "Senha incorreta!", "OK");
                    }

                    
                }
                else
                {
                    await Navigation.PushAsync(new Login());
                }
                    
            }

        }

        private async void btnApoie_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ApoiasePage());
        }
    }
}
