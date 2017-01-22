using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils
{
	public static Tone[] Tones
	{
		get;
		private set;
	}

	static Utils()
	{
		Tones = Enum.GetValues(typeof(Tone)).Cast<Tone>().ToArray();
	}

	private static System.Random Random = new System.Random();

	public static TValue GetRandom<TValue>(this TValue[] list)
	{
		return list[Random.Next(0, list.Length)];
	}

	public static TValue GetRandom<TValue>(this List<TValue> list)
	{
		return list[Random.Next(0, list.Count)];
	}

	public static TGameObject Create<TGameObject>(this GameObject gameObject, Vector3 position, Transform parent = null)
	{
		return gameObject.Create(position, parent).GetComponent<TGameObject>();
	}

	public static GameObject Create(this GameObject obj, Vector3 position, Transform parent = null)
	{
        GameObject gameObject = (GameObject)GameObject.Instantiate<GameObject>(obj, Vector3.zero, Quaternion.identity,parent);

		gameObject.transform.localPosition = position;

		return gameObject;
	}
}