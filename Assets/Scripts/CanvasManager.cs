using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonPiedra()
    {
        gameManagerScript.TiradaJugador(0);
    }

    public void BotonPapel()
    {
        gameManagerScript.TiradaJugador(1);
    }

    public void BotonTijera()
    {
        gameManagerScript.TiradaJugador(2);
    }
}
