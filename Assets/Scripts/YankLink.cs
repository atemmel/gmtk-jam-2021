using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YankLink : MonoBehaviour
{
	public GameObject linkToYank;
	public string keyToPress;
	
	const float yankMag = 20.0f;

	Rigidbody2D originBody, bodyToYank, body2ToYank;
	Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        var linkOrigin = linkToYank.gameObject.transform.GetChild(0).gameObject;
        var firstSegmentInLink = linkToYank.gameObject.transform.GetChild(1).gameObject;
        var secondSegmentInLink = linkToYank.gameObject.transform.GetChild(2).gameObject;
		originBody = linkOrigin.GetComponent<Rigidbody2D>();
		bodyToYank = firstSegmentInLink.GetComponent<Rigidbody2D>();
		body2ToYank = secondSegmentInLink.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown(keyToPress)) {
			var delta = originBody.position - body2ToYank.position;
			offset = delta * yankMag;
			bodyToYank.MovePosition(bodyToYank.position + offset);
			body2ToYank.MovePosition(body2ToYank.position + offset);
		}
    }
}
