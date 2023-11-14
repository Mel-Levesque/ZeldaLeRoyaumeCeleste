using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEquipment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            var particle_equipment = GameObject.Find("Particle System_equiment");
            particle_equipment.GetComponent<Renderer>().enabled = false;

            if (gameObject.tag == "Chestplate")
            {
                PlayerPrefs.SetInt("Chestplate", 1);
                PlayerPrefs.Save();
            }
        }
    }
}
