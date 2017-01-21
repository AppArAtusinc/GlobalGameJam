using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
	public int Width;
	public int Height;
	public GameObject HexTemplate;

	private void Start()
	{
		const float HorizontalShift = 1.02f;
		const float VerticalShift = 0.771f;
		var transform = this.transform;

		for (int i = 0; i < this.Width; i++)
			for (int j = 0; j < this.Height; j++)
			{
				var hex = this.HexTemplate.Create(new Vector3(i * HorizontalShift + (j * HorizontalShift) / 2, j * VerticalShift), transform);
				if (Vector3.Distance(hex.transform.position, Vector3.zero) > 20)
				{
					hex.transform.localScale = new Vector3(1, Random.value * 3 + 8, 1);
					hex.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
				}
			}
	}

}
