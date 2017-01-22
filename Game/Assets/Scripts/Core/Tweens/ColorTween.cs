using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tweens
{
	public class ColorTween : DelayAndCurveTween<ScaleTween, Color>
	{
		private Renderer Renderer;
		private Color Shift;
		private Color StartColor;

		public ColorTween(Renderer target, Color to, float time) 
			: base(to, time)
		{
			this.Renderer = target;
			this.StartColor = this.Renderer.material.color;
			this.Shift = to - this.StartColor;
		}

		public override Color Value
		{
			get
			{
				return this.Renderer.material.color;
			}
			set
			{
				this.Renderer.material.color = value;
			}
		}

		protected override Color Update(float t)
		{
			return this.StartColor + this.Shift * t;
		}
	}
}
