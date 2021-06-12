using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkBase : MonoBehaviour
{
	public Rigidbody2D hook;
	public GameObject prefabLinkSegment;
	public int numLinks = 5;
	public GameObject objectToHold;
	public int nthHingeToInteractWith;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLink();
    }

	void GenerateLink() {
		Rigidbody2D prevBody = hook;
		for(int i = 0; i < numLinks; i++) {
			GameObject newLink = Instantiate(prefabLinkSegment);
			newLink.transform.parent = transform;
			newLink.transform.position = transform.position;
			HingeJoint2D hj = newLink.GetComponent<HingeJoint2D>();
			hj.connectedBody = prevBody;

			prevBody = newLink.GetComponent<Rigidbody2D>();

			if(i == numLinks - 1) {
				objectToHold.GetComponents<HingeJoint2D>()[nthHingeToInteractWith].connectedBody = prevBody;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
