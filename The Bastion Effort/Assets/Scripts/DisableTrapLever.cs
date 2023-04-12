using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTrapLever : MonoBehaviour
{
    private bool canActivateLever;
    public SpriteRenderer spriteRenderer;
    public GameObject destroyWall;
    public Sprite newSprite;
     private void Update()
     {
         if (canActivateLever)
         {
             if (Input.GetKeyDown(KeyCode.E))
             {
                GetComponent<ShootHeatWaves>().enabled = false;
             }
             Destroy(destroyWall);
             spriteRenderer.sprite = newSprite;
         }  
     }
 
     private void OnTriggerEnter2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Player"))
         {   
            canActivateLever = true;
         }
     }
 
     private void OnTriggerExit2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Player"))
         {
             canActivateLever = false;
         }
     }
}

