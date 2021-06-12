using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCrosshair : MonoBehaviour
{
    public Transform targetTransform;
    public float trackingSpeed;
    public float startLerpingDistance;

    Rigidbody2D ourRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var positionDelta = targetTransform.position - transform.position;
        var newVelocity = positionDelta.normalized * trackingSpeed;

        if (positionDelta.magnitude < startLerpingDistance)
        {
            ourRigidbody2D.velocity = Vector2.Lerp(Vector2.zero, newVelocity, positionDelta.magnitude / startLerpingDistance);
        }
        else
        {
            ourRigidbody2D.velocity = newVelocity;
        }
    }
}
