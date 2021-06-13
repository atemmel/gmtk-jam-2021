using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoScript : MonoBehaviour
{
	public int maxHealth;
	int currentHealth;

	public Healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        References.Cargo = gameObject;
		currentHealth = maxHealth;
		healthbar.SetMaxHealth(maxHealth);
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
	}
}
