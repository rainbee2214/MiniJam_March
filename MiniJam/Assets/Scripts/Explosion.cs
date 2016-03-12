using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Explosion : MonoBehaviour
{
    public bool explode;
    SpriteRenderer[] srs;

   public Animator anim;
    Vector2 explodeLocation;
    bool exploded = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        srs = GetComponentsInChildren<SpriteRenderer>();
        StartCoroutine(TurnOff());
    }

    void Update()
    {
        if (explode)
        {
            Explode();
            explode = false;
        }

        if (exploded) transform.position = explodeLocation;
    }

    public void Explode()
    {
        if (exploded) return;
        exploded = true;
        srs[1].enabled = false;
        anim.SetTrigger("Explode");
        explodeLocation = transform.position;
        StartCoroutine(StartExplosion());
    }

    public void Reset()
    {
        srs[1].enabled = true;
    }

    public IEnumerator StartExplosion()
    {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }

    public IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
