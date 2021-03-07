using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DamageTaking : MonoBehaviour
{
   public int hitPoint = 10;
   public GameObject destructionPrefab;
   public bool gameOverOnDestroyed = false;

   public void TakeDamage(int amount)
   {
      Debug.Log(gameObject.name + " damaged!");

      hitPoint -= amount;
      if (hitPoint <= 0)
      {
         Debug.Log(gameObject.name + " destroyed!");
         Destroy(gameObject);
         if (destructionPrefab != null)
         {
            Instantiate(destructionPrefab, transform.position, transform.rotation);
         }
      }
   }
}
