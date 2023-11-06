using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{   

    //Máté, neked ezek kellenek
    //******************************
    public bool isPlayerOne = true;                
    public bool playerOneWon = false;
    public bool playerTwoWon = false;
    public bool isDraw = false;
    //******************************
    //Ha nem akarod magad elhányni, akkor ennél lentebb ne olvass el semmiféle kódot



    public GameObject Scripthandler;
    public GameObject[] cubes = new GameObject[9];
    String[] GameStateArray = new String[9];
    int counter = 0;

    void Update()
    {
        
        isPlayerOne = Scripthandler.GetComponent<Instantiating>().isPlayerOne;

        Ray ray = new Ray(cubes[counter].transform.position, transform.up);
        Debug.DrawRay(cubes[counter].transform.position, transform.up, Color.red);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("CircleLayer"))
        {
            GameStateArray[counter] = ("Circle");
        }

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("CrossLayer"))
        {
            GameStateArray[counter] = ("Cross");
        }

        counter++;
        if(counter >= 9) {
            counter = 0;
        }

        //Bal függõleges
        if (GameStateArray[0] == ("Cross") && GameStateArray[3] == ("Cross") && GameStateArray[6] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[0] == ("Circle") && GameStateArray[3] == ("Circle") && GameStateArray[6] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Közép függõleges
        if (GameStateArray[1] == ("Cross") && GameStateArray[4] == ("Cross") && GameStateArray[7] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[1] == ("Circle") && GameStateArray[4] == ("Circle") && GameStateArray[7] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Jobb függõleges
        if (GameStateArray[2] == ("Cross") && GameStateArray[5] == ("Cross") && GameStateArray[8] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[2] == ("Circle") && GameStateArray[5] == ("Circle") && GameStateArray[8] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Felsõ sor
        if (GameStateArray[0] == ("Cross") && GameStateArray[1] == ("Cross") && GameStateArray[2] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[0] == ("Circle") && GameStateArray[1] == ("Circle") && GameStateArray[2] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Középsõ sor
        if (GameStateArray[3] == ("Cross") && GameStateArray[4] == ("Cross") && GameStateArray[5] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[3] == ("Circle") && GameStateArray[4] == ("Circle") && GameStateArray[5] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Alsó sor
        if (GameStateArray[6] == ("Cross") && GameStateArray[7] == ("Cross") && GameStateArray[8] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[6] == ("Circle") && GameStateArray[7] == ("Circle") && GameStateArray[8] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Fõátló
        if (GameStateArray[0] == ("Cross") && GameStateArray[4] == ("Cross") && GameStateArray[8] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[0] == ("Circle") && GameStateArray[4] == ("Circle") && GameStateArray[8] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //Mellékátló
        if (GameStateArray[6] == ("Cross") && GameStateArray[4] == ("Cross") && GameStateArray[2] == ("Cross"))
        {
            playerOneWon = true;
        }

        if (GameStateArray[6] == ("Circle") && GameStateArray[4] == ("Circle") && GameStateArray[2] == ("Circle"))
        {
            playerTwoWon = true;
        }

        //isdraw
        if ((GameStateArray[0] == ("Cross") || GameStateArray[0] == ("Circle")) && 
           (GameStateArray[1] == ("Cross") || GameStateArray[1] == ("Circle"))&& 
           (GameStateArray[2] == ("Cross") || GameStateArray[2] == ("Circle"))&& 
           (GameStateArray[3] == ("Cross") || GameStateArray[3] == ("Circle"))&& 
           (GameStateArray[4] == ("Cross") || GameStateArray[4] == ("Circle"))&& 
           (GameStateArray[5] == ("Cross") || GameStateArray[5] == ("Circle"))&&
           (GameStateArray[6] == ("Cross") || GameStateArray[6] == ("Circle"))&& 
           (GameStateArray[7] == ("Cross") || GameStateArray[7] == ("Circle"))&& 
           (GameStateArray[8] == ("Cross") || GameStateArray[8] == ("Circle"))&&
           !playerOneWon && !playerTwoWon)
        {
            isDraw = true;           
        }

        if (isDraw)
            Debug.Log("Draw");
        if (playerOneWon)
            Debug.Log("Player 1 Won");
        if (playerTwoWon)
            Debug.Log("Player 2 Won");

    }

}
