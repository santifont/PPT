using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    int turno = 0; // 0 --> JUGADOR
                   // 1 --> IA

    // DATOS DE LA PARTIDA
    int ronda = 1;
    int victoriasJugador = 0;
    int empates = 0;
    int victoriasIA = 0;

    // DATOS DE LA RONDA
    int tiradaJugador;
    int tiradaIA;

    GameObject      canvasPanel;
    TextMeshProUGUI canvasTexto;

    // Start is called before the first frame update
    void Start()
    {
        canvasPanel = GameObject.Find("PanelBotones");
        canvasTexto = GameObject.Find("TextoPrincipal").GetComponent<TextMeshProUGUI>();

        //Bienvenida(); --> ERROR LLAMAR A LA CORRUTINA COMO UNA FUNCIÓN NORMAL
        StartCoroutine(Bienvenida());
    }

    // Update is called once per frame
    void Update()
    {
        if (turno == 0) // TIRADA JUGADOR
        {

        }
        else // TIRADA IA
        {
            TiradaIA();

            //  CALCULAR QUIEN HA GANADO
            CalculoGanador();
            turno = 0;
        }
    }

    // TIRADA JUGADOR:
        // 0 -- piedra
        // 1 -- papel
        // 2 -- tijera
    public void TiradaJugador(int tirada) 
    {
        tiradaJugador = tirada;
        turno = 1;
    }

    public void TiradaIA()
    {
        tiradaIA = Random.Range(0, 3);
    }

    void CalculoGanador()
    {
       if (tiradaJugador == tiradaIA)
        {
            empates++;
        }
        else if (tiradaJugador == 0 & tiradaIA == 2 || tiradaJugador == 1 && tiradaIA == 0 || tiradaJugador == 2 && tiradaIA == 1)
        {
            victoriasJugador++;
        }
        else
        {
            victoriasIA++;
        }
    }
    
    IEnumerator Bienvenida()
    {
        // 1 -- BIENVENIDA AL JUEGO
        canvasPanel.SetActive(false);
        canvasTexto.text = "BIENVENIDO AL JUEGO PIEDRA-PAPEL-TIJERA";

        // VAMOS A PARAR DE EJECUTAR LA FUNCIÓN
        // DURANTE 2.5 SEGUNDOS
        // UNA VEZ PASADOS, LA FUNCIÓN CONTINUARÁ EJECUTANDOSE
        yield return new WaitForSeconds(2.5f);
        


        // 2 -- ANUNCIAR LA RONDA
        canvasTexto.text = "RONDA " + ronda;
        yield return new WaitForSeconds(2.5f);


        // 3 -- MOSTRAMOS LOS BOTONES
        canvasTexto.text = "ELIGE:";
        canvasPanel.SetActive(true);
    }

    IEnumerator AvanzaRonda()
    {

    }
}
