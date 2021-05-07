using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectManagerment;
using static ValueObject;

public class BombSmokeScript : ObjectScripts
{
    public GameObject explosion;
    public Transform smoke;
    void OnTriggerEnter2D(Collider2D col)
    {
        // base.OnTriggerEnter2D(col);
        if (col.CompareTag("Hook") && col.gameObject.GetComponent<Hook>().move_down)
        {
            smoke.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSmoke());
            col.gameObject.GetComponent<Hook>().GetBombSmoke();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }


    }

    IEnumerator stopSmoke(){
        yield return new WaitForSeconds(.4f);
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
    }



}
