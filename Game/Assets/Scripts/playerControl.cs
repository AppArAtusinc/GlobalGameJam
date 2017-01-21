using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
	public float playerSpeed, playerRotationSpeed;
	Transform TR;
    Rigidbody RB;

	private void Awake()
	{
        RB = GetComponent<Rigidbody>();
		TR = transform;
	}

	void Update()
	{
        TR.position = new Vector3(TR.position.x, 0, TR.position.z);
		//TR.position += 
        RB.AddForce(    new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))* playerSpeed * Time.deltaTime,ForceMode.Impulse);

        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

        float step = playerRotationSpeed * Time.deltaTime;
        //transform.rotation = 
        RB.MoveRotation (    Quaternion.RotateTowards(TR.rotation, Quaternion.LookRotation((mouseWorldPoint - TR.position).normalized, TR.up), step));

	}
}
