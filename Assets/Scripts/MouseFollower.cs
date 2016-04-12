using UnityEngine;
using System.Collections;

public class MouseFollower : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
	}
}
