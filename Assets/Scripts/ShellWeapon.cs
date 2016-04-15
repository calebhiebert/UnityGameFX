using UnityEngine;
using System.Collections;

public class ShellWeapon : MonoBehaviour {

    [SerializeField]
    private GameObject _shellPrefab;

    [SerializeField]
    private GameObject _fireworks;

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            var shell = Instantiate(_shellPrefab, transform.position, transform.LookQuaternion(Camera.main.ScreenToWorldPoint(Input.mousePosition))) as GameObject;

            Physics2D.IgnoreCollision(shell.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
        }

        if(Input.GetMouseButtonDown(1))
        {
            Destroy(Instantiate(_fireworks, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity), 5f);
        }
	}
}
