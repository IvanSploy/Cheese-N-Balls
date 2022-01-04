using UnityEngine;

public class Ray : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
            Debug.Log("HitByRay");

    }
}
