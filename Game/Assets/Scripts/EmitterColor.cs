using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterColor : MonoBehaviour {

    [HideInInspector]
    public Tone particleColor;

    ParticleSystem PS;

    private void Awake()
    {
        PS = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        ChangeColor();
    } 

    public void ChangeColor()
    {
        ParticleSystem.CollisionModule CM = PS.collision;
        CM.collidesWith = (1 << LayerMask.NameToLayer("Player"));
        switch (particleColor)
        {
            case (Tone.Red):
                {
                    CM.collidesWith = (1 << LayerMask.NameToLayer("RedShield"));
                    PS.startColor = Color.red;
                    break;
                }
            case (Tone.Green):
                {
                    CM.collidesWith = (1 << LayerMask.NameToLayer("GreenShield"));
                    PS.startColor = Color.green;
                    break;
                }
            case (Tone.Blue):
                {
                    CM.collidesWith = (1 << LayerMask.NameToLayer("BlueShield"));
                    PS.startColor = Color.blue;
                    break;
                }
        }
    }

}
