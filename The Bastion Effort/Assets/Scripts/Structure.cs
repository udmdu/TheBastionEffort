using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Structure : MonoBehaviour
{
    public SpriteRenderer wireEnd;
    public GameObject startNode, endNode;
    public BoxCollider2D boxCol2d;
    Vector3 startPoint;
    Vector3 GOpos;
    Vector3 GOscale;
    
    public float destroyTime = 5f;
    public float timeUntilDestroyed;
    
    private bool destroyStructure = false;
 
    // Start is called before the first frame update
    void Start()
    {
        
        GOpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GOscale = new Vector3(transform.localScale.x/5, 0f, 0f);
        //startPoint = GO.transform.position - GO.transform.localScale;
        startPoint = GOpos - GOscale;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;
        timeUntilDestroyed = Time.time + destroyTime;
        destroyStructure = true;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.Equals(endNode))
            {
                UpdateStructure(collider.transform.position);
                return;
            }
        }
        UpdateStructure(newPosition);
    }


    private void UpdateStructure(Vector3 newPosition)
    {
        transform.position = newPosition;

        Vector3 direction = newPosition - startPoint;
        transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPosition);
        wireEnd.size = new Vector2(dist, wireEnd.size.y);

        //adjusts colliders
        boxCol2d.offset = new Vector2(-dist/2, 0f);
        boxCol2d.size = wireEnd.size;
    }

    private void FixedUpdate()
    {
        DestroyStructure();
    }

    private void DestroyStructure()
    {
        if (Time.time > timeUntilDestroyed && destroyStructure)
            {
                UpdateStructure(GOpos);
                destroyStructure = false;
            }
    }
}