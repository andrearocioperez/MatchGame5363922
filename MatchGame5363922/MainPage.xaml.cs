using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Timers;


namespace MatchGame5363922;

public partial class MainPage : ContentPage
{
    //Declaramos las variables que utilizaremos
    IDispatcherTimer timer;
    int milisegundos;
    int pares;
    //int count = 0;
    public MainPage()
	{
        //Con la variable timer declaramos como se mostrara el tiempo usando las propiedades
        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(.1);
        timer.Tick += Timer_Tick;
        InitializeComponent();
		//Se agrega el metodo para mostrar el juego en pantalla con las figuras
		SetUpGame();

    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
        //count++;

        //if (count == 1)
        //	CounterBtn.Text = $"Clicked {count} time";
        //else
        //	CounterBtn.Text = $"Clicked {count} times";

        //SemanticScreenReader.Announce(CounterBtn.Text);
    }

    //Creamos el Timer_Tick para declarar el proceso que se utilizara para mostrar el tiempo en el label utilizando variables deeclaradas anteriormente
    private void Timer_Tick(object? sender, EventArgs e)
    {
        milisegundos++;
        LabelTime.Text = (milisegundos / 10f).ToString("0.00s");
        if (pares == 8)
        {
            timer.Stop();
            LabelTime.Text = LabelTime.Text + "Muy Bien!! Ha finalizado el juego";
            Tiempo	.IsVisible = true;
        }
    }

    //Metodo que se utilizara para el funcionamiento del juego
    private void SetUpGame()
	{
		List<string> animalEmoji = new List<string>()

        {
            "❤️","❤️",
			"🙈","🙈",
			"🐘","🐘",
			"🦋","🦋",
			"🦒","🦒",
			"🐶","🐶",
			"😁","😁",
			"😥","😥",
        };
		Random random = new Random();
		foreach(Button view in Grid1.Children)
		{
			int index= random.Next(animalEmoji.Count);
			string nextEmoji = animalEmoji[index];
			view.Text = nextEmoji;
			animalEmoji.RemoveAt(index);
		}
        //Declaramos el inicio del tiempo del juego
        timer.Start();
        milisegundos = 0;
        pares = 0;
    }
	Button ultimoButtonCliked;
	bool encontrandoMatch = false;
	
	// dar click al boton se generara el metodo declarado anteriormente
    private void Button_Clicked(object sender, EventArgs e)
    {
		Button button = sender as Button;
		if(encontrandoMatch == false)
		{	
			button.IsVisible = false;
			ultimoButtonCliked= button;
			encontrandoMatch = true;
        }
        else if (button.Text == ultimoButtonCliked.Text)
		{
            pares++;
            button.IsVisible = false;
			encontrandoMatch= false;
        }
        else
		{
			ultimoButtonCliked.IsVisible= true;
			encontrandoMatch = false;
		}
    }

	//Hara referencia al momento de empezar a contar el tiempo en el juego
	private void Button_Clicked_1(object sender, EventArgs e)
	{
        SetUpGame();
        //Declaramos el boton que hara visible  eel tieempo por medio de los metodos
        Tiempo.IsVisible = false;
    }


    private void Button_Clicked_2(object sender, EventArgs e)
    {
		//Dentro del boton agregamos el metodo que dara referencia a reiniciar el juego
		ReiniciarAplicacion();
    }

	//Declaramos el metodo para reiniciar el juego
	private void ReiniciarAplicacion()
	{
		//Con este codigo estamos ordenando y haciedno una instancia para que la pagina principal del programa vuelva a reiniciarse
		Application.Current.MainPage = new MainPage();
	}
}

