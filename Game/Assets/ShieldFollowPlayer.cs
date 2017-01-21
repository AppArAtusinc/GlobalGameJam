﻿using System.Collections;
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
        TR.position = player.position + player.forward * 1.5f;
        TR.rotation = player.rotation;	
	}
}