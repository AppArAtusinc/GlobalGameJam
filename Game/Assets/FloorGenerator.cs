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
		const float HorizontalShift = 1;
		const float VerticalShift = 1;
		var transform = this.transform;
		for (int i = 0; i < this.Width; i++)
			for (int j = 0; j < this.Height; j++)
				this.HexTemplate.Create(new Vector3(i * HorizontalShift + i * 2, 0, j * VerticalShift), transform);
	}
}
