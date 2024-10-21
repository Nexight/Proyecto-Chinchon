using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Carta
{
    public string Palo { get; set; }
    public int Valor { get; set; }

    public Carta(string palo, int valor)
    {
        Palo = palo;
        Valor = valor;
    }
}
public class Mazo
{
    private List<Carta> cartas;

    public Mazo()
    {
        cartas = new List<Carta>();
        string[] palos = { "Oros", "Copas", "Espadas", "Bastos" };
        for (int i = 1; i <= 12; i++)
        {
            foreach (string palo in palos)
            {
                cartas.Add(new Carta(palo, i));
            }
        }
        Mezclar();
    }
    public void Mezclar()
    {
        Random rng = new Random();
        cartas = cartas.OrderBy(c => rng.Next()).ToList(); //ordenar la lista de de manera aleatoria
    }

    public Carta RepartirCarta()
    {
        if (cartas.Count == 0)
            return null;

        Carta carta = cartas[0];
        cartas.RemoveAt(0); //elimina las cartas que salieron del mazo
        return carta;
    }
}
public class Jugador
{
    public string Nombre { get; set; }
    public List<Carta> Mano { get; set; }

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Mano = new List<Carta>();
    }

    public void RecibirCarta(Carta carta)
    {
        Mano.Add(carta);
    }

    public void MostrarMano()
    {
        Console.WriteLine($"{Nombre}'s mano:");
        foreach (var carta in Mano)
        {
            Console.WriteLine(carta);
        }
    }
}