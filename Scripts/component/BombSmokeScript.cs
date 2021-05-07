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
        // smoke.GetComponent<ParticleSystem>().emission.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // base.OnTriggerEnter2D(col);
        Debug.Log("OnTriggerEnter2D");
        if (col.CompareTag("Hook"))
        {
            Debug.Log("Hihi");
            col.gameObject.GetComponent<Hook>().GetBombSmoke();
            smoke.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSmoke());
        }
        if (col.tag == "Bomb")
        {
            Debug.Log(col.gameObject + " : " + gameObject.name);
            Destroy(gameObject);smoke.GetComponent<ParticleSystem>().enableEmission = true;
            StartCoroutine(stopSmoke());
        }
    }

    IEnumerator stopSmoke(){
        yield return new WaitForSeconds(.4f);
        smoke.GetComponent<ParticleSystem>().enableEmission = false;
    }



}
