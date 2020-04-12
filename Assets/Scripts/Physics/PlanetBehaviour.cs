using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanetBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody _rigidbody;
    public Vector3 angularVelocity;
    public StarBehaviour orbitingStar;

    public float gravityIncrease;

    protected void Start()
    {
        orbitingStar.orbitedPlanets.Add(this);
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.angularVelocity = angularVelocity;
        _rigidbody.velocity = GetOrbitalVelocity();
    }
    private void FixedUpdate()
    {
        foreach(var mass in FindObjectsOfType<GravityMassBehaviour>())
        {
            mass._rigidbody.AddForce(GetGravityForce(mass)*gravityIncrease);
        }
    }
    private Vector3 GetOrbitalVelocity()
    {
        float m = orbitingStar._rigidbody.mass;
        float d = (transform.position - orbitingStar.transform.position).magnitude;
        float G = Global.GRAVITY;
        float orbitalVelocity = Mathf.Sqrt(m*G/d);
        Vector3 dir = transform.position - orbitingStar.transform.position;
        dir = Quaternion.Euler(0, -90, 0) * dir.normalized;
        return orbitalVelocity * dir;
    }
    private Vector3 GetGravityForce(GravityMassBehaviour mass)
    {
        float distance = (mass.transform.position - transform.position).magnitude;
        float m1 = _rigidbody.mass;
        float m2 = mass._rigidbody.mass;
        float G = Global.GRAVITY;
        float force = G*m1*m2/Mathf.Pow(distance, 2);
        Vector3 dir = (mass.transform.position - transform.position).normalized;
        return -dir*force;
    }
}
