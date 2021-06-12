using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    //public Image[] cargo;
    public Slider slider;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Debug.Log("hit");
            health--;
            Destroy(collision.gameObject);
            slider.value = health;
            /*for (int i = 0; i < cargo.Length; i++)
            {
                if(i < health)
                {
                    cargo[i].enabled = true;
                }
                else
                {
                    cargo[i].enabled = false;
                }
            }*/
            
        }
    }
}
