using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum Simbolo
{
        Espada, Corazon, Diamante, Trebol
}
public class Carta
{
    public int numero;
    public Simbolo simbolo;
}

public class GameManager : MonoBehaviour
{
    public Transform CartasJugadorCanvas;
    private Dictionary<Simbolo, List<Carta>> m_Baraja = new Dictionary<Simbolo, List<Carta>>();
    private List<Carta> m_CartasJugador = new List<Carta>();
    private List<Carta> m_CartasMesa = new List<Carta>();

    private void Start() 
    {
        CrearBaraja();
        RepartirCartasMesa();
        RepartirCartasJugador();
    }

    private void RepartirCartasJugador()
    {
        int i = UnityEngine.Random.Range(0, 3);
        Simbolo simbolo = Simbolo.Espada;
        switch (i)
        {
            case 0: simbolo = Simbolo.Espada; break;
            case 1: simbolo = Simbolo.Trebol; break;
            case 2: simbolo = Simbolo.Corazon; break;
            case 3: simbolo = Simbolo.Diamante; break;
        }

        int posAleatoria = UnityEngine.Random.Range(0, m_Baraja[simbolo].Count - 1);
        m_CartasJugador.Add(m_Baraja[simbolo][posAleatoria]);

        int pos = m_CartasJugador.Count - 1;
        Transform carta = CartasJugadorCanvas.Find($"Carta{pos}");
        SetValoresCarta(m_Baraja[simbolo][posAleatoria], carta);

        m_Baraja[simbolo].RemoveAt(posAleatoria);
    }

    private void RepartirCartasMesa()
    {
        throw new NotImplementedException();
    }

    private void CrearBaraja()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                Carta c = new Carta();
                c.numero = j;
                switch (i)
                {
                    case 0: c.simbolo = Simbolo.Espada; break;
                    case 1: c.simbolo = Simbolo.Trebol; break;
                    case 2: c.simbolo = Simbolo.Corazon; break;
                    case 3: c.simbolo = Simbolo.Diamante; break;
                }

                if (!m_Baraja.ContainsKey(c.simbolo))
                {
                    m_Baraja[c.simbolo] = new List<Carta>();
                }
                m_Baraja[c.simbolo].Add(c);
            }
        }
    }

    private void SetValoresCarta(Carta carta, Transform cartaTransform)
    {
        cartaTransform.Find("Numero").GetComponent<TextMeshProUGUI>().text = carta.numero.ToString();
        cartaTransform.Find("CartaVacia").gameObject.SetActive(false);
    }
}
