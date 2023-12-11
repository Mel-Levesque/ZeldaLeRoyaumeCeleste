using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NiveauMenu : MonoBehaviour
{
    public string NomDeScene;
    // Start is called before the first frame update
    public void AllerAuNiveau()
    {
        SceneManager.LoadScene(NomDeScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        AllerAuNiveau();
    }  
}
