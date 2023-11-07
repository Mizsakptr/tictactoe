using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject Scripthandler;
    public GameObject ReplayWindow;
    public GameObject PlayerOneWonText;
    public GameObject PlayerTwoWonText;
    public GameObject DrawText;

    public bool isPlayerOne = true;
    public bool playerOneWon = false;
    public bool playerTwoWon = false;
    public bool isDraw = false;
    public bool isReplay = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerOne = Scripthandler.GetComponent<GameState>().isPlayerOne;
        playerOneWon = Scripthandler.GetComponent<GameState>().playerOneWon;
        playerTwoWon = Scripthandler.GetComponent<GameState>().playerTwoWon;
        isDraw = Scripthandler.GetComponent<GameState>().isDraw;

        if (playerOneWon || playerTwoWon || isDraw)
        {
            GameEnd();
        }
    }

    // Pops up the End window and replay option.
    void GameEnd()
    {
        ReplayWindow.SetActive(true);
        if (playerOneWon){
            PlayerOneWonText.SetActive(true);
        }else if (playerTwoWon){
            PlayerTwoWonText.SetActive(true);
        }else{
            DrawText.SetActive(true);
        }
    }
    public void ReplayPressed()
    {
        ReplayWindow.SetActive(false);
        if (playerOneWon){
            PlayerOneWonText.SetActive(false);
        }
        else if (playerTwoWon){
            PlayerTwoWonText.SetActive(false);
        }
        else{
            DrawText.SetActive(false);
        }
        isReplay = true;
    }
}
