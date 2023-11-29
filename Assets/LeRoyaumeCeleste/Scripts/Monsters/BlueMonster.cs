using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMonster : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage");
        HP -= damage;
        Debug.Log("HP = " + HP);
        Debug.Log("damage = " + damage);
        if (HP <= 0)
        {
            Debug.Log("Die !");
            //Death anim
            animator.SetTrigger("Die");
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            Debug.Log("Damage !");
            //Hit anim
            animator.SetTrigger("Damage");
        }
    }
}
