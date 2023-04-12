using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapons : MonoBehaviour
{
    
private int count;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (count < 1)
            {
                count++;
            }
            else 
            {
                count = 0;
            }
        }

        switch (count)
        {
            case 0:
                GetComponent<Shield>().enabled = true;
                GetComponent<Slingshot>().enabled = false;
            break;

            case 1:
                GetComponent<Shield>().enabled = false;
                GetComponent<Slingshot>().enabled = true;
            break;
        }
    }
}
