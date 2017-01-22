using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniRx;
using UnityEngine;

namespace Tweens
{
	public abstract class Tween : CustomYieldInstruction
	{

		private bool inProgress;

		public override bool keepWaiting
		{
			get
			{
				return this.inProgress;
			}
		}

		public IEnumerator Start()
		{
			this.inProgress = true;
			yield return Observable.FromMicroCoroutine(this.Execute).ToYieldInstruction();
			this.inProgress = false;
		}

		protected abstract IEnumerator Execute();
	}
}
