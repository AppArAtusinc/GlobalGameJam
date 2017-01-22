using System;
using System.Collections;
using UnityEngine;

public class Beat : MonoBehaviour {

	ParticleSystem PS;
	AudioSource AS;
    EmitterColor EC;

	public float frequency = 1, arcSize;
	bool playNow=true;

	private void Awake()
	{
        EC = GetComponent<EmitterColor>();
		AS = GetComponent<AudioSource>();
		PS = GetComponent<ParticleSystem>();
        EC.particleColor = frequency > .3 ? frequency > .7 ? Tone.Blue : Tone.Green : Tone.Red;
        ParticleSystem.ShapeModule shape = PS.shape;
        shape.arc = arcSize;
    }


    // Use this for initialization
    void Start ()
	{
		StartCoroutine(Emit());	
	}

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
        {
            other.GetComponent<Health>().Damage(5f);
        }
    }

    private IEnumerator Emit()
	{
		while (true)
		{
			playNow = UnityEngine.Random.value > .5f;
			if (playNow)
			{
				AS.Play();
				PS.Emit(500);
			}
			yield return new WaitForSeconds(frequency);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
