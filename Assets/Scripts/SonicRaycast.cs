using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicRaycast : MonoBehaviour
{
    public float heightAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log("Height: " + distance);
        }
    }
}
