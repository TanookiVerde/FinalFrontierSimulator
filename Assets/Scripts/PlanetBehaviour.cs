using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : GravityMassBehaviour
{
    public Vector3 angularVelocity;
    public Vector3 initialVelocity;

    protected void Start()
    {
        _rigidbody.angularVelocity = angularVelocity;
        _rigidbody.velocity = initialVelocity;
    }
}
