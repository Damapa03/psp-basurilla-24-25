using HilosParaTodos;

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia de EventManager
        var eventManager = new EventManager<string>();

        // Suscripciones globales
        eventManager.Subscribe(arg => Console.WriteLine($"Suscriptor A para: {arg}"));
        eventManager.Subscribe(arg => Console.WriteLine($"Suscriptor B para: {arg}"));

        // Crear los hilos
        MiHilo t1 = new MiHilo("x", eventManager);
        MiHilo t2 = new MiHilo("y", eventManager);

        // Nueva suscripción después de crear los hilos
        eventManager.Subscribe(arg => Console.WriteLine($"Suscriptor C para: {arg}"));

        // Iniciar los hilos
        t1.Start();
        t2.Start();
    }
}