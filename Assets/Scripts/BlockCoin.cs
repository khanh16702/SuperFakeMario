using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCoin : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.AddCoin();
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        Vector3 restingPosition = transform.localPosition;
        Vector3 animatedPosition = restingPosition + Vector3.up * 2f;

        yield return Move(restingPosition, animatedPosition);
        yield return Move(animatedPosition, restingPosition);

        Destroy(gameObject);
    }

    private IEnumerator Move(Vector3 from, Vector3 to)
    {
        float elapse = 0f;
        float duration = 0.25f;
        while (elapse < duration)
        {
            float t = elapse / duration;
            transform.localPosition = Vector3.Lerp(from, to, t);

            elapse += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = to;
    }
}
