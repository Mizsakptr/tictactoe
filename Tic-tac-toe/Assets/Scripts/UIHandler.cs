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

    public GameObject Player1Text;
    public GameObject Player2Text;
    [SerializeField] private Material GridMaterial;

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
        //read Game State Publics
        isPlayerOne = Scripthandler.GetComponent<GameState>().isPlayerOne;
        playerOneWon = Scripthandler.GetComponent<GameState>().playerOneWon;
        playerTwoWon = Scripthandler.GetComponent<GameState>().playerTwoWon;
        isDraw = Scripthandler.GetComponent<GameState>().isDraw;

        //color changing grid and next player text
        if(isPlayerOne)
        {
            GridMaterial.color = Color.blue;
            Player1Text.SetActive(true);
            Player2Text.SetActive(false);
        }
        else
        {
            GridMaterial.color = Color.red;
            Player1Text.SetActive(false);
            Player2Text.SetActive(true);
        }

        //Check for winners
        if (playerOneWon || playerTwoWon || isDraw)
        {
            Player1Text.SetActive(false);
            Player2Text.SetActive(false);
            GameEnd();
        }
        //checks if game is restarted
        if(Scripthandler.GetComponent<GameState>().isReplay)
        {
            PlayerOneWonText.SetActive(false);
            PlayerTwoWonText.SetActive(false);
            DrawText.SetActive(false);
            ReplayWindow.SetActive(false);
            isReplay = false;
        }
    }

    // Pops up the End window and replay option.
    void GameEnd(){
        ReplayWindow.SetActive(true);
        if (playerOneWon){
            PlayerOneWonText.SetActive(true);
        }else if (playerTwoWon){
            PlayerTwoWonText.SetActive(true);
        }else{
            DrawText.SetActive(true);
        }
    }
    //replay button action changes restart to true
    public void ReplayPressed()
    {
        isReplay = true;
    }
}
