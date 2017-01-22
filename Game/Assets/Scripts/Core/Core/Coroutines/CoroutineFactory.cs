using System;
using System.Collections;
using UnityEngine;

namespace Core
{
	public static class CoroutineFactory
	{
		private static CoroutineHolderComponent coroutineHolderComponent;

		private static CoroutineHolderComponent CoroutineHolder
		{
			get
			{
				if (coroutineHolderComponent == null)
					coroutineHolderComponent = new GameObject("~Coroutine").AddComponent<CoroutineHolderComponent>();

				return coroutineHolderComponent;
			}
		}

		public static CoroutineTask Run(IEnumerator coroutine)
		{
			var task = new CoroutineTask(coroutine);
			CoroutineHolder.StartCoroutine(task.Execute());
			return task;
		}

		public static CoroutineTask StartTask(MonoBehaviour holder, IEnumerator coroutine, Action onCancel = null)
		{
			var task = new CoroutineTask(coroutine);
			holder.StartCoroutine(task.Execute());
			return task;
		}

		public static void Stop(IEnumerator coroutine)
		{
			CoroutineHolder.StopCoroutine(coroutine);
		}

		public static void StopAll()
		{
			CoroutineHolder.StopAllCoroutines();
		}
	}
}
