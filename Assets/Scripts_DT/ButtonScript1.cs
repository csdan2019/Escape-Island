using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript1 : MonoBehaviour
{
    // Start is called before the first frame update

    private Image image;
    public Color myColor;
    void Start()
    {
        image = GetComponent<Image>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            Debug.Log("Help");
            myColor = new Color(.3f,.8f,.2f);
            image.color = myColor;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Help");
            myColor = new Color(0,0,0);
            image.color = myColor;
        }

    }
}
