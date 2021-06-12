using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundBehaviour : MonoBehaviour
{
	static float YVelocity = -0.004f;

	Renderer _renderer;
	Vector3 offsetVec = new Vector3(0, YVelocity, 0);

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_renderer.isVisible && transform.position.y <= 0.0f) {
			transform.position = transform.position + new Vector3(0, _renderer.bounds.size.y * 1.96f, 0);
		} else {
			transform.position = transform.position + offsetVec;
		}
	}
}
