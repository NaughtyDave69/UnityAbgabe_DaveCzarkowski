using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target; // Das Target

   NavMeshAgent agent; // komponente für das PathFinding

    private SpriteRenderer spriteRenderer; // der spriterenderer 
    private PolygonCollider2D collider;   //der collider

    public ParticleSystem particle;  // die patikel 


    private void Start()
    {      //  Initialisierung der komponenten 
         spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<PolygonCollider2D>();
         agent = GetComponent<NavMeshAgent>();

        // Deaktiviert Automatische  Rotation und ausrichtung des Agents
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // falls kein Zielobjekt festgelegt is was in dem fall auch nicht über den inspektor möglich ist sucht er sich den Player
      if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    // setzt das ziel für den navMesh  
    private void Update()
    {
        agent.SetDestination(target.position);

        

    }
    /* es wird überprüft ob ein objekt mit dem Tag Bullet kollidiert 
     ist das der fall spielen die partikel ab der sprite wird unsichtbar gemacht und die Coroutine Wait wird aktiviert*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            particle.Play();
            SpriteVisibility();
            StartCoroutine(Wait(1));

            Debug.Log("Hit");
        }
    }

    //deaktiviert den collider und den sprite
    private void SpriteVisibility()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
    }
    // wartet eine zeit ab bis das objekt zerstört wird 
    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
