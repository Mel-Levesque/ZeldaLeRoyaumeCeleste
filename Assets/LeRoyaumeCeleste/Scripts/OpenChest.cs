using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class OpenChest : MonoBehaviour
{
    //public Animator animator;
    // Start is called before the first frame update
    Animator animator;
    //Collider colliderG;
    GameObject chestCube;

    AudioSource audioG;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        //colliderG = gameObject.GetComponent<Collider>();
        audioG = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void OnTriggerEnter(Collider other)
    { //attacking
        if (other.name == "PlayerCapsule")
        {
            if (!animator.GetBool("IsOpenChest"))
            {
                animator.SetBool("IsOpenChest", true);
                GameObject.Find("HeartpieceFull").GetComponent<Animator>().SetBool("IsOpenChest", true);
                audioG.Play();
                await Delay(7f);
                GameObject.Find("ChestCube").GetComponent<Collider>().enabled = false;
            }
        }
    }

    private async Task Delay(float seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }
}
