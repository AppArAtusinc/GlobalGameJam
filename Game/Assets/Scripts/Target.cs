using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Target : MonoBehaviour
{
	public GameObject ObstacleTemplate;

	private void Awake()
	{
	}

	private void Start()
	{
		this.Setup(6);
	}

	public void Setup(int layers)
	{
		float initValue = 1f;
		float progretion = 0.5f;
		for (int i = 0; i < layers; i++)
		{
			var obstacle = this.ObstacleTemplate.Create<Obstacle>(new Vector3(0, -(initValue - 1), 0), this.transform);
			obstacle.Tone = Utils.Tones.GetRandom();
			obstacle.transform.localScale *= initValue;
			initValue += progretion;
		}
	}
}
