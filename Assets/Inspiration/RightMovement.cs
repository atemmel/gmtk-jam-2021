using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMovement : MonoBehaviour
{

	Vector2 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        prevPos = new Vector2(0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
		/*
		Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

		if(prevPos == new Vector2(0.0f, 0.0f)) {
			prevPos = worldPosition;
		}

		var translation = worldPosition - prevPos;
		transform.position = transform.position + new Vector3(translation.x, translation.y, 0.0f);
		prevPos = worldPosition;
		*/


    }
}
