using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCrosshair : MonoBehaviour
{
	public CargoScript cargo;
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

		Vector3 positionDelta;
		if(!cargo.IsAlive()) {
			if(targetTransform.name == "MouseCrosshair") {
				positionDelta = Camera.main.ViewportToScreenPoint(new Vector3(1.1f, 1.1f, 0.0f)) - transform.position;
			} else {
				positionDelta = Camera.main.ViewportToScreenPoint(new Vector3(-1.1f, 1.1f, 0.0f)) - transform.position;
			}
		} else {
			positionDelta = targetTransform.position - transform.position;
		}

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

		if(!cargo.IsAlive()) {
			return;
		}


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
