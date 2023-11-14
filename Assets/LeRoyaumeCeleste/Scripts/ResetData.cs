using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            PlayerPrefs.SetInt("Chestplate", 0);
            PlayerPrefs.Save();
        }
    }
}
