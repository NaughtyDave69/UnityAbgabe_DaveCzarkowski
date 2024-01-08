using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed; // speed der Projektile 
    

    
    //bewegt das objekt kontinuierlich mit einer gewissen geschwindigkeit 
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    //bei kollision  wird das gameobjekt zerstört 
    private void OnCollisionEnter2D(Collision2D collision)
    {
            
          
        Destroy(gameObject);

    }

  
}
