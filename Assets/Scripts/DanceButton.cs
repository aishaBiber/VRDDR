using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceButton : MonoBehaviour
{

    public GameObject button;
    public Spawner LeftSpawner;
    public Spawner UpSpawner;
    public Color steppedColor;
    public DDRKey Key; 

    private Color defaultColor;
    

    public enum DDRKey { 
    DDR_Up_btn, DDR_Down_btn, DDR_Left_btn, DDR_Right_btn
    }
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        //material = GetComponent<Renderer>().material;
        //defaultColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftSpawner.ActivateInput();  
          
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            UpSpawner.ActivateInput();

        }
        if (Input.GetButtonDown(Key.ToString()))
        {
          
            material.color = steppedColor;
        }
        if (Input.GetButtonUp(Key.ToString()))
        {
          
            material.color = defaultColor;
        }

    }


    public void OnHitStepStart()
    {
        material.color = steppedColor;
    }

    public void OnHitStepEnd()
    {
        material.color = defaultColor;
    }
}
