using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using UniRx;
using UnityEngine;

public static class CoroutineExtentions
{
	public static IEnumerator Wait(this IEnumerable<IEnumerator> coroutines)
	{
		var tasks = coroutines.Select(o => o.Run()).ToArray();

		foreach (var task in tasks)
			if (task.keepWaiting)
				yield return task;
	}

	public static IEnumerator Wait(this IEnumerable<CoroutineTask> tasks)
	{
		foreach (var task in tasks.ToArray())
			if (task.keepWaiting)
				yield return task;
	}

	public static CoroutineTask Run(this IEnumerator coroutine)
	{
		return CoroutineFactory.Run(coroutine);
	}

	public static CoroutineTask StartTask(this MonoBehaviour holder, IEnumerator coroutine)
	{
		return CoroutineFactory.StartTask(holder, coroutine);
	}

	public static CoroutineTask Run(this CoroutineTask task)
	{
		CoroutineFactory.Run(task.Execute());
		return task;
	}

	public static IEnumerator Lock(this object lockObject)
	{
		return Observable.FromMicroCoroutine(() => LockCoroutine(lockObject)).ToYieldInstruction();
	}

	public static IEnumerator BreakIfLock(this object lockObject)
	{
		if (Locks.Contains(lockObject))
			yield break;
	}

	public static void UnLock(this object lockObject)
	{
		Locks.Remove(lockObject);
	}

	static HashSet<object> Locks = new HashSet<object>();

	private static IEnumerator LockCoroutine(object lockObject)
	{
		while (Locks.Contains(lockObject))
			yield return null;

		Locks.Add(lockObject);
	}
}
