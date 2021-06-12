using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCursor : MonoBehaviour
{
	Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
		var translation = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f) * 0.030f;
		transform.position = transform.position + translation;

 		Vector3 lowerCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0));
 		Vector3 upperCameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 0));

		if(transform.position.x < lowerCameraBounds.x || transform.position.y < lowerCameraBounds.y 
				|| transform.position.x > upperCameraBounds.x || transform.position.y > upperCameraBounds.y) {
			transform.position = transform.position - translation;
		}
    }
}
