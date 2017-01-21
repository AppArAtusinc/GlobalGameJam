using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	Transform TR, playerTR;

	public float speed = 10;

	private void Awake()
	{
		TR = transform;
		playerTR = GameObject.FindGameObjectWithTag("Player").transform;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float step = speed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(TR.rotation, Quaternion.LookRotation((playerTR.position-TR.position).normalized,TR.up), step);
	}
}
