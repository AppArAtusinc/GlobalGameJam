using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    private void OnCollisionStay(Collision collision)
    {
        print("APtechka");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().Damage(-2);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        print("APtechka");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().Damage(-2);
        }
    }

}
