using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CoroutineTween.Extentions;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	public int Width;
	public int Height;
	public GameObject HexTemplate;
	public float HexGrowSpeed = 1;
	public float HexChangeCooldown = 5;

	private List<GameObject> arenaHexes;
	private Material redColor;
	private Material defaultColor;


	private IEnumerator Start()
	{
		const float HorizontalShift = 1.02f;
		const float VerticalShift = 0.771f;
		var transform = this.transform;
		this.arenaHexes = new List<GameObject>();

		this.redColor = GameObject.Instantiate<Material>(this.HexTemplate.GetComponentInChildren<MeshRenderer>().sharedMaterial);
		this.defaultColor = GameObject.Instantiate<Material>(this.HexTemplate.GetComponentInChildren<MeshRenderer>().sharedMaterial);

		this.redColor.color = Color.red;

		for (int i = 0; i < this.Width; i++)
			for (int j = 0; j < this.Height; j++)
			{
				var hex = this.HexTemplate.Create(new Vector3(i * HorizontalShift + (j * HorizontalShift) / 2, j * VerticalShift), transform);
				if (Vector3.Distance(hex.transform.position, Vector3.zero) > 20)
				{
					hex.transform.localScale = new Vector3(1, GetRandomScale(), 1);
					hex.GetComponentInChildren<MeshRenderer>().material = this.redColor;
				}
				else
				{
					this.arenaHexes.Add(hex);
				}
			}

		while (true)
		{
			var enities = GameObject.FindObjectsOfType<Health>();
			var baseHexes = Enumerable.Range(0, 10).
				Select(o => this.arenaHexes.GetRandom()).
				Where(hex => enities.
					All(enity => Vector3.Distance(enity.transform.position, hex.transform.position) > 3));

			var hexes = baseHexes.SelectMany(o =>
			{
				var index = this.arenaHexes.IndexOf(o);
				return this.arenaHexes.Skip(index).Take(3);
			}).ToArray();

			yield return hexes.Select(o => this.Toggle(o)).Wait();
			yield return new WaitForSeconds(this.HexChangeCooldown);
			yield return hexes.Select(o => this.Toggle(o)).Wait();
		}
	}

	private float GetRandomScale()
	{
		return UnityEngine.Random.value * 3 + 8;
	}

	public IEnumerator Toggle(GameObject hex)
	{
		var hexMaterial = hex.GetComponentInChildren<MeshRenderer>().material;
		if (hexMaterial.color != Color.red)
		{
			hex.Color(Color.red, this.HexGrowSpeed);
			yield return hex.Scale(new Vector3(1, this.GetRandomScale(), 1), this.HexGrowSpeed);
		}
		else
		{
			hex.Color(this.defaultColor.color, this.HexGrowSpeed);
			yield return hex.Scale(new Vector3(1, 1, 1), this.HexGrowSpeed);
		}
	}
}
