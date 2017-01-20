using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Tone
{
	Red,
	Green,
	Blue,
	Purpure
}

public class WaveEmiter : MonoBehaviour
{
	public ParticleSystem System;
	public static Dictionary<Tone, ParticleSystem> Emiters;

	private void Awake()
	{
		var emiters = Utils.Tones.Select(tone =>
		{
			var emitor = GameObject.Instantiate<ParticleSystem>(this.System);
			emitor.gameObject.transform.parent = this.transform;
			emitor.gameObject.transform.localPosition = Vector3.zero;
			emitor.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
			emitor.startColor = tone.ToColor();
			return emitor;
		}).ToArray();

		Emiters = new Dictionary<Tone, ParticleSystem>();
		for (int i = 0; i < Utils.Tones.Length; i++)
			Emiters[(Tone)i] = emiters[i];
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
			case Tone.Red:
				return Color.red;
			case Tone.Green:
				return Color.green;
			case Tone.Blue:
				return Color.blue;
			case Tone.Purpure:
				return new Color(255, 0, 255);
			default:
				throw new NotSupportedException();
		}
	}
}