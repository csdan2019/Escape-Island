using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

#pragma warning disable 618, 649


public class PlayerMovementDT : MonoBehaviour
{


    public GameObject weapon;

    public CharacterController controller;
    private GameObject HUD;

    public float moveSpeed = 10f;
    public float gravity = -1000f;
    public float jumpHeight = 10f;
    public Transform groundCheck;
    //groundDistance creates the sphere to detect ground
    public float groundDistance = 0.4f;
    //groundMask registers what objects it should check for, such as ground only
    public LayerMask groundMask;
    bool isGrounded;

    private TreeFall treeScript;

    private RaycastHit hit;
    private Ray ray;
    public float rayDistance = 4f;

    //store current velocity
    Vector3 velocity;
    // Use this for initialization
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        weapon = GameObject.FindWithTag("TreeTag");
        HUD = GameObject.FindWithTag("HUD");

    }
    public float blablabla = 3;

    // Update is called once per frame
    void Update()
    {
        // Ray is automatic object of player
        ray = new Ray(transform.position + new Vector3(0f, controller.center.y, 0f), transform.forward);

        //ray origin is at transform.position
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance < rayDistance)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (hit.collider.gameObject.tag == "TreeTag")
                    {
                        Animator treeAnim;
                        treeScript = weapon.GetComponent<TreeFall>();
                        treeScript.treeHealth--;

                        treeAnim = weapon.GetComponent<Animator>();
                        if (treeScript.treeHealth <= 0)
                            treeAnim.SetBool("TreeFall", true);
                        Debug.Log("Test debug");
                        print("theere is an enemy ahead");

                    }
                }

            }
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //force player down to the ground
        if (velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + controller.transform.forward * z;

        //controller.transform.position = transform.position + Camera.main.transform.forward;
        controller.Move(move * moveSpeed * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        blablabla -= Time.deltaTime;
        if (blablabla < 0)
        {
            HUD.transform.GetChild(1).gameObject.SetActive(false);

        }



 



    }
    // Displays message panel upon collision
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("message popup");
        if (hit.collider == weapon.GetComponent<CapsuleCollider>())
        {

            blablabla = 0.5f;

            HUD.transform.GetChild(1).gameObject.SetActive(true);

        }
    }
}

