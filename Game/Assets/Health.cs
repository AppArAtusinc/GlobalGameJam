using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour {

    public float MAX_HEALTH = 100;

    protected float health;

    protected virtual void OnEnable()
    {
        health = MAX_HEALTH;
    }

    public virtual void Damage(float damage)
    {
        health -= damage;

        health = Mathf.Clamp(health, 0, MAX_HEALTH);

        Debug.LogFormat("{0} Health = {1}",gameObject.name, health);

        if (health <= 0)
        {
            Die();
        }
    }

    public abstract void Die();

    public void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
