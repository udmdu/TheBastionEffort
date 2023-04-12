using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatWaveProperties : MonoBehaviour
{       
    public GameObject bulletPrefab;
    public GameObject playerObject;
    public GameObject healthBar;
    PlayerController refScript;
    HealthBar healthBarScript;
    public float horizontalMove;
    void Start()
    {
        playerObject = GameObject.Find("Player");
         refScript = playerObject.GetComponent<PlayerController>();
        healthBar = GameObject.Find("HealthBar");
        healthBarScript = healthBar.GetComponent<HealthBar>();
    }
    void Update()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Shield") || collision.gameObject.layer == 8 && !collision.gameObject.CompareTag("Grate"))
        {
            Destroy(gameObject);
        }
        
        if(collision.gameObject.CompareTag("Player"))
        {
            refScript.playerHealth -= refScript.damage;
            healthBarScript.SetHealth(refScript.playerHealth);
        }
    }
}
