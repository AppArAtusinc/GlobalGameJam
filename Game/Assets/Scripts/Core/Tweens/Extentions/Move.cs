using Tweens;
using UniRx;
using UnityEngine;

namespace CoroutineTween.Extentions
{
	public static class MoveExtention
	{
		public static MoveTween Move(this GameObject target, Vector3 to, float time)
		{
			var tween = new MoveTween(target, to, time);
			tween.Start().Run();
			return tween;
		}
	}
}
