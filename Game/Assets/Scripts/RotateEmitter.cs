using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEmitter : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem.ShapeModule shape = GetComponent<ParticleSystem>().shape;
        transform.rotation = Quaternion.Euler(90, shape.arc / 2 - 90, 0);
    } 
}
