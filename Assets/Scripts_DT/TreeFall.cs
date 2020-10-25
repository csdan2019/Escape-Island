using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFall : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private PlayerMovementDT player;
    public int treeHealth = 5;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //treefall script
/*        if (Input.GetMouseButton(1))
        {
            anim.SetBool("TreeFall", true);
        }*/
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Colision with player");
        }
    }
}
