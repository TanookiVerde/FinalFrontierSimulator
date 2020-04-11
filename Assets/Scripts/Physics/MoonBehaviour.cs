using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBehaviour : GravityMassBehaviour
{
    public Vector3 angularVelocity;
    public PlanetBehaviour orbitingPlanet;

    protected void Start()
    {
        _rigidbody.angularVelocity = angularVelocity;
        _rigidbody.velocity = GetOrbitalVelocity();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private Vector3 GetOrbitalVelocity()
    {
        float m = orbitingPlanet._rigidbody.mass;
        float d = (transform.position - orbitingPlanet.transform.position).magnitude;
        float G = Global.GRAVITY;
        float orbitalVelocity = Mathf.Sqrt(m*G/d);
        Vector3 dir = transform.position - orbitingPlanet.transform.position;
        dir = Quaternion.Euler(0, -90, 0) * dir.normalized;
        print("Orbital Velocity: " + orbitalVelocity + " with d = " + d);
        return orbitalVelocity * dir;
    }
}
