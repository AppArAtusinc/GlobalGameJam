using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
	public WaveEmiter WaveEmiter;
	public Target Target;

	IEnumerator Start()
	{
		//this.Target.Setup(5);
		this.WaveEmiter.Emit(Tone.Blue);

		yield return new WaitForSeconds(1f);
		this.WaveEmiter.Emit(Tone.Green);

		yield return new WaitForSeconds(1f);
		this.WaveEmiter.Emit(Tone.Red);
	}
}
