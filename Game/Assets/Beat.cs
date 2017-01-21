using System;
using System.Collections;
using UnityEngine;

public class Beat : MonoBehaviour {

	ParticleSystem PS;
	AudioSource AS;
	float frequency;

	bool playNow=true;

	private void Awake()
	{
		AS = GetComponent<AudioSource>();
		PS = GetComponent<ParticleSystem>();
		frequency = GetComponent<AudioSource>().clip.length;
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(Emit());	
	}

	private IEnumerator Emit()
	{
		while (true)
		{
			playNow = UnityEngine.Random.value > .5f;
			PS.startColor = Color.HSVToRGB(frequency, 1, .8f);
			AS.mute = !playNow;
			if (playNow)
			{
				PS.Emit(100);
			}
			yield return new WaitForSeconds(frequency);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
