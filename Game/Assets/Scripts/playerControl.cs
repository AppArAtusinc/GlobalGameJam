using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
	public float playerSpeed, playerRotationSpeed;
	public float FootstepCooldown = 0.3f;
	public AudioClip[] Steps;

	private AudioSource AudioSource;
	private Transform TR;
	private Rigidbody RB;
	private Vector3 power;

	private void Awake()
	{
		this.AudioSource = this.GetComponent<AudioSource>();
		RB = GetComponent<Rigidbody>();
		TR = transform;
		this.StartCoroutine(this.FootstepCoroutine());
	}

	private IEnumerator FootstepCoroutine()
	{
		var wait = new WaitForSeconds(this.FootstepCooldown);
		while (true)
		{
			yield return wait;
			if (this.power.magnitude > 0)
				this.AudioSource.PlayOneShot(this.Steps.GetRandom());
		}
	}

	void Update()
	{
		TR.position = new Vector3(TR.position.x, 0, TR.position.z);

		this.power = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerSpeed * Time.deltaTime;
		RB.AddForce(power, ForceMode.Impulse);

		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));

		float step = playerRotationSpeed * Time.deltaTime;
		//transform.rotation = 
		RB.MoveRotation(Quaternion.RotateTowards(TR.rotation, Quaternion.LookRotation((mouseWorldPoint - TR.position).normalized, TR.up), step));

	}
}
