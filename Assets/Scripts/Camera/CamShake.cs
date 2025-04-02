using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    [SerializeField]
    private float duration = 1f;
    public AnimationCurve curve;
    public bool start = false;

    Vector3 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }
    public void StartShake()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.position = startPos + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPos;
    }
}
