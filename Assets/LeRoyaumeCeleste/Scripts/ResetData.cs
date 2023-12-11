using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    GameObject textGameInfo;

    void Start()
    {
        textGameInfo = GameObject.Find("GameInfo");
        textGameInfo.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerCapsule")
        {
            PlayerPrefs.SetInt("Chestplate", 0);
            PlayerPrefs.SetInt("Helmet", 0);
            PlayerPrefs.SetInt("Gaz", 0);
            PlayerPrefs.SetInt("Pants", 0);
            PlayerPrefs.SetInt("Rupees", 0);
            PlayerPrefs.Save();
            textGameInfo.GetComponent<TMPro.TextMeshProUGUI>().text = "Pour passer au niveau suivant dirige toi vers le bloc rouge !";
            textGameInfo.SetActive(true);
            StartCoroutine(DisableTextAfterSeconds(5f));
        }
    }

    
    private IEnumerator DisableTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        textGameInfo.SetActive(false); // Désactivez le texte après le délai spécifié
    }
}
