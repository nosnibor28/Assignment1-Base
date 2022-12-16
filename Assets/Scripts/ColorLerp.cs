using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorLerp : MonoBehaviour
{
    [SerializeField] [Min(0.1f)] float transitionTime = 0.5f;
    [SerializeField] Color[] cycleColors;

    SpriteRenderer mySprite;

    void Start()
    {
        if (cycleColors == null || cycleColors.Length < 1) return;

        mySprite = GetComponent<SpriteRenderer>();

        if (cycleColors.Length == 1)
        {
            mySprite.color = cycleColors[0];
            return;
        }

        StartCoroutine(DoColorLerp());
    }

    IEnumerator DoColorLerp()
    {
        float t = 0f;
        int i = 0, j = 1;
        Vector3 cv1, cv2;

        while (true)
        {
            cv1 = ColorToVector(cycleColors[i]);
            cv2 = ColorToVector(cycleColors[j]);

            while (t < transitionTime)
            {
                t += Time.deltaTime;
                mySprite.color = VectorToColor(Vector3.Lerp(cv1, cv2, t / transitionTime));
                yield return 0;
            }
            t = 0f;

            i++;
            if (i >= cycleColors.Length)
            {
                i = 0;
            }
            j = i + 1;
            if (j >= cycleColors.Length)
            {
                j = 0;
            }
        }
    }

    Vector3 ColorToVector(Color c)
    {
        return new Vector3(c.r, c.g, c.b);
    }

    Color VectorToColor(Vector3 v)
    {
        return new Color(v.x, v.y, v.z, 1.0f);
    }
}
