using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectManagerment;
using static ValueObject;

public class BombSmokeScript : ObjectScripts
{
    public Transform smoke;
   
    void Start(){
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hook"))
        {
            col.gameObject.GetComponent<Hook>().GetBombSmoke();
            smoke.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSmoke());
        }
    }

    IEnumerator stopSmoke(){
        yield return new WaitForSeconds(.4f);
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
    }



}
