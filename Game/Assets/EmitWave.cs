using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitWave : MonoBehaviour {

    ParticleSystem [] PS;

    float lastWaveTime = -1;

    const float maxWaveLength = 2;

    private void Awake()
    {
        PS = GetComponentsInChildren<ParticleSystem>();
    }
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0)||(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began ) || Input.GetKeyDown(KeyCode.Space))
        {
            if (lastWaveTime != -1)
            {
                if(Time.time - lastWaveTime < maxWaveLength)
                {
                    foreach (var item in PS)
                    {
                        item.startColor = Color.HSVToRGB((Time.time - lastWaveTime) / maxWaveLength, .8f, .8f);
                    }
                }
                else
                {
                    foreach (var item in PS)
                    {
                        item.startColor = new Color(1, 1, 1);
                    }
                }

            }
            foreach (var item in PS)
            {
                item.Emit(300);
            }
            lastWaveTime = Time.time;
        }	
	}
}
