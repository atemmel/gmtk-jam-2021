using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCrosshair : MonoBehaviour
{
    public Transform targetTransform;
    public float trackingSpeed;
    public float startLerpingDistance;
    public GameObject bulletPrefab;

    Rigidbody2D ourRigidbody2D;
	AudioSource _audioSource;


	const float timeBetweenShots = 0.3f;
	float collectedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody2D = GetComponent<Rigidbody2D>();
        if (targetTransform.name == "MouseCrosshair")
        {
			_audioSource = GetComponent<AudioSource>();
            References.MouseShip = gameObject;
        }
        else if (targetTransform.name == "WasdCrosshair")
        {
            References.WasdShip = gameObject;
        }
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

		collectedTime += Time.deltaTime;


		if (Input.GetButton("Fire3") && collectedTime >= timeBetweenShots) {
			collectedTime = 0.0f;
            var bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
			if(_audioSource != null) {
				_audioSource.Play();
			}
        }
    }
}
