using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class SwordScript : MonoBehaviour
{

    public float attackDelay = 0.4f;
    public float attackSpeed = 0.4f;

    bool attacking = false;
    bool readyToAttack = true;
    int attackCount;

    private int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Animator_bool = ");
        //Debug.Log(gameObject.GetComponent<Animator>().GetBool("IsMainAttack"));
    }

    private void OnTriggerEnter(Collider other)
    { //attacking
        Debug.Log("Hit");
        Debug.Log("other.tag = ");
        Debug.Log(other.tag);
        if (other.tag == "BlueMonster" && gameObject.GetComponent<Animator>().GetBool("IsMainAttack")) //
        {
            Debug.Log("Hit BlueMonster");
            //TakeDamage
            other.GetComponent<BlueMonster>().TakeDamage(damage);
        }
        //gameObject.GetComponent<Animator>().SetBool("IsMainAttack", false);
    }
}
