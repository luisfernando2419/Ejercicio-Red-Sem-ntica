namespace RedSemanticaEjemplo
{
    public class Program
    {
        static void Main(string[] args)
        {
            RedSemantica red = new RedSemantica();

            // Creación de nodos principales
            Nodo perro = red.CrearNodo("Perro");
            Nodo animal = red.CrearNodo("Animal");
            Nodo tiene = red.CrearNodo("Tiene");
            Nodo cuatroPatas = red.CrearNodo("Cuatro Patas");


            Nodo annimal = red.CrearNodo("Animal");
            Nodo ave = red.CrearNodo("Ave");
            Nodo mamifero = red.CrearNodo("Mamifero");
            Nodo avestruz = red.CrearNodo("Avestruz");
            Nodo albatros = red.CrearNodo("Albatros");
            Nodo ballena = red.CrearNodo("Ballena");
            Nodo tigre = red.CrearNodo("Tigre");

            // Agregar arcos principales
            animal.AgregarArco(ave, "tipo de");
            animal.AgregarArco(mamifero, "tipo de");
            ave.AgregarArco(avestruz, "tipo de");
            ave.AgregarArco(albatros, "tipo de");
            mamifero.AgregarArco(ballena, "tipo de");
            mamifero.AgregarArco(tigre, "tipo de");

            // Características y habilidades específicas
            perro.AgregarArco(animal, "es un");
            perro.AgregarArco(cuatroPatas, "tiene");

            avestruz.AgregarArco(new Nodo("patas largas"), "tiene");
            avestruz.AgregarArco(new Nodo("no puede"), "vuela");
            albatros.AgregarArco(new Nodo("muy bien"), "vuela");
            ave.AgregarArco(new Nodo("plumas"), "tiene");
            ave.AgregarArco(new Nodo("pone huevos"), "pone");
            mamifero.AgregarArco(new Nodo("pelo"), "tiene");
            tigre.AgregarArco(new Nodo("carne"), "come");
            ballena.AgregarArco(new Nodo("piel"), "tiene");
            ballena.AgregarArco(new Nodo("mar"), "vive en");

            red.MostrarRed();
        }
    }

    public class Nodo
    {
        public string Etiqueta { get; set; }
        public List<Arco> Arcos { get; set; }

        public Nodo(string etiqueta)
        {
            Etiqueta = etiqueta;
            Arcos = new List<Arco>();
        }

        public void AgregarArco(Nodo destino, string etiquetaArco)
        {
            Arcos.Add(new Arco(this, destino, etiquetaArco));
        }
    }

    public class Arco
    {
        public Nodo Origen { get; set; }
        public Nodo Destino { get; set; }
        public string Etiqueta { get; set; }

        public Arco(Nodo origen, Nodo destino, string etiqueta)
        {
            Origen = origen;
            Destino = destino;
            Etiqueta = etiqueta;
        }

        public override string ToString()
        {
            return $"{Origen.Etiqueta} -- {Etiqueta} --> {Destino.Etiqueta}";
        }
    }

    public class RedSemantica
    {
        public List<Nodo> Nodos { get; set; }

        public RedSemantica()
        {
            Nodos = new List<Nodo>();
        }

        public Nodo CrearNodo(string etiqueta)
        {
            var nodo = new Nodo(etiqueta);
            Nodos.Add(nodo);
            return nodo;
        }

        public void MostrarRed()
        {
            foreach (Nodo nodo in Nodos)
            {
                foreach (var arco in nodo.Arcos)
                {
                    Console.WriteLine(arco);
                }
            }
        }
    }
}
