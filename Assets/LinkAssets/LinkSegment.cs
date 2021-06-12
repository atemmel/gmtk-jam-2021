using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// homeboy Julia
// https://www.youtube.com/watch?v=yQiR2-0sbNw
// pogchamp Julia pogchamp Julia

public class LinkSegment : MonoBehaviour
{
	public GameObject connectedAbove, connectedBelow;

    // Start is called before the first frame update
    void Start()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
		LinkSegment aboveSegment = connectedAbove.GetComponent<LinkSegment>();
		if(aboveSegment != null) {
			aboveSegment.connectedBelow = gameObject;
			float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.y;
			GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0.0f, spriteBottom * -0.25f);
		} else {
			GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0.0f, 0.0f);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
