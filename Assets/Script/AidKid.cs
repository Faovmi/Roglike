using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKid : MonoBehaviour
{
    public float healAmount = 50;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<Playerhealth>();
        if(playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
