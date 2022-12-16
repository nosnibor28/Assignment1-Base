using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class RobinsonJ : MonoBehaviour
{
    [SerializeField] float redRate = 0.5f;
    [SerializeField] float greenRate = 0.7f;
    [SerializeField] float blueRate = 0.1f;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.deltaTime;
        Color c = sr.color;

        c.r = Loop01(c.r + redRate * t);
        c.g = Loop01(c.g + greenRate * t);
        c.b = Loop01(c.b + blueRate * t);

        sr.color = c;
    }

    float Loop01(float x)
    {
        if (x > 1f)
        {
            return x - 1f;
        }
        else if (x < 0f)
        {
            return x + 1f;
        }
        else
        {
            return x;
        }
    }
}
