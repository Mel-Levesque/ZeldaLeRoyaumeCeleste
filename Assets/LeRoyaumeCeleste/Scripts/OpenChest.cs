using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class OpenChest : MonoBehaviour
{
    //public Animator animator;
    // Start is called before the first frame update
    Animator animator;
    Collider collider;
    GameObject chestCube;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider>();
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
                await Delay(2f);
                GameObject.Find("ChestCube").GetComponent<Collider>().enabled = false;
            }
        }
    }

    private async Task Delay(float seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }
}
