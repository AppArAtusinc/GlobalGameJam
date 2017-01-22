using Tweens;
using UnityEngine;

namespace CoroutineTween.Extentions
{
	public static class ColorExtention
	{
		public static ColorTween Color(this GameObject target, Color to, float time)
		{
			Renderer renderer = target.GetComponent<Renderer>() ?? target.GetComponentInChildren<Renderer>();
			var tween = new ColorTween(renderer, to, time);
			tween.Start().Run();
			return tween;
		}
	}
}
