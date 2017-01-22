using Tweens;
using UnityEngine;

namespace CoroutineTween.Extentions
{
	public static class ScaleExtentions
	{
		public static ScaleTween Scale(this GameObject target, Vector3 to, float time)
		{
			var tween = new ScaleTween(target, to, time);
			tween.Start().Run();
			return tween;
		}
	}
}
