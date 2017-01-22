using System;
using UnityEngine;

public class EnemyHealth : Health {

	public event Action<EnemyHealth> OnDeath;

    public override void Damage(float damage)
    {
        base.Damage(damage);
        UiManager.instance.score += 25;
    }

    public override void Die()
    {
        UiManager.instance.score += 500;

        if (this.OnDeath != null)
			this.OnDeath(this);
        transform.parent.parent.GetComponent<Animator>().SetTrigger("Die");
        Invoke("Kill", .4f);
    }

    void Kill()
    {
        Destroy(this.transform.parent.parent.gameObject);
    }

}
