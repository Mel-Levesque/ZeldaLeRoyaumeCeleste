using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class BlueMonster : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public async void TakeDamage(int damage)
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
            await Delay(2f);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Damage !");
            //Hit anim
            animator.SetTrigger("Damage");
        }
    }

    private void OnTriggerEnter(Collider other)
    { //attacking
        if (other.name == "PlayerCapsule")
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.DecreaseHealth();
                Debug.Log("Hit player test");
            }
        }
    }

    private async Task Delay(float seconds)
    {
        await Task.Delay((int)(seconds * 1000));
    }
}
