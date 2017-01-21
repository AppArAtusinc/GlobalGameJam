using System;
using System.Collections;
using UnityEngine;

public class Beat : MonoBehaviour {

	ParticleSystem PS;
	AudioSource AS;
    EmitterColor EC;

	float frequency;
	bool playNow=true;

	private void Awake()
	{
        EC = GetComponent<EmitterColor>();
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
            EC.particleColor = frequency > .3 ? frequency > .7 ? Tone.Blue : Tone.Green : Tone.Red;
			AS.mute = !playNow;
			if (playNow)
			{
				PS.Emit(1000);
			}
			yield return new WaitForSeconds(frequency);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
