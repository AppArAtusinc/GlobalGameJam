using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("{0} hit the player", other.name);
        Destroy(other.gameObject);
    }
}
