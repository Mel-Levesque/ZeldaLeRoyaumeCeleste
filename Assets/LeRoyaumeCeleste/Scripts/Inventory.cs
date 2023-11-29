using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public Image chestplate;
    public Image helmet;
    public Image gaz;
    public Image pants;

    // Update is called once per frame
    void Update()
    {
        int asChestplate = PlayerPrefs.GetInt("Chestplate", 0);
        if (asChestplate == 1)
        {
            chestplate.enabled = true;
        }
        else
        {
            chestplate.enabled = false;
        }

        int asHelmet = PlayerPrefs.GetInt("Helmet", 0);
        if (asHelmet == 1)
        {
            helmet.enabled = true;
        }
        else
        {
            helmet.enabled = false;
        }

        int asGaz = PlayerPrefs.GetInt("Gaz", 0);
        if (asGaz == 1)
        {
            gaz.enabled = true;
        }
        else
        {
            gaz.enabled = false;
        }

        int asPants = PlayerPrefs.GetInt("Pants", 0);
        if (asPants == 1)
        {
            pants.enabled = true;
        }
        else
        {
            pants.enabled = false;
        }
    }
}
