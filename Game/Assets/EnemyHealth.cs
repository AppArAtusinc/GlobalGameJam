using System;

public class EnemyHealth : Health {

	public event Action<EnemyHealth> OnDeath;

    public override void Die()
    {
		if (this.OnDeath != null)
			this.OnDeath(this);

		Destroy(this.transform.parent.parent.gameObject);
    }
}
