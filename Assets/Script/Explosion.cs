using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 50;
    public float maxSize = 5;
    public float speed = 1;
    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed; 

        if (transform.localScale.x > maxSize)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var Playerhealth = other.GetComponent<Playerhealth>();
        if (Playerhealth != null)
        {
            Playerhealth.DealDamage(damage);
        }

        var enemyhealth = other.GetComponent<EnemyHealth>();
        if (enemyhealth != null)
        {
            enemyhealth.DealDamage(damage);
        }
    }
}

