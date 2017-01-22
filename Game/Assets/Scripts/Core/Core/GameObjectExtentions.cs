using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class GameObjectExtentions
{
	public static TComponent Create<TComponent>(this GameObject gameObject)
		where TComponent : Component
	{
		return GameObject.Instantiate<GameObject>(gameObject).GetComponent<TComponent>();
	}

	public static TComponent Create<TComponent>(this GameObject gameObject, Transform parent)
	where TComponent : Component
	{
		return GameObject.Instantiate<GameObject>(gameObject, parent).GetComponent<TComponent>();
	}

	public static void TryDispose(this IDisposable disposable)
	{
		if (disposable != null)
			disposable.Dispose();
	}
}
