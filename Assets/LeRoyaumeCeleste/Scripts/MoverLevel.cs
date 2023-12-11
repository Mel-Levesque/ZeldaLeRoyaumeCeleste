using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverLevel : MonoBehaviour
{
    GameObject textLevel;

    void Start()
    {
        textLevel = GameObject.Find("LevelInfo");
        textLevel.SetActive(false);
    }

    void Update()
    {
        // Ajoutez ici votre logique de mise à jour si nécessaire.
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "LevelExit")
        {
            int asChestplate = PlayerPrefs.GetInt("Chestplate", 0);
            int asHelmet = PlayerPrefs.GetInt("Helmet", 0);
            int asGaz = PlayerPrefs.GetInt("Gaz", 0);
            int asPants = PlayerPrefs.GetInt("Pants", 0);


            Debug.Log("################################################");
            if (SceneManager.GetActiveScene().buildIndex == 1 && asChestplate == 1) //OK Passage au niveau 2
            {
                Debug.Log("Level 1 terminé");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if(SceneManager.GetActiveScene().buildIndex == 1) //Pas de plastron pour passer au niveau 2
            {
                Debug.Log("Level 1 non terminé");
                textLevel.GetComponent<TMPro.TextMeshProUGUI>().text = "Pour passer au niveau 2, il faut d'abord récupérer le plastron !";
                textLevel.SetActive(true);
                StartCoroutine(DisableTextAfterSeconds(5f));
            }
            else if(SceneManager.GetActiveScene().buildIndex == 2 && asHelmet == 1 && asGaz == 1 && asPants == 1){
                Debug.Log("Level 2 terminé et jeu terminé");
                // show message "Bravo, vous avez terminé le jeu !" et quand on fait echap on quitte le jeu
                textLevel.GetComponent<TMPro.TextMeshProUGUI>().text = "Bravo, vous avez terminé le jeu !";
                textLevel.SetActive(true);
                StartCoroutine(DisableTextAfterSeconds(5f));
                // quitte le jeu
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif


            }
            else if (SceneManager.GetActiveScene().buildIndex == 2){
                textLevel.GetComponent<TMPro.TextMeshProUGUI>().text = "Vous devez récupérer le casque, la bouteille de gaz et le pantalon pour terminer le jeu!";
                textLevel.SetActive(true);
                StartCoroutine(DisableTextAfterSeconds(5f));
            }else{
                Debug.Log("Test");
            }
        }
    }

    private IEnumerator DisableTextAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        textLevel.SetActive(false); // Désactivez le texte après le délai spécifié
    }
}
