using UnityEngine;
using System.Collections;

public class ShellWeapon : MonoBehaviour {

    [SerializeField]
    float lowness;

    [SerializeField]
    private GameObject _shellPrefab;

    [SerializeField]
    private GameObject[] _fireworks;

    [SerializeField]
    private GameObject[] _lowFireworks;

    void Update () {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            var shell = Instantiate(_shellPrefab, transform.position, transform.LookQuaternion(mousePos)) as GameObject;

            Physics2D.IgnoreCollision(shell.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
        }

        if(Input.GetMouseButtonDown(1))
        {
            if(mousePos.y < -lowness)
            {
                Destroy(Instantiate(_lowFireworks[Random.Range(0, _lowFireworks.Length)], mousePos, Quaternion.identity), 20f);
            } else
            {
                Destroy(Instantiate(_fireworks[Random.Range(0, _fireworks.Length)], mousePos, Quaternion.identity), 20f);
            }
        }
	}
}
