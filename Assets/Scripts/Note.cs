using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private bool isActive = false;
    private Material defaultMaterial;

    public Material GlowMaterial;



    // Start is called before the first frame update
    void Start()
    {
        defaultMaterial = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsActive()
    {
        return isActive; 
    }

    private void OnTriggerEnter(Collider other)
    {
        isActive = true;
        GetComponent<Renderer>().material = GlowMaterial;
    }

    private void OnTriggerExit(Collider other)
    {

        isActive =  false;
        GetComponent<Renderer>().material = defaultMaterial;
    }
}
