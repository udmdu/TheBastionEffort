using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject spawnTarget;
    public Transform attachTo;

    public float shieldGaugeCap;
    public float shieldGauge;

    public float shieldGaugeDrainRate;

    public float shieldGaugeRechargeRate;

    public float rechargeWaitTime;
    public float playerReducedSpeed;
    public HealthBar healthBar;

    [SerializeField]
    private bool shieldUp = false;

    private bool canCharge = true;
    private float playerOriginalSpeed;
    private GameObject playerObject;
    private PlayerController refScript;
    private float nextRechargeWaitTime;

    public void Start()
    {
        playerObject = GameObject.Find("Player");
        refScript = playerObject.GetComponent<PlayerController>();
        playerOriginalSpeed = refScript.speed;

    }

    void FixedUpdate()
    {
        healthBar.setShield(shieldGauge);
        ControlShield();
        RegenShield();
    }

    public void ControlShield()
    {
        //Deploys Shield
       if (Input.GetButton("Fire1") && shieldGauge > 0)
            {
                if (!shieldUp)
                    {
                        Instantiate(spawnTarget, attachTo);
                    }
                shieldGauge -= shieldGaugeDrainRate;
                refScript.speed = playerOriginalSpeed*playerReducedSpeed;
                shieldUp = true;
                canCharge = true;
            }

        //Removes Shield if mouse button is let go
        if ((!Input.GetButton("Fire1") && shieldUp) || shieldGauge == 0)
            {
                Destroy(GameObject.Find(spawnTarget.name+"(Clone)"));
                refScript.speed = playerOriginalSpeed;
                shieldUp = false;           
            }

        if (!shieldUp && canCharge)
        {
            nextRechargeWaitTime = Time.time + rechargeWaitTime;
            canCharge = false;
        }
    }
    public void RegenShield()
    {
        if (Time.time > nextRechargeWaitTime)
        {
             if (!Input.GetButton("Fire1") && !shieldUp && shieldGauge < shieldGaugeCap)
                {
                    shieldGauge += shieldGaugeRechargeRate;
                }
        }
        
    }
}
