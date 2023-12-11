using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    GameObject textLevel;

    void Start()
    {
        textLevel = GameObject.Find("LevelInfo");
        textLevel.SetActive(false);
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
            textLevel.GetComponent<TMPro.TextMeshProUGUI>().text = "Pour passer au niveau suivant dirige toi vers le bloc rouge ! Quand tu aura le plastron";
            textLevel.SetActive(true);
            StartCoroutine(DisableTextAfterSeconds(5f));
        }
    }

    
    private IEnumerator DisableTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        textLevel.SetActive(false); // Désactivez le texte après le délai spécifié
    }
}
