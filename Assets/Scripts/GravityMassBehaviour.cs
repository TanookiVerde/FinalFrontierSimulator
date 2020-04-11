using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMassBehaviour : MonoBehaviour
{
    private const float GRAVITY_CONSTRAINT = 6.674184f;

    public Rigidbody _rigidbody;

    protected virtual void FixedUpdate()
    {
        foreach(var mass in FindObjectsOfType<GravityMassBehaviour>())
        {
            if(mass == this) 
                continue;
            float distance = (mass.transform.position - transform.position).magnitude;
            float m1 = _rigidbody.mass;
            float m2 = mass._rigidbody.mass;
            float G = GRAVITY_CONSTRAINT/Mathf.Pow(10f, 5);
            float force = G*m1*m2/Mathf.Pow(distance, 2);
            Vector3 dir = mass.transform.position - transform.position;
            mass._rigidbody.AddForce(-dir*force);
        }
    }
}
