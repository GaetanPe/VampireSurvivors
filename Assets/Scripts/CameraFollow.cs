using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] Vector3 posOffset;
    private float timeOffset;

    private Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, character.transform.position + posOffset,ref velocity, timeOffset);
    }
}
