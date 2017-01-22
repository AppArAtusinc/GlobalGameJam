using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour {

    ParticleSystem[] PS;

    private void Awake()
    {
        PS = GetComponentsInChildren<ParticleSystem>();
    }

    // Use this for initialization
    void Start ()
    {
        ChangeColor(transform.parent.GetComponentInChildren<EmitterColor>().particleColor);
	}

    public void ChangeColor(Tone color)
    {
        switch (color)
        {
            case (Tone.Red):
                {
                    gameObject.layer = LayerMask.NameToLayer("RedShield");
                    foreach (var particleSystem in PS)
                    {
                        particleSystem.startColor = Color.red;
                    }
                    break;
                }
            case (Tone.Green):
                {
                    gameObject.layer = LayerMask.NameToLayer("GreenShield");
                    foreach (var particleSystem in PS)
                    {
                        particleSystem.startColor = Color.green;
                    }
                    break;
                }
            case (Tone.Blue):
                {
                    gameObject.layer = LayerMask.NameToLayer("BlueShield");
                    foreach (var particleSystem in PS)
                    {
                        particleSystem.startColor = Color.blue;
                    }
                    break;
                }
        }
    }
}
