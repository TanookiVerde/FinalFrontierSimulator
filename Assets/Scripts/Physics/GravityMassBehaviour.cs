using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMassBehaviour : MonoBehaviour
{
    public float lineSize;

    public Rigidbody _rigidbody;

    private Vector3 lastVelocity;

    private void Update()
    {
        foreach(var mass in FindObjectsOfType<GravityMassBehaviour>())
        {
            if(mass == this)
                continue;
            Debug.DrawLine(transform.position, mass.transform.position, Color.green);
        }
    }
    protected virtual void FixedUpdate()
    {
        foreach(var mass in FindObjectsOfType<GravityMassBehaviour>())
        {
            if(mass == this) 
                continue;
            mass._rigidbody.AddForce(GetGravityForce(mass));
        }
        if(lastVelocity != _rigidbody.velocity)
            lastVelocity = _rigidbody.velocity;
    }
    private Vector3 GetGravityForce(GravityMassBehaviour mass)
    {
        float distance = (mass.transform.position - transform.position).magnitude;
        float m1 = _rigidbody.mass;
        float m2 = mass._rigidbody.mass;
        float G = Global.GRAVITY;
        float force = G*m1*m2/Mathf.Pow(distance, 2);
        Vector3 dir = (mass.transform.position - transform.position).normalized;
        print(name + "/" + mass.name + "=>" + force +" where M=" + m2 +"; m="+m1+"; d="+distance);
        return -dir*force;
    }
}
