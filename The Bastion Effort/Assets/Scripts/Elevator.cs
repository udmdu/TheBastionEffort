using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public GameObject box1, box2 ,box3;
    public Transform stop1, stop2, stop3;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartElevator();
    }

    void StartElevator()
    {
        if (box1 == null && box2 != null && box3 != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, stop1.position, speed * Time.deltaTime);
        }
        if (box2 == null && box3!= null)
        {
            transform.position = Vector2.MoveTowards(transform.position, stop2.position, speed * Time.deltaTime);
        }
        if (box3 == null)
        {
            transform.position = Vector2.MoveTowards(transform.position, stop3.position, speed * Time.deltaTime);
        }
       
        
    }
}
