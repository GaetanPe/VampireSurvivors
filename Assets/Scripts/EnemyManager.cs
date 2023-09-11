using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] private List<Enemy> list;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void AddNewEnemy(Enemy e)
    {
        list.Add(e);
    }

    public void RemoveEnemy(Enemy e)
    {
        list.Remove(e);
    }

    public Enemy GetClosestEnemy()
    {
        Enemy res = null;
        if (list.Count <= 0) return res;

        float minDist = 99999999;
        foreach(Enemy e in list)
        {
            float newDist = Vector2.Distance(new Vector2(e.transform.position.x, e.transform.position.z), new Vector2(player.transform.position.x, player.transform.position.z));
            if (newDist < minDist)
            {
                minDist = newDist;
                res = e;
            }
        }
        Debug.Log(res.name);
        return res;
    }
}
