﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public void OnDeath()
    {
        gameObject.SetActive(false);
    }

}