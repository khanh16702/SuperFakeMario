using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockItem : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Animate());
    }
    public IEnumerator Animate()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        CircleCollider2D c = rb.GetComponent<CircleCollider2D>();
        BoxCollider2D box = rb.GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        rb.isKinematic = true;
        c.enabled = false;
        box.enabled = false;
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.25f);
        spriteRenderer.enabled = true;

        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition = transform.localPosition + Vector3.up;
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = endPosition;

        rb.isKinematic = false;
        c.enabled = true;
        box.enabled = true;
    }
}