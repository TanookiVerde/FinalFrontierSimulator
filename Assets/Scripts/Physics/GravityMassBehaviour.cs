using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityMassBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
