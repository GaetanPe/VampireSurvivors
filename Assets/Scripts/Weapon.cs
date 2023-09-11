using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected float cooldown;
    protected float lastShot;
    protected bool activated;
    protected Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if(activated && player.isAlive() &&  cooldown + lastShot<=Time.time) TryToShoot();

    }

    public virtual void TryToShoot()
    {

    }

    public virtual void Shoot()
    {

    }

    public void ActivateItem()
    {
        activated = true;
        transform.SetParent(player.transform);
        transform.localPosition = Vector3.zero;
    }
}
