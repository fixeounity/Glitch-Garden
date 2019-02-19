using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] float health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float deathVFXDestroyDelay = 2f;

    private void Die()
    {
        PlayDeathVFX();
        Destroy(gameObject);
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();

        }
    }

    private void PlayDeathVFX()
    {
        if (!deathVFX) return;
        Instantiate(deathVFX, transform.position, transform.rotation);
    }


}
