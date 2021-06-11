using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShipBehaviour : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D ourRigidbody;

    //public List<WeaponBehaviour> weapons = new List<WeaponBehaviour>();
    //public int selectedWeaponIndex;


    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
        //References.thePlayer = gameObject;
        //selectedWeaponIndex = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        //WASD to Move        
        //Vector2 inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //ourRigidbody.velocity = inputVector * playerSpeed;

        ////Look at cursor
        //Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Plane playerPlane = new Plane(Vector3.up, transform.position);
        //playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        //Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 directionToMouse = (mousePosition - transform.position).normalized;
        ourRigidbody.velocity = directionToMouse * playerSpeed;


        //ourRigidbody.velocity += new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));


        //ourRigidbody.velocity = Vector2.MoveTowards(, , playerSpeed);
        //transform.LookAt(cursorPosition);


        //Shooting
        //if (Input.GetButton("Fire1") && weapons.Count > 0)
        //{
        //    //Tell gun to shoot
        //    //weapons[selectedWeaponIndex].Fire(cursorPosition);
        //}


        //if (Input.GetButtonDown("Fire2"))
        //{
        //    //Tell gun to shoot
        //    ChangeWeaponIndex(selectedWeaponIndex + 1);
        //}
    }

    //private void ChangeWeaponIndex(int index)
    //{
    //    //Change weapon index
    //    selectedWeaponIndex = index;
    //    //if gone to far, go back to zero
    //    if (selectedWeaponIndex >= weapons.Count)
    //    {
    //        selectedWeaponIndex = 0;
    //    }

    //    //For each weapon in our list
    //    for (int i = 0; i < weapons.Count; i++)
    //    {
    //        if (i == selectedWeaponIndex)
    //        {   //make current waapon enabled
    //            weapons[i].gameObject.SetActive(true);
    //        }
    //        else
    //        {   //Disable outer weapons
    //            weapons[i].gameObject.SetActive(false);
    //        }
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    WeaponBehaviour thierWeapon = other.GetComponentInParent<WeaponBehaviour>();
    //    if (thierWeapon != null)
    //    {
    //        weapons.Add(thierWeapon);
    //        thierWeapon.transform.position = transform.position;
    //        thierWeapon.transform.rotation = transform.rotation;
    //        thierWeapon.transform.SetParent(transform);
    //        ChangeWeaponIndex(weapons.Count - 1);
    //    }
    //}
}
