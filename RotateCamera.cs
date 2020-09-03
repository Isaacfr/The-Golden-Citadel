using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float spinSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, (spinSpeed * Time.deltaTime), 0);
    }
}
