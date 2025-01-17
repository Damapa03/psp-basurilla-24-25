namespace HilosParaTodos;

public class MiHilo
{
    private Thread hilo;
    private string text;
    private EventManager<string> eventManager;

    public MiHilo(string text, EventManager<string> eventManager)
    {
        this.text = text;
        this.eventManager = eventManager;

        // Suscribirse a los eventos del gestor
        this.eventManager.Subscribe(arg =>
        {
            if (arg == text)
                Console.WriteLine($"Hilo {text}");
        });

        hilo = new Thread(_process);
    }

    public void Start()
    {
        hilo.Start();
    }

    private void _process()
    {
        for (int i = 0; i < 1000; i++) Console.Write(text);

        // Disparar el evento al finalizar
        eventManager.Trigger(text);
        Console.WriteLine($"Ha terminado: {text}");
    }
}