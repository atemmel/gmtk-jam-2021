using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoScript : MonoBehaviour
{
	public int maxHealth;
	int currentHealth;

	public Healthbar healthbar;
	AudioSource hurtSound, destroySound;

    // Start is called before the first frame update
    void Start()
    {
        References.Cargo = gameObject;
		currentHealth = maxHealth;
		healthbar.SetMaxHealth(maxHealth);
		hurtSound = GetComponents<AudioSource>()[0];
		destroySound = GetComponents<AudioSource>()[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

     private void OnCollisionEnter2D(Collision2D collision)
     {
		 if (collision.collider.gameObject.CompareTag("HurtsPlayerToTouch")) {
			 Hurt(1);
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
	}
}
