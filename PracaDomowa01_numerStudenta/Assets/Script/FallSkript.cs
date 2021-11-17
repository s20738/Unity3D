using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSkript : MonoBehaviour
{
 
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            HealthSript.health -= 3;
        }


    }
    
}
