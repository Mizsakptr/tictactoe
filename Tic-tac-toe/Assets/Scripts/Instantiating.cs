using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiating : MonoBehaviour
{
    public GameObject cross;
    public GameObject circle;
    
    public GameObject Scripthandler;
    public bool isPlayerOne;

    private void Start()
    {
        isPlayerOne = Scripthandler.GetComponent<GameState>().isPlayerOne;
    }
    

    void Update()
    {       

        if (Input.GetMouseButtonDown(0)) 
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea") && isPlayerOne)
            {
               
                Instantiate(cross, hit.collider.gameObject.transform.position, Quaternion.identity);
                Debug.Log(isPlayerOne);              

            }
            

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea") && !isPlayerOne)
            {

                Instantiate(circle, hit.collider.gameObject.transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                Debug.Log(isPlayerOne);                

            }

            isPlayerOne = !isPlayerOne;
        }
        
    }
}
