using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public Tone Tone;

	private void Start()
	{
		this.GetComponentInChildren<MeshRenderer>().material.color = this.Tone.ToColor();
	}

	private void OnParticleCollision(GameObject other)
	{
		var system = other.GetComponent<ParticleSystem>();
		if (system.GetTone() == this.Tone)
			GameObject.Destroy(this.gameObject);
	}
}
