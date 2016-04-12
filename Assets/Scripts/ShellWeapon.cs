using UnityEngine;
using System.Collections;

public class ShellWeapon : MonoBehaviour {

    [SerializeField]
    private GameObject _shellPrefab;
	
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            var shell = Instantiate(_shellPrefab, transform.position, transform.LookQuaternion(Camera.main.ScreenToWorldPoint(Input.mousePosition))) as GameObject;

            Physics2D.IgnoreCollision(shell.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
        }
	}
}
