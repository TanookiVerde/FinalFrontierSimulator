using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    public Transform _camera;
    public float cameraVelocity;

    private void Update()
    {
        MoveVertically();
        MoveHorizontally();   
    }
    private void MoveVertically()
    {
        if(Input.GetKey(KeyCode.I))
            _camera.Rotate(-Vector3.right*cameraVelocity*Time.deltaTime);
        if(Input.GetKey(KeyCode.K))
            _camera.Rotate(Vector3.right*cameraVelocity*Time.deltaTime);
    }
    private void MoveHorizontally()
    {
        if(Input.GetKey(KeyCode.J))
            transform.Rotate(-Vector3.up*cameraVelocity*Time.deltaTime);
        if(Input.GetKey(KeyCode.L))
            transform.Rotate(Vector3.up*cameraVelocity*Time.deltaTime);
    }
}
