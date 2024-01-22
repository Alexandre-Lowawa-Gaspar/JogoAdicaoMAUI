namespace JogoAdicaoMAUI
{
    public partial class MainPage : ContentPage
    {
        int score = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void JogarBtn_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            int v1 = random.Next(0, 51);
            int v2 = random.Next(0, 51);
            int total = v1 + v2;
            string texto = await DisplayPromptAsync("Pergunta", $"Quanto é {v1} + {v2}", "Responder", "Cancelar", maxLength: 3,keyboard:Keyboard.Numeric);
            if (texto is not null)
            {
                try
                {
                    int resp = Convert.ToInt32(texto);
                    if (resp == total)
                    {
                        score += 10;
                        texto = "Certo";
                    }
                    else
                    {

                        score -= 10;
                        texto = "Errado";
                    }
                    ScoreLb.Text = score.ToString();
                    await DisplayAlert("Notificação", texto, "Ok");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro", "Insira números", "Ok");
                }
            }

        }

        private async void ZerarBtn_Clicked(object sender, EventArgs e)
        {
            bool resp = await DisplayAlert("Score", "Quer zerar o score?", "Sim", "Não");
            if (resp)
            {
                score = 0;
                ScoreLb.Text = "000";
            }
        }

    }

}
