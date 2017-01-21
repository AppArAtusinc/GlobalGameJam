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

    public float shieldRechargeTime = 3;

    float chargeLevel = 0;

    ParticleSystem[] PS;

    private void Awake()
    {
        PS = GetComponentsInChildren<ParticleSystem>();
        ChangeColor();
    }

   

    public Tone shieldColor;

    private void Update()
    {
        chargeLevel += Time.deltaTime;
        UiManager.instance.SetShieldLevel(chargeLevel / shieldRechargeTime);

        if(Input.GetKeyDown(KeyCode.Space) &&isPlayer && chargeLevel>=1)
        {
            chargeLevel = 0;
            SwitchShield();
        }
    }

    private void SwitchShield()
    {
        switch (shieldColor)
        {
            case (Tone.Red): shieldColor = Tone.Green; UiManager.instance.SetShieldColor(Color.green); break;
            case (Tone.Green): shieldColor = Tone.Blue; UiManager.instance.SetShieldColor(Color.blue); break;
            case (Tone.Blue): shieldColor = Tone.Red; UiManager.instance.SetShieldColor(Color.red); break;
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
