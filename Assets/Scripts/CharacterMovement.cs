using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxDistanceToCorrection;
    public float moveSpeed;
    public float jumpForce;

    public Rigidbody _rigidbody;

    public void Update()
    {
        Correct();
        Move();
        Jump();
    }
    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(transform.up * jumpForce);
        }
    }
    private void Move()
    {
        var v = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.AddForce(transform.right * v.x * moveSpeed);
        _rigidbody.AddForce(transform.forward * v.y * moveSpeed);
    }
    private void Correct()
    {
        var planet = GetPlanetForCorrection();
        if(planet != null)
        {
            var v = (planet.transform.position - transform.position).normalized;
            transform.up = -v;
        }
    }
    private PlanetBehaviour GetPlanetForCorrection()
    {
        foreach(var planet in FindObjectsOfType<PlanetBehaviour>())
        {
            //print("DIST.: " + (planet.transform.position - transform.position).magnitude);
            if((planet.transform.position - transform.position).magnitude <= maxDistanceToCorrection)
                return planet;
        }
        return null;
    }
}
