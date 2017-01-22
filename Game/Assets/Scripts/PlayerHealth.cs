using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
	public AudioClip[] Pain;
	private AudioSource AudioSource;

	protected override void OnEnable()
	{
		base.OnEnable();
		UiManager.instance.SetHealthLevel(health / MAX_HEALTH);
	}

	private void Start()
	{
		this.AudioSource = this.GetComponent<AudioSource>();
	}

	public override void Damage(float damage)
	{
		base.Damage(damage);
		UiManager.instance.SetHealthLevel(health / MAX_HEALTH);

		if (!this.AudioSource.isPlaying)
			this.AudioSource.PlayOneShot(this.Pain.GetRandom());
	}

	public override void Die()
	{
		GetComponent<Animator>().SetTrigger("Die");
	}



}
