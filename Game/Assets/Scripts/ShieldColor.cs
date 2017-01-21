using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tone
{
    Red,
    Green,
    Blue
}

public class ShieldColor : MonoBehaviour {

    public bool isPlayer = false;

    ParticleSystem[] PS;

    private void Awake()
    {
        PS = GetComponentsInChildren<ParticleSystem>();
        ChangeColor();
    }

   

    public Tone shieldColor;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) &&isPlayer)
        {
            SwitchShield();
        }
    }

    private void SwitchShield()
    {
        switch (shieldColor)
        {
            case (Tone.Red): shieldColor = Tone.Green; break;
            case (Tone.Green): shieldColor = Tone.Blue; break;
            case (Tone.Blue): shieldColor = Tone.Red; break;
        }
        ChangeColor();
    }

    public void ChangeColor()
    {
        switch (shieldColor)
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
