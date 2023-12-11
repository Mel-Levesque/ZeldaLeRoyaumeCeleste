using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartpiece : MonoBehaviour
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
        if (other.name == "PlayerCapsule")
        {
            Debug.Log("GetHeart");
            PlayerPrefs.SetInt("Heartpiece", 1);
            PlayerPrefs.Save();
            Debug.Log("DestroyHeart");
            Destroy(gameObject);
        }
    }
}
