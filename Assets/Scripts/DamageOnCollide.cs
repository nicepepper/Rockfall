using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 1;
    public int damageToSelf = 5;

    private void HitObject(GameObject theObject)
    {
        var theirDamage = theObject.GetComponentInParent<DamageTaking>();
        if (theirDamage)
        {
            theirDamage.TakeDamage(damage);
        }

        var ourDamage = this.GetComponent<DamageTaking>();
        if (ourDamage)
        {
            ourDamage.TakeDamage(damageToSelf);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        HitObject(collider.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitObject(collision.gameObject);
    }
}
