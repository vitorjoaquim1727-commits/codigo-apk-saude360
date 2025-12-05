namespace Saude360.NovaPasta;

public partial class Login : ContentPage
{
    string verificaSexo;
    string verificaBiotipo;
    string login;
    public Login()
	{
		InitializeComponent();
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        string login = await SecureStorage.Default.GetAsync("Login");

        if(login == "sim")
        {
            dadosCadastrados();
            btnFinalizar.Text = "Continuar e Alterar";
        }
    }

    private void txtSenhas_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length > 5)
        {
            lblRecado.IsVisible = true;
        }
        else if (e.NewTextValue.Length <= 0 || e.NewTextValue.Length == null)
        {
            lblRecado.Text = "É necessário criar uma senha";
            lblRecado.IsVisible = true;
        }
        else
        {

        }
    }

    private void VerificaSexo (object sender, EventArgs e)
    {
        if (sexoM.IsChecked)
        {
            verificaSexo = sexoM.Content.ToString();
        }
        else if (sexoF.IsChecked) { 
            verificaSexo = sexoF.Content.ToString();
        }
        else
        {

            DisplayAlert("Alerta!!", "Você esqueceu de assinalar o seu sexo", "OK");
        }
    }

    private void VerificaBiotipo(object sender, EventArgs e)
    {
        if (Ectomorfo.IsChecked) {
            verificaBiotipo = Ectomorfo.Content.ToString();
        }
        else if (Mesomorfo.IsChecked)
        {
            verificaBiotipo = Mesomorfo.Content.ToString();
        }
        else if (Endomorfo.IsChecked)
        {
            verificaBiotipo = Endomorfo.Content.ToString();

        }
        else
        {
            DisplayAlert("Alerta!!", "Você esqueceu de assinalar o seu biotipo", "OK");
        }
    }

    private async void btnFinalizar_Clicked(object sender, EventArgs e)
    {
        string login = await SecureStorage.Default.GetAsync("Login"); ;
        string senha = await SecureStorage.Default.GetAsync("Senha");

        if (login != "sim")
        {
            string nome = txtNome.Text;
            string sexo = verificaSexo;
            string peso = txtPeso.Text;
            string meta = txtMeta.Text;
            string biotipo = verificaBiotipo;
            senha = txtSenhas.Text;
            login = "sim";

            await SecureStorage.Default.SetAsync("Nome", nome);
            await SecureStorage.Default.SetAsync("Sexo", sexo);
            await SecureStorage.Default.SetAsync("Peso", peso);
            await SecureStorage.Default.SetAsync("MetaP", meta);
            await SecureStorage.Default.SetAsync("Biotipo", biotipo);
            await SecureStorage.Default.SetAsync("Senha", senha);
            await SecureStorage.Default.SetAsync("Login", login);

            await DisplayAlert("Login", "Login criado com sucesso, agora pode explorar todas as funcionalidade, e os resultados serão salvo", "OK");
            await Navigation.PushAsync(new MainPage());
        }
        else if (login == "sim" && senha == txtSenhas.Text)
        {
            string nome = txtNome.Text;
            string sexo = verificaSexo;
            string peso = txtPeso.Text;
            string meta = txtMeta.Text;
            string biotipo = verificaBiotipo;
            senha = txtSenhas.Text;
            login = "sim";

            await SecureStorage.Default.SetAsync("Nome", nome);
            await SecureStorage.Default.SetAsync("Sexo", sexo);
            await SecureStorage.Default.SetAsync("Peso", peso);
            await SecureStorage.Default.SetAsync("MetaP", meta);
            await SecureStorage.Default.SetAsync("Biotipo", biotipo);
            await SecureStorage.Default.SetAsync("Senha", senha);
            await SecureStorage.Default.SetAsync("Login", login);

            await DisplayAlert("Login", "Login alterado com sucesso", "OK");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            segurançaSenha();
        }
    }

    private async void dadosCadastrados()
    {
        string nome = await SecureStorage.Default.GetAsync("Nome");
        string sexo = await SecureStorage.Default.GetAsync("Sexo");
        string peso = await SecureStorage.Default.GetAsync("Peso"); 
        string meta = await SecureStorage.Default.GetAsync("MetaP");
        string biotipo = await SecureStorage.Default.GetAsync("Biotipo");
        string senha = await SecureStorage.Default.GetAsync("Senha");

        txtNome.Text = nome;
        verificaSexo = sexo;
        txtPeso.Text = peso;
        txtMeta.Text = meta;
        verificaBiotipo = biotipo;
        txtSenhas.Text = senha;


        if (sexoM.Content.ToString() == verificaSexo)
        {
            sexoM.IsChecked = true;
        }
        else if (sexoF.Content.ToString() == verificaSexo)
        {
            sexoF.IsChecked = true;
        }
        else
        {
            sexoM.IsChecked = false;
            sexoF.IsChecked = false;
        }


        if (Ectomorfo.Content.ToString() == verificaBiotipo)
        {

            Ectomorfo.IsChecked = true;
        }
        else if (Mesomorfo.Content.ToString() == verificaBiotipo)
        {
            Mesomorfo.IsChecked = true;
        }
        else if (Endomorfo.Content.ToString() == verificaBiotipo)
        {
            Endomorfo.IsChecked = true;
        }
        else
        {
            Ectomorfo.IsChecked = false;
            Mesomorfo.IsChecked = false;
            Endomorfo.IsChecked = false;
        }
    }
    private async void segurançaSenha()
    {
        string senha = await SecureStorage.Default.GetAsync("Senha");

        if (txtSenhas.Text == senha)
        {
            await Navigation.PushAsync(new escolha());
        }
        else
        {
            bool obs = await DisplayAlert("Observação", "A senha foi alterada, por motivo de segurança iremos apagar todas as suas informações!!", "Continuar", "Cancelar");
            if (obs)
            {
                await SecureStorage.Default.SetAsync("Nome", "");
                await SecureStorage.Default.SetAsync("Sexo", "");
                await SecureStorage.Default.SetAsync("Peso", "");
                await SecureStorage.Default.SetAsync("MetaP", "");
                await SecureStorage.Default.SetAsync("Biotipo", "");
                await SecureStorage.Default.SetAsync("Senha", "");
                await SecureStorage.Default.SetAsync("Login", "");

                dadosCadastrados();
            }
            else
            {
                txtSenhas.Text = await SecureStorage.Default.GetAsync("Senha");
                DisplayAlert("Está Seguro", "Seuas informações estão intactas", "Continuar");
            }
        }
    }
}