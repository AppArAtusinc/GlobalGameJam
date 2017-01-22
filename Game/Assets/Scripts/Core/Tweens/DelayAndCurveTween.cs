using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoroutineTween.Data;
using CoroutineTween.Extentions;
using UnityEngine;

namespace Tweens
{
	public abstract class DelayAndCurveTween<TTarget, TValue> : Tween<TTarget>
		where TTarget : Tween
	{
		public Curve Curve = Curves.Linear;
		public float Delay;
		public float Time;
		public TValue To;

		public abstract TValue Value
		{
			get;
			set;
		}

		public DelayAndCurveTween(TValue to, float time)
		{
			this.To = to;
			this.Time = time;
		}

		public TTarget SetDelay(float delay)
		{
			this.Delay = delay;

			return this as TTarget;
		}

		public TTarget SetCurve(Curve curve)
		{
			this.Curve = curve;

			return this as TTarget;
		}

		protected override IEnumerator Execute()
		{
			var time = 0.0f;
			while (time < this.Delay)
			{
				time += UnityEngine.Time.deltaTime;
				yield return null;
			}

			time = 0.0f;
			while (time < this.Time)
			{
				this.Value = this.Update(this.Curve.Caclculate(time / this.Time));
				time += UnityEngine.Time.deltaTime;
				yield return null;
			}

			this.Value = this.To;
		}

		protected abstract TValue Update(float t);
	}
}
