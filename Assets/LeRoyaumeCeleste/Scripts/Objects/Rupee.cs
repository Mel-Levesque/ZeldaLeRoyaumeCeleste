using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    { //attacking
        Debug.Log("OnTriggerEnter");
        if (other.name == "PlayerCapsule")
        {
            PlayerPrefs.SetInt("Rupees", PlayerPrefs.GetInt("Rupees", 0) + 1);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
