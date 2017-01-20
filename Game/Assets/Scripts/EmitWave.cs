using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitWave : MonoBehaviour
{
	public WaveEmiter WaveEmiter;
	float lastWaveTime;

	void Update()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
		{
			this.WaveEmiter.Emit(this.CalculateTone(Time.time - lastWaveTime));
			lastWaveTime = Time.time;
		}
	}

	private Tone CalculateTone(float lastWaveTime)
	{
		const float maxDelay = 2f;
		var toneCount = Utils.Tones.Length;
		var delta = maxDelay / toneCount;

		return (Tone)(int)(Mathf.Clamp(lastWaveTime / delta, 0, toneCount - 1));
	}
}
