using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
	public AudioClip[] Pain;
	public AudioClip[] Death;
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
		this.AudioSource.Stop();
		this.AudioSource.PlayOneShot(this.Death.GetRandom());
		GameObject.FindObjectOfType<Spawner>().Reload(3);
		GetComponent<Animator>().SetTrigger("Die");
	}
}
