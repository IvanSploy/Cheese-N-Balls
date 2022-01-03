using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidFromRotate : MonoBehaviour
{
    private Quaternion initialRotate;

    private void Awake()
    {
        initialRotate = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = initialRotate;
    }
}
