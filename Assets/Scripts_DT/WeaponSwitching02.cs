using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching02 : MonoBehaviour
{
    public int currentWeapon = 0;
    public int maxWeapons = 2;
    public Animator theAnimator;

    private void Start()
    {
        
    }
    // Start is called before the first frame update
    void Awake()
    {

        SelectWeapon(0);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon + 1 <= maxWeapons)
            {
                currentWeapon++;
            }
            else
            {
                currentWeapon = 0;
            }
          //  print("scrolll wheel activated");
            SelectWeapon(currentWeapon);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon -1>= 0)
            {
                currentWeapon--;
            }
            else
            {
                currentWeapon = maxWeapons;
            }
            SelectWeapon(currentWeapon);
        }

        if(currentWeapon== maxWeapons + 1)
        {
            currentWeapon = 0;
        }
        if (currentWeapon == -1)
        {
            currentWeapon = maxWeapons;
        }
       

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
            SelectWeapon(currentWeapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
            SelectWeapon(currentWeapon);
        }
       // print("current weapon is " + currentWeapon);
        
        
        
        //attack
        if (Input.GetMouseButtonDown(1))
        {
            theAnimator.SetBool("Hit01", true);
        }
        else
        {
            theAnimator.SetBool("Hit01", false);

        }
        if (Input.GetMouseButtonDown(0))
        {
            theAnimator.SetBool("Hit02", true);
        }
        else
        {
            theAnimator.SetBool("Hit02", false);

        }
    }
    void SelectWeapon(int index)
    {
        for(int i=0;i<transform.childCount; i++)
        {
            //activate the selected weapon
            if (i == index)
            {
                if(transform.GetChild(i).name == "Fists")
                {
                   // print("Fists");
                    theAnimator.SetBool("WeaponIsOn", false);
                }
                else
                {
                    theAnimator.SetBool("WeaponIsOn", true);

                }
                transform.GetChild(i).gameObject.SetActive(true); 
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

        }

    }

}

