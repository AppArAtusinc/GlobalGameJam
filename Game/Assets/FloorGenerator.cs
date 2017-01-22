using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	public int Width;
	public int Height;
	public GameObject HexTemplate;
	public float HexGrowSpeed;

	private List<GameObject> arenaHexes;
	private Material redColor;
	private Material defaultColor;

	private void Start()
	{
		const float HorizontalShift = 1.02f;
		const float VerticalShift = 0.771f;
		var transform = this.transform;
		this.arenaHexes = new List<GameObject>();

		this.redColor = GameObject.Instantiate<Material>(this.HexTemplate.GetComponentInChildren<MeshRenderer>().sharedMaterial);
		this.defaultColor = GameObject.Instantiate<Material>(this.HexTemplate.GetComponentInChildren<MeshRenderer>().sharedMaterial);

		redColor.color = Color.red;

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
	}

	private float GetRandomScale()
	{
		return UnityEngine.Random.value * 3 + 8;
	}

	public IEnumerator Toggle(GameObject hex)
	{
		var hexMaterial = hex.GetComponent<MeshRenderer>().material;
		if (hexMaterial == this.redColor)
	}
}
