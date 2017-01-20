using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Tone
{
	Blue,
	Green,
	Red
}

public class WaveEmiter : MonoBehaviour
{
	public ParticleSystem System;
	public static Dictionary<Tone, ParticleSystem> Emiters;

	private void Awake()
	{
		var tones = new[] { Tone.Blue, Tone.Green, Tone.Red };
		var emiters = tones.Select(tone =>
		{
			var emitor = GameObject.Instantiate<ParticleSystem>(this.System);
			emitor.gameObject.transform.parent = this.transform;
			emitor.gameObject.transform.localPosition = Vector3.zero;
			emitor.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
			emitor.startColor = tone.ToColor();
			return emitor;
		}).ToArray();

		Emiters = new Dictionary<Tone, ParticleSystem>();
		Emiters[Tone.Blue] = emiters[0];
		Emiters[Tone.Green] = emiters[1];
		Emiters[Tone.Red] = emiters[2];
	}

	public void Emit(Tone tone)
	{
		Emiters[tone].Emit(100);
	}

}


public static class WaveEmiterHelper
{
	public static Tone GetTone(this ParticleSystem system)
	{
		return WaveEmiter.Emiters.First(o => o.Value == system).Key;
	}

	public static Color ToColor(this Tone tone)
	{
		switch (tone)
		{
			case Tone.Blue:
				return Color.blue;
			case Tone.Green:
				return Color.green;
			case Tone.Red:
				return Color.red;
			default:
				throw new NotSupportedException();
		}
	}
}