using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
	public float playerSpeed, playerRotationSpeed;
	Transform TR;

	private void Awake()
	{
		TR = transform;
	}

	void Update()
	{
		TR.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* playerSpeed * Time.deltaTime;

        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        float step = playerRotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(TR.rotation, Quaternion.LookRotation((mouseWorldPoint - TR.position).normalized, TR.up), step);

	}
}
