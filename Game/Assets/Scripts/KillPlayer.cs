using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Heh");
        other.GetComponent<Animator>().SetTrigger("Die");
    }

}
