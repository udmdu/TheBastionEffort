using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0.6f, -10f);
    private float smoothTime = 0f;
    private Vector3 velocity = Vector3.zero;

    private bool facingRight, facingUp;

    [SerializeField]
    private Transform target;

    
    // Update is called once per frame
    void FixedUpdate()
    {
        

       /* Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        if (difference.x >= 0 && !facingRight)
        {
            offset[0] = 0.5f;
            facingRight = true;
        }
        if (difference.x < 0 && facingRight)
        {
            offset[0] = -0.5f;
            facingRight = false;
        }*/
    
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
