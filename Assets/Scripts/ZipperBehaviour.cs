using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipperBehaviour : MonoBehaviour
{
    const float OriginalVelocity = -0.02f;
    const float Acceleration = -0.002f;
    const float TopVelocity = -0.03f;

    const float EnterTime = 1.1f;
    const float WaitTime = EnterTime + 0.7f;

    float storedTime = 0.0f;
    float velocity = OriginalVelocity;

    Renderer _renderer;
    Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.AddForce(Vector2.down * 500);
    }

    // Update is called once per frame
    void Update()
    {
        //_rigidbody.MovePosition(_rigidbody.position + new Vector2(0.0f, velocity));

        //_rigidbody.velocity = Vector2.down * 5;

        if (_renderer.isVisible && storedTime < EnterTime)
        {
            storedTime += Time.deltaTime;
        }
        else if (storedTime > EnterTime && storedTime < WaitTime)
        {
            velocity = 0.0f;
            storedTime += Time.deltaTime;
        }
        else if (velocity == 0.0f && storedTime > WaitTime)
        {
            velocity = OriginalVelocity;
        }
        else if (storedTime > WaitTime)
        {
            velocity += Acceleration;
            if (velocity > TopVelocity)
            {
                velocity = TopVelocity;
            }
        }

        if (!_renderer.isVisible && storedTime > WaitTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //playerBullet layer
        {
            Destroy(gameObject);
        }
    }
}
