internal class Program
{
    private static void Main(string[] args)
    {
        var definiciones = LeerArchivo();

    }

    public static Dictionary<string, string> 
    LeerArchivo()
    {
        Dictionary<string, string> definiciones = new Dictionary<string, string>();

        using (StreamReader lector = new StreamReader("info.txt"))
        {
            string linea;
            while ((linea = lector.ReadLine()) != null)
            {
                string[] partes = linea.Split(new[] { ": " }, StringSplitOptions.None);
                if (partes.Length == 2)
                {
                    string clave = partes[0].Trim();
                    string valor = partes[1].Trim();
                    definiciones[clave] = valor;
                }
            }
        }

        return definiciones;
    }

    public static void AgregarDefinicion(Dictionary<string, string> definiciones)
{
    Console.Write("Ingrese la nueva palabra: ");
    string nuevaPalabra = Console.ReadLine()?.Trim();

    Console.Write("Ingrese la definición: ");
    string nuevaDefinicion = Console.ReadLine()?.Trim();

    if (string.IsNullOrEmpty(nuevaDefinicion))
    {
        Console.WriteLine("La definición no puede estar vacía.");
        return;
    }
    definiciones[nuevaPalabra] = nuevaDefinicion;

    using (StreamWriter escritor = File.AppendText("info.txt"))
    {
        escritor.WriteLine($"{nuevaPalabra}: {nuevaDefinicion}");
    }

    Console.WriteLine("Término agregado correctamente.");
}
}