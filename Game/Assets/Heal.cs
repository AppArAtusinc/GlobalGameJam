using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

    ParticleSystem PS;

    float healthCapacity;
    const float MAX_HEALTH_CAPACITY = 25;
    private void Awake()
    {
        PS = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        healthCapacity = 25;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PS.emission.SetBursts(new ParticleSystem.Burst[] { new ParticleSystem.Burst(0, (short)(200 * healthCapacity/MAX_HEALTH_CAPACITY), (short)(300 * healthCapacity / MAX_HEALTH_CAPACITY)) });
            other.gameObject.GetComponent<Health>().Damage(-5 * Time.deltaTime);
            UiManager.instance.score += 10;
            healthCapacity += -5 * Time.deltaTime;
            if (healthCapacity <= 0) gameObject.SetActive(false);
        }
    }

}
