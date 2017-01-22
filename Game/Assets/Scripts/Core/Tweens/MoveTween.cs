using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tweens
{
	public class MoveTween : DelayAndCurveTween<MoveTween, Vector3>
	{
		public Transform Transform;

		private Vector3 Shift;
		private Vector3 StartPosition;

		public MoveTween(GameObject target, Vector3 to, float time) 
			: base(to, time)
		{
			this.Transform = target.transform;
			this.StartPosition = this.Transform.localPosition;
			this.Shift = to - this.Transform.localPosition;
		}

		public override Vector3 Value
		{
			get
			{
				return this.Transform.localPosition;
			}

			set
			{
				this.Transform.localPosition = value;
			}
		}

		protected override Vector3 Update(float t)
		{
			return this.StartPosition + this.Shift * t;
		}
	}
}
