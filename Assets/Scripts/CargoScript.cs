using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoScript : MonoBehaviour
{
	public GameObject explosionVfx;
	public int maxHealth;
	int currentHealth;

	public Healthbar healthbar;
	AudioSource hurtSound, destroySound;
	Rigidbody2D _rigidbody;

	GameObject hitVfx;

    // Start is called before the first frame update
    void Start()
    {
        References.Cargo = gameObject;
		currentHealth = maxHealth;
		healthbar.SetMaxHealth(maxHealth);
		hurtSound = GetComponents<AudioSource>()[0];
		destroySound = GetComponents<AudioSource>()[1];
		_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
		 if (collision.collider.gameObject.CompareTag("HurtsPlayerToTouch")) {
			Hurt(1);
			_rigidbody.AddForce(collision.relativeVelocity * 1000.0f);
		 } 
     }

	void Hurt(int damage) {
		currentHealth -= damage;
		healthbar.SetHealth(currentHealth);
		if(currentHealth <= 0) {
			Die();
		} else {
			hurtSound.Play();
		}
	}

	void Die() {
		destroySound.Play();
		for(float f = 0.0f; f < 2.0f; f += 0.1f) {
			Invoke("RandomBoom", f);
		}
		Sayonara();
	}

	void RandomBoom() {
		float alpha = Random.Range(0.0f, 2.0f * Mathf.PI);
		float mag = Random.Range(1.0f, 1.5f);
		var vec2 = new Vector2(Mathf.Cos(alpha), Mathf.Sin(alpha)) * mag;
		var effect = Instantiate(explosionVfx, transform.position + new Vector3(vec2.x, vec2.y, 0.0f), Quaternion.identity);
		Destroy(effect, 0.5f);
	}

	public bool IsAlive() {
		return currentHealth > 0;
	}

	void Sayonara() {
		// o7
		CutTheRope(0);
		CutTheRope(1);
		_rigidbody.AddForce(Vector2.up * 10.0f);
	}

	void CutTheRope(int i) {
		var link = gameObject.transform.GetChild(i);
		var toDisconnect = link.gameObject.transform.GetChild(0);
		Destroy(toDisconnect.gameObject); 
	}
}
