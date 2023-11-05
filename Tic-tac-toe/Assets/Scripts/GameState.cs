using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject Scripthandler;
    public bool isPlayerOne = true;


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
        //Debug.Log(counter + ":   " + GameStateArray[counter]);


        if (GameStateArray[0] == GameStateArray[3] && GameStateArray[0] == GameStateArray[6] && GameStateArray[3] == GameStateArray[6])

        {
            Debug.Log("YOU'RE WINNER");
        }
    }

}
