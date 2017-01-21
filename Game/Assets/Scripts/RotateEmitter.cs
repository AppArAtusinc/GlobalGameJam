using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEmitter : MonoBehaviour {

	private void Awake()
	{
		transform.rotation = Quaternion.Euler(new Vector3(90, -GetComponent<ParticleSystem>().shape.arc / 2, 0));
	}
}
