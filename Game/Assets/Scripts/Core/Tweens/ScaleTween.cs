using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tweens
{
	public class ScaleTween : DelayAndCurveTween<ScaleTween, Vector3>
	{
		public Transform Transform;

		private Vector3 Shift;
		private Vector3 StartScale;

		public ScaleTween(GameObject target, Vector3 to, float time) 
			: base(to, time)
		{
			this.Transform = target.transform;
			this.StartScale = this.Transform.localScale;
			this.Shift = to - this.Transform.localScale;
		}

		public override Vector3 Value
		{
			get
			{
				return this.Transform.localScale;
			}

			set
			{
				this.Transform.localScale = value;
			}
		}

		protected override Vector3 Update(float t)
		{
			return this.StartScale + this.Shift * t;
		}
	}
}
