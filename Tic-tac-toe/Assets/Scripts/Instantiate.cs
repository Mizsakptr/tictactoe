using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject cross;
    public GameObject circle;
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Baleg�r
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                /* TODO: megoldani, hogy layer haszn�lata n�lk�l meg tudjam k�l�nb�ztetni a kock�kat a gridt�l
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea"))
                {
                    Debug.Log("Raycast hit:  " + hit.collider.gameObject.name);
                    Instantiate(cross, hit.collider.gameObject.transform.position, Quaternion.identity);
                }
                */

                Instantiate(cross, hit.collider.gameObject.transform.position, Quaternion.identity);
            }
        }


        if (Input.GetMouseButtonDown(1)) //Jobbeg�r
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                /*
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea"))
                {
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                    Instantiate(circle, hit.collider.gameObject.transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                }
                */

                Instantiate(circle, hit.collider.gameObject.transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
            }
        }

    }
}
