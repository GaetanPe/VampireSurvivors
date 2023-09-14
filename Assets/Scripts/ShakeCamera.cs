using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1;

    public void shake()
    {
        start = true;
    }

    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position += Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
