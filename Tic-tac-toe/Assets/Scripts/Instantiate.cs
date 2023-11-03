using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject cross;
    public GameObject circle;
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) //Balegér
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                /* TODO: megoldani, hogy layer használata nélkül meg tudjam különböztetni a kockákat a gridtõl
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Playarea"))
                {
                    Debug.Log("Raycast hit:  " + hit.collider.gameObject.name);
                    Instantiate(cross, hit.collider.gameObject.transform.position, Quaternion.identity);
                }
                */

                Instantiate(cross, hit.collider.gameObject.transform.position, Quaternion.identity);
            }
        }


        if (Input.GetMouseButtonDown(1)) //Jobbegér
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
