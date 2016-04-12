using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    [SerializeField]
    private float _delay;

	void Start () {
        Invoke("Destroy", _delay);
	}

    void Destroy()
    {
        Destroy(gameObject);
    }
}
