using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoardHP : MonoBehaviour
{

    Camera mainCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        FindCamera();
    }

    void FindCamera()
    {
        mainCamera = Camera.main;
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}
