using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [HideInInspector]
    private Rigidbody _rigidbody;
    [SerializeField]
    private SpaceshipDirection direction;
    [SerializeField]
    private Velocimeter velocimeter;

    public float axisForce;
    public float verticalForce;
    public float rotationSensibility;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        velocimeter.SetVelocity(_rigidbody.velocity);
        RotateSpaceship();
        MoveInAxis();
        VerticalMove();
    }
    private void VerticalMove()
    {
        bool up = Input.GetKey(KeyCode.Space);
        bool down = Input.GetKey(KeyCode.LeftShift);
        if(up)
            _rigidbody.AddForce(transform.up * verticalForce);
        if(down)
            _rigidbody.AddForce(transform.up * -verticalForce);
        direction.SetVerticalState(up, down);
    }
    private void MoveInAxis()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.AddForce(transform.forward * input.y * axisForce * Time.deltaTime);
        _rigidbody.AddForce(transform.right * input.x * axisForce * Time.deltaTime);
        direction.SetAxisState(input);
    }
    private void RotateSpaceship()
    {
        var mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        mousePosition = mousePosition - new Vector3(0.5f, 0.5f, 0);
        transform.Rotate(new Vector3(-mousePosition.y, mousePosition.x, 0) * rotationSensibility * Time.deltaTime);
    }
}
