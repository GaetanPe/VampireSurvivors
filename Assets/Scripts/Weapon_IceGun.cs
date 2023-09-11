using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_IceGun : Weapon
{
    [SerializeField] private float range;
    private Enemy target;
    public override void TryToShoot()
    {
        target = EnemyManager.Instance.GetClosestEnemy();
        if (!target) return;
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(target.transform.position.x, target.transform.position.z)) > range)return;
        Shoot();
    }

    public override void Shoot()
    {
        lastShot = Time.time;
        GameObject newAttack = Instantiate(prefab, transform.position, Quaternion.identity);
        newAttack.transform.LookAt(new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
