using System;
using UnityEngine;

public static class Utils
{
	private static System.Random Random = new System.Random();

	public static TValue GetRandom<TValue>(this TValue[] list)
	{
		return list[Random.Next(0, list.Length)];
	}

	public static TGameObject Create<TGameObject>(this GameObject gameObject, Vector3 position, Transform parent)
	{
		return gameObject.Create(position, parent).GetComponent<TGameObject>();
	}

	public static GameObject Create(this GameObject @object, Vector3 position, Transform parent)
	{
		var gameObject = GameObject.Instantiate<GameObject>(@object, Vector3.zero, Quaternion.identity, parent);
		gameObject.transform.localPosition = position;

		return gameObject;
	}
}