using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemySpawner : MonoBehaviour
{
    public GameObject EnemyPre; //das Enemy Prefab
    public Color gizmoColor = Color.magenta;  // das gizmo
    public float spawnRadius =1f;  // der spawn radius 
    public float spawnInterval = 5f; // der interval in dem die enemys gespant werden 

    // setzt eine Farbe für das Gizmo und Zeichnet eine kugel wo die enemys spawnen 
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, spawnRadius);
    }
    // Instanziiert die Enemys 
    void SpawnEnemy()
    {

        Instantiate(EnemyPre, transform.position, Quaternion.identity);
    }

    //spawnt es regemäßig und in intervallen 
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }
}
