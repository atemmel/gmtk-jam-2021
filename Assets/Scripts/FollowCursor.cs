using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
	public GameObject cursorToTrack;
	public float trackingVelocity;
	public float stopTrackingDistance;
	public float startLerpingDistance;

	//const float lerpTime = 100.7f;
	//const float lerpTime = 0.5f;
	const float lerpTime = 0.7f;
	float storedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var target = new Vector2(cursorToTrack.transform.position.x, cursorToTrack.transform.position.y);
		var me = new Vector2(transform.position.x, transform.position.y);

		var dist = Vector2.Distance(target, me);
		if(dist <= stopTrackingDistance) {
			storedTime = 0.0f;
			return;	// aight, imma head out
		}

		var delta = target - me;
		var m = delta.normalized * trackingVelocity;

		if(dist < startLerpingDistance) {
			storedTime += Time.deltaTime;
			var lerped = Vector2.Lerp(me + m, me, storedTime / lerpTime);
			transform.position = new Vector3(lerped.x, lerped.y, transform.position.z);
		} else {
			storedTime = 0.0f;
			transform.position = transform.position + new Vector3(m.x, m.y, 0.0f);
		}
    }
}
