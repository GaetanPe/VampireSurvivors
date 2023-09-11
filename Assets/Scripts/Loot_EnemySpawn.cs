using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot_EnemySpawn : Loot
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnSpot;
    [SerializeField] private int number;
    protected override void Trigger()
    {
        for(int i =0;i<number; i++)
        {
            Instantiate(prefab, spawnSpot.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spawnSpot.position, 0.2f);
        Gizmos.DrawLine(spawnSpot.position, transform.position);
    }
}
