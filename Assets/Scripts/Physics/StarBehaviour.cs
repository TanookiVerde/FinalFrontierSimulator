using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StarBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody _rigidbody;

    public List<PlanetBehaviour> orbitedPlanets;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        foreach(var planet in orbitedPlanets)
        {
            planet._rigidbody.AddForce(GetGravityForce(planet));
        }
        foreach(var mass in FindObjectsOfType<GravityMassBehaviour>())
        {
            mass._rigidbody.AddForce(GetGravityForce(mass));
        }
    }
    private Vector3 GetGravityForce(PlanetBehaviour mass)
    {
        float distance = (mass.transform.position - transform.position).magnitude;
        float m1 = _rigidbody.mass;
        float m2 = mass._rigidbody.mass;
        float G = Global.GRAVITY;
        float force = G*m1*m2/Mathf.Pow(distance, 2);
        Vector3 dir = (mass.transform.position - transform.position).normalized;
        return -dir*force;
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
