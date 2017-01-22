using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
	private Animator Animator;

	public static Fader Instance
	{
		get;
		private set;
	}

	private void Start()
	{
		this.Animator = this.GetComponent<Animator>();
		Instance = this;
	}

	public void Fade()
	{
		this.Animator.Play("Fade");
	}

	public void UnFade()
	{
		this.Animator.Play("UnFade");
	}
}
