using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFollowPlayer : MonoBehaviour {

    Transform player,TR;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        TR = transform;
    }


    void Update ()
    {
		this.gameObject.SetActive(this.player.gameObject.active);
		TR.position = player.position + player.forward * 0.7f;
        TR.rotation = player.rotation;	
	}
}
