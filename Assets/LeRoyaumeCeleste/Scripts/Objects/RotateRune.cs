using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRune : MonoBehaviour
{
    GameObject textRune;
    float objectiveY;
    // Start is called before the first frame update
    void Start()
    {
        textRune = GameObject.Find("RotateRune");
        textRune.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        // Will contain the information of which object the raycast hit
        RaycastHit hit;

        Debug.Log("YOU SEE");

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            Debug.Log("YOU SEE " + hit.collider.gameObject);
        }

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.collider.gameObject.CompareTag("Rune"))
        {
            GameObject lookedObj = hit.collider.gameObject;
            Debug.Log("YOU SEE RUNE " + lookedObj);
            lookedObj.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);

            textRune.SetActive(true);

            /*switch(hit.collider.gameObject){
                case "CMDL_73F36E22": 
                    break;
                case "CMDL_73F36E22.001": 
                    break;
                case "CMDL_E6C4B13E": 
                    break;
                case "CMDL_E6C4B13E.001": 
                    break;
            }*/
            //this.enabled = false;

            // Starts the countdown to destroy the enemy
            //StartCoroutine(Deactivate());

        }
        else
        {
            textRune.SetActive(false);
        }

    }
}
