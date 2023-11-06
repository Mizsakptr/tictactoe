using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiating : MonoBehaviour
{
    public GameObject cross;
    public GameObject circle;    
    public GameObject Scripthandler;

    public bool isPlayerOne;
    public bool playerOneWon;
    public bool playerTwoWon;
    public bool isDraw;


    void Start()
    {
        isPlayerOne = Scripthandler.GetComponent<GameState>().isPlayerOne;
    }
    

    void Update()
    {

        playerOneWon = Scripthandler.GetComponent<GameState>().playerOneWon;
        playerTwoWon = Scripthandler.GetComponent<GameState>().playerTwoWon;
        isDraw = Scripthandler.GetComponent<GameState>().isDraw;

        if (Input.GetMouseButtonDown(0) && !playerOneWon && !playerTwoWon) 
        {
           
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;          
            

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea") && isPlayerOne)
            {
                Ray ray2 = new Ray(hit.transform.position, transform.up);
                RaycastHit hit2;
                if(!Physics.Raycast(ray2, out hit2))
                {
                    Instantiate(cross, hit.collider.gameObject.transform.position, Quaternion.identity);
                    isPlayerOne = !isPlayerOne;
                }                       

            }
            

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea") && !isPlayerOne)
            {

                Ray ray2 = new Ray(hit.transform.position, transform.up);
                RaycastHit hit2;
                if (!Physics.Raycast(ray2, out hit2))
                {
                    Instantiate(circle, hit.collider.gameObject.transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                    isPlayerOne = !isPlayerOne;
                }                
                
            }            

        }

      
    }
}
