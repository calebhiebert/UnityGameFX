using UnityEngine;
using System.Collections;

public class FireworkChain : MonoBehaviour {

    public float t;
    public int num;
    public float dist;
    public GameObject prefab;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = -num; i < num; i++)
        {
            var newFirework = Instantiate(prefab);

            newFirework.transform.SetParent(transform, false);

            newFirework.transform.position = new Vector3(dist * i, transform.position.y, 5);

            var sys = newFirework.GetComponent<ParticleSystem>();

            yield return new WaitForSeconds(t);
        }
    }
}
