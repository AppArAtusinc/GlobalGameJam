using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

    protected override void OnEnable()
    {
        base.OnEnable();
        UiManager.instance.SetHealthLevel(health / MAX_HEALTH);
    }

    public override void Damage(float damage)
    {
        base.Damage(damage);
        UiManager.instance.SetHealthLevel(health / MAX_HEALTH);
    }

    public override void Die()
    {
        GetComponent<Animator>().SetTrigger("Die");
    }



}
