using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    int turno = 0; // 0 -> Turno JUGADOR,  1 -> Turno IA

    // DATOS DE LA PARTIDA

    int ronda = 1;
    int victoriasJugador = 0;
    int victoriasIA = 0;
    int empates = 0;

    // DATOS DE LA RONDA
    int tiradaJugador;
    int tiradaIA;

    GameObject canvasPanel;
    GameObject canvasTexto;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasPanel = GameObject.Find("PanelBotones");
        canvasTexto = GameObject.Find("TextoPrincipal");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
