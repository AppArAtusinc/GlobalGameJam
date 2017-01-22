using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
	public GameObject PlayerTemplate;
	public GameObject[] HardEnimies;
	public GameObject[] NormalEnimies;
	public GameObject[] EasyEnimies;

	public int UseEasy;
	public int UseNormal;
	public int EnemyNumber;

	private GameObject player;
	private int enimiesOnArena;
	private AudioSource AudioSource;

	private IEnumerator Start()
	{
		this.enimiesOnArena = 0;
		this.AudioSource = this.GetComponent<AudioSource>();
		yield return this.SpawnPlayer();

		for (int i = 0; i < this.UseEasy; i++)
		{
			if (this.enimiesOnArena == this.EnemyNumber)
				yield return new WaitWhile(() => this.enimiesOnArena == this.EnemyNumber);

			this.Spawn(this.EasyEnimies.GetRandom());
		}

		for (int i = 0; i < this.UseNormal; i++)
		{
			if (this.enimiesOnArena == this.EnemyNumber)
				yield return new WaitWhile(() => this.enimiesOnArena == this.EnemyNumber);

			this.Spawn(this.NormalEnimies.GetRandom());
		}

		while (true)
		{
			yield return new WaitWhile(() => this.enimiesOnArena >= this.EnemyNumber);
			this.Spawn(this.HardEnimies.GetRandom());
		}
	}

	private IEnumerator SpawnPlayer()
	{
		this.AudioSource.Play();
        //yield return new WaitForSeconds(this.AudioSource.clip.length);
        yield return new WaitForEndOfFrame();
		this.player = this.PlayerTemplate.Create(this.GetPossiblePosition());
		foreach (Transform child in player.transform)
			child.parent = null;
	}

    private void Spawn(GameObject template)
	{
		this.enimiesOnArena++;
		var enimies = GameObject.FindObjectsOfType<EnemyHealth>();
		var position = this.GetPossiblePosition();
		while (Vector3.Distance(this.player.transform.position, position) < 3 || enimies.Any(o => Vector3.Distance(o.transform.position, position) < 2))
			position = this.GetPossiblePosition();

		var enemy = template.Create(position).GetComponentInChildren<EnemyHealth>();
		enemy.OnDeath += this.Enemy_OnDeath;
	}

	private Vector3 GetPossiblePosition()
	{
		return new Vector3(UnityEngine.Random.value * 30 - 15, 0, UnityEngine.Random.value * 30 - 15);
	}

	private void Enemy_OnDeath(EnemyHealth enemy)
	{
		this.enimiesOnArena--;
		enemy.OnDeath -= this.Enemy_OnDeath;
	}

	public void Reload(float delay)
	{
		this.ReloadCoroutine(delay).Run();
	}

	private IEnumerator ReloadCoroutine(float delay)
	{
		Fader.Instance.Fade();
		yield return new WaitForSeconds(delay);
		SceneManager.LoadSceneAsync("Main", LoadSceneMode.Single);
	}
}
