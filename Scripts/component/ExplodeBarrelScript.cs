using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectManagerment;
using static ValueObject;

public class ExplodeBarrelScript : ObjectScripts
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D col)
    {
        // base.OnTriggerEnter2D(col);
        if (col.CompareTag("Hook"))
        {
            col.gameObject.GetComponent<Hook>().GetExplodeBarrel();
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

    }



}
