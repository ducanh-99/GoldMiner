using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectManagerment;
using static ValueObject;

public class ExplodeBarrelScript : ObjectScripts { 


    void OnTriggerEnter2D(Collider2D col) {
       // base.OnTriggerEnter2D(col);
        if (col.CompareTag("Hook")) {
            col.gameObject.GetComponent<Hook>().GetExplode();

        }
    }



}
