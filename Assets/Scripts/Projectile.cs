using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private GameObject _deathAnimation;

    [SerializeField]
    private float _speed;

    [SerializeField]
    GameObject _particles;
	
	void Update () {
        transform.Translate(0, _speed * Time.deltaTime, 0, Space.Self);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        _particles.transform.SetParent(null, true);
        Destroy(gameObject);
        Instantiate(_deathAnimation, transform.position, transform.rotation);
    }
}
