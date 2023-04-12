using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootHeatWaves : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int direction; //direction where heatwaves go, 0 = up, 1 = down, 2 = right, 3 = left, 4 = 45 degree angle
    public Transform firePoint;
    public float fireForce = 20f;
    public bool canShoot;

    private float xcomponent, ycomponent;
  
    // Update is called once per frame
    void Start()
    {
        xcomponent = Mathf.Cos(45 * Mathf.PI / 180) * fireForce;
        ycomponent = Mathf.Sin(45 * Mathf.PI / 180) * fireForce;
    }

    void FixedUpdate()
    {
        ShootHeat();
    }

    private void ShootHeat()
    {
        if (canShoot)
        {
            GameObject heatWave = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            {
                switch (direction)
                {
                    case 0:
                        heatWave.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
                        break;

                    case 1:
                        heatWave.GetComponent<Rigidbody2D>().AddForce(-firePoint.up * fireForce, ForceMode2D.Impulse);
                        break;

                    case 2:
                        heatWave.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
                        break;
                    case 3:
                        heatWave.GetComponent<Rigidbody2D>().AddForce(-firePoint.right * fireForce, ForceMode2D.Impulse);
                        break;
                    case 4:
                        heatWave.GetComponent<Rigidbody2D>().AddForce(AddForceAtAngle(fireForce, 180), ForceMode2D.Impulse);
                        break;
                }
            }
        }
    }
     public Vector3 AddForceAtAngle(float force, float angle)
    {
        
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;
        
        Vector3 angledForce = new Vector3(ycomponent, 0, xcomponent);

        return angledForce;
    }

     private void OnTriggerEnter2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Player"))
         {   
           canShoot = true;
         }
     }
 
     private void OnTriggerExit2D(Collider2D collider)
     {
         if (collider.gameObject.CompareTag("Player"))
         {
             canShoot = false;
         }
     }
}


