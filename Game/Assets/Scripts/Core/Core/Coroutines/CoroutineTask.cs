using System;
using System.Collections;
using UnityEngine;

namespace Core
{
	public class CoroutineTask : CustomYieldInstruction
	{
		public static readonly CoroutineTask Empty = new CoroutineTask(null);
		private IEnumerator coroutine;

		public CoroutineTask(IEnumerator coroutine)
		{
			this.coroutine = coroutine;
		}

		public bool InProgress;

		public override bool keepWaiting
		{
			get
			{
				return this.InProgress;
			}
		}

		public IEnumerator Execute()
		{
			this.InProgress = true;
			yield return this.coroutine;
			this.InProgress = false;
		}

	}
}