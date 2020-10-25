using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject HUD;
    private GameObject messagePanel;
    private GameObject Tree;
    private GameObject Player;
    void Start()
    {
        Tree = GameObject.FindWithTag("TreeTag");
        Player = GameObject.FindWithTag("Player");



        //allows messagePanel
     //  transform.GetChild(1).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
