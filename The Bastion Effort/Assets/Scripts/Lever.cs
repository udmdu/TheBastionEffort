using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject playerGO;
    public GameObject leverGO;

    public GameObject bridgeGO;
    public HingeJoint2D bridgeHinge;

    public Sprite newSprite;

    public SpriteRenderer spriteRenderer;
    private JointMotor2D motorRef;

    JointMotor2D motorRef1 = new JointMotor2D();
    public bool bridgeDown;



     [SerializeField]
     private bool canActivateLever;

     private void Start()
     {
        var hinge = bridgeGO.GetComponent<HingeJoint2D>();
        motorRef = hinge.motor;
     }
 
     private void Update()
     {
         if (canActivateLever)
         {
             if (Input.GetKeyDown(KeyCode.E))
             {
                 canActivateLever = false;
                 if (bridgeDown)
                 {
                    motorRef1.motorSpeed = 100;
                    motorRef = motorRef1;
                 }
                 if (!bridgeDown)
                 {
                    motorRef1.motorSpeed = -100;
                    motorRef = motorRef1;
                    Debug.Log("test");
                 }
                spriteRenderer.sprite = newSprite;
                bridgeHinge.useMotor = true;
             }
         }  
     }
 
     private void OnTriggerEnter2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Player"))
         {   
            bridgeHinge.useMotor = false;
            canActivateLever = true;
         }
     }
 
     private void OnTriggerExit2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Player"))
         {
             canActivateLever = false;
             Debug.Log("test2");
         }
     }
}
