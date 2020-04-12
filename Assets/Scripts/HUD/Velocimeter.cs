using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Velocimeter : MonoBehaviour
{
    [SerializeField]
    private TMP_Text velocimeter;

    public void SetVelocity(Vector3 velocity)
    {
        velocimeter.text = "X: " + velocity.x + "U/s\nY: " + velocity.y + "U/s\nZ: " + velocity.z + "U/s"; 
    }
    
}
