using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRune : MonoBehaviour
{
    //public StarterAssets starterAssetsInputs;

    GameObject textRune;
    float objectiveY;
    //MonoBehaviour starterAssetsInputs;
    bool isActivate = false;

    Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        textRune = GameObject.Find("RotateRune");
        textRune.SetActive(false);
        doorAnimator = GameObject.Find("Door_start").GetComponent<Animator>();
        //starterAssetsInputs = gameObject.GetComponent<StarterAssetsInputs>();
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

        checkRuneRotation();

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10))
        {
            Debug.Log("YOU SEE " + hit.collider.gameObject);
        }

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.collider.gameObject.CompareTag("Rune"))
        {
            GameObject lookedObj = hit.collider.gameObject;
            Debug.Log("YOU SEE RUNE " + lookedObj);

            int isRotateRune = PlayerPrefs.GetInt("isRotateRune", 0);

            if (isRotateRune > 0 && !doorAnimator.GetBool("IsOpenDoor"))
            {
                lookedObj.GetComponent<AudioSource>().Play();
                lookedObj.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
                //isRotateRune = true;
                PlayerPrefs.SetInt("isRotateRune", 0);
                PlayerPrefs.Save();
            }

            textRune.SetActive(true);
        }
        else
        {
            textRune.SetActive(false);
        }

    }

    private void checkRuneRotation()
    {
        Debug.Log("TEST DE LA POSITION !!");
        GameObject rune1 = GameObject.Find("CMDL_73F36E22.001");
        GameObject rune2 = GameObject.Find("CMDL_E6C4B13E");
        GameObject rune3 = GameObject.Find("CMDL_73F36E22");
        GameObject rune4 = GameObject.Find("CMDL_E6C4B13E.001");

        float rune1Y = rune1.transform.rotation.eulerAngles.y;
        float rune2Y = rune2.transform.rotation.eulerAngles.y;
        float rune3Y = rune3.transform.rotation.eulerAngles.y;
        float rune4Y = rune4.transform.rotation.eulerAngles.y;

        //Debug.Log("LA POSITION DES RUNES: rune1Y=" + rune1Y + " rune2Y=" + rune2Y + " rune3Y=" + rune3Y + " rune4Y=" + rune4Y);

        if (rune1Y.ToString() == "55,12771" && rune2Y.ToString() == "10,23085" && rune3Y.ToString() == "338,4933" && rune4Y.ToString() == "93,34542")
        {
            //Debug.Log("BONNE POSITION !!");
            doorAnimator.SetBool("IsOpenDoor", true);
            GameObject.Find("Door_start").GetComponent<AudioSource>().Play();
        }
    }
}
