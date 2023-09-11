using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int power;
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent action;
    private Vector3 lastPos;

    void Awake()
    {
        lastPos = transform.position;
        Destroy(gameObject, 10);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        Vector3 direction = transform.position - lastPos;
        RaycastHit[] hits = Physics.RaycastAll(lastPos, direction.normalized, direction.magnitude * 1.3f);
        Debug.DrawRay(lastPos, direction, Color.green);
        foreach (RaycastHit h in hits)
        {
            Enemy e = h.collider.gameObject.GetComponent<Enemy>();

            if (e)
            {
                e.Hurt(power);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        lastPos = transform.position;

    }
}
