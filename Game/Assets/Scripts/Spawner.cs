using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] HardEnimies;
	public GameObject[] NormalEnimies;
	public GameObject[] EasyEnimies;

	public int UseEasy;
	public int UseNormal;
	public int EnemyNumber;
	private PlayerHealth player;
	private int enimiesOnArena;

	private IEnumerator Start()
	{
		this.enimiesOnArena = 0;
		this.player = GameObject.FindObjectOfType<PlayerHealth>();

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

	private void Spawn(GameObject enemyTemplate)
	{
		this.enimiesOnArena++;
		var position = new Vector3(UnityEngine.Random.value * 15, 0, UnityEngine.Random.value * 15);
		while (Vector3.Distance(this.player.transform.position, position) < 2)
			position = new Vector3(UnityEngine.Random.value * 15, 0, UnityEngine.Random.value * 15);

		var enemy = enemyTemplate.Create(position).GetComponentInChildren<EnemyHealth>();
		enemy.OnDeath += this.Enemy_OnDeath;
	}

	private void Enemy_OnDeath(EnemyHealth enemy)
	{
		this.enimiesOnArena--;
		enemy.OnDeath -= this.Enemy_OnDeath;
	}
}
