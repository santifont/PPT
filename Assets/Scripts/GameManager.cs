using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool turn = true; // true -> player / false -> ai
    bool game = true;

    // MATCH STATISTICS
    private int        round = 1;
    public  int    maxRounds = 0;
    private int playerPoints = 0;
    private int     aiPoints = 0;

    // DATOS DE LA RONDA
    int    playerTurn;
    int    aiTurn;
    string playerHand;

    GameObject        startCanvas; // This screen allows you to choose among three different round options.
    GameObject          endCanvas; // "Play Again" and "Exit" buttons when the game is over.
    GameObject         mainCanvas; // Game shows this canvas when you're playing.
    GameObject      canvasButtons;
    TextMeshProUGUI    canvasText;

    // Start is called before the first frame update
    void Start()
    {
        startCanvas   = GameObject.Find("StartCanvas");
        endCanvas     = GameObject.Find("EndCanvas");
        mainCanvas    = GameObject.Find("Canvas");
        canvasButtons = GameObject.Find("ButtonsPanel");
        canvasText    = GameObject.Find("MainText").GetComponent<TextMeshProUGUI>();
        endCanvas.SetActive(false);
        mainCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Game()
    {
        // 0 -> 2, 1 -> 0, 2 -> 1
        // WELCOME SCREEN
        canvasButtons.SetActive(false);
        canvasText.text = "Welcome to\n Rock-Paper-Scissors!\n" + "This match will take\n" + maxRounds + " rounds.";
        yield return new WaitForSeconds(2f);

        // GAME STARTS
        //while (round <= maxRounds)
        while (game == true)
        {
            Debug.Log("Round " + round);
            // Player's turn
            canvasText.text = "Round " + round + "\nPick an option.";
            canvasButtons.SetActive(true);
            while (turn == true)
            {
                yield return null;
            }
            //AI turn
            canvasButtons.SetActive(false);
            canvasText.text = playerHand + ".\nThe AI is thinking...";
            yield return new WaitForSeconds(2f);
            aiPlay();
            if (playerTurn == 0 && aiTurn == 2 || playerTurn == 1 && aiTurn == 0 || playerTurn == 2 && aiTurn == 1)
            {
                playerPoints++;
                canvasText.text = "Congrats!\nYou won this round!\n" + playerPoints + " - " + aiPoints;
                yield return new WaitForSeconds(2f);
            }
            else if (playerTurn == aiTurn)
            {
                canvasText.text = "It's a tie! \n Current score: " + playerPoints + " - " + aiPoints;
                yield return new WaitForSeconds(2f);
            }
            else
            {
                aiPoints++;
                canvasText.text = "Too bad! AI won this round!\n" + playerPoints + " - " + aiPoints;
                yield return new WaitForSeconds(2f);
            }

            if (aiPoints == maxRounds / 2 + 1 || playerPoints == maxRounds / 2 + 1)
            {
                game = false;
            }
            else if (round < maxRounds)
            {
                round++;
                turn = true;
            }
            else
            {
                game = false;
            }
            
        }

        canvasText.text = "Calculating results...";
        yield return new WaitForSeconds(2f);

        if (playerPoints > aiPoints)
        {
            canvasText.text = "You won!\n" + playerPoints + " - " + aiPoints + "\nRounds played: " + round + " / " + maxRounds;
            endCanvas.SetActive(true);
        }
        else if (aiPoints > playerPoints)
        {
            canvasText.text = "You lost...\n" + playerPoints + " - " + aiPoints + "\nRounds played: " + round + " / " + maxRounds;
            endCanvas.SetActive(true);
        }
        else
        {
            canvasText.text = "You tied with the AI.\n" + playerPoints + " - " + aiPoints + "\nRounds played: " + round + " / " + maxRounds;
            endCanvas.SetActive(true);
        }
    }

    public void aiPlay()
    {
        aiTurn = Random.Range(0, 3);
        //aiTurn = 0; // Para comprobar que el primero que llegue a superar una cantidad concreta de puntos gana la partida directamente.
    }

    public void ThreeRounds()
    {
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        maxRounds = 3;
        StartCoroutine(Game());
    }

    public void FiveRounds()
    {
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        maxRounds = 5;
        StartCoroutine(Game());
    }

    public void SevenRounds()
    {
        startCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        maxRounds = 7;
        StartCoroutine(Game());
    }

    public void Rock()
    {
        playerTurn = 0;
        turn = false;
        playerHand = "Player chose ROCK";
    }

    public void Paper()
    {
        playerTurn = 1;
        turn = false;
        playerHand = "Player chose PAPER";
    }

    public void Scissors()
    {
        playerTurn = 2;
        turn = false;
        playerHand = "Player chose SCISSORS";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("PPT");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
