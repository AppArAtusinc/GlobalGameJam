using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float Speed = 4;
	public float MaximumDistance = 4;

	private Camera Camera;
	private PlayerHealth Player;

	void Start()
	{
		this.Player = GameObject.FindObjectOfType<PlayerHealth>();
		this.Camera = this.GetComponent<Camera>();
	}

	private void Update()
	{
		if (!this.Player)
		{
			this.Player = GameObject.FindObjectOfType<PlayerHealth>();
			return;
		}

		var cameraPosition = this.Player.transform.position;

		cameraPosition.y = 10;
		this.Camera.transform.position = cameraPosition;
	}
}
