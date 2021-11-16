using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{

    public Color hoveredColor;
    private Color defaultColor;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        defaultColor = material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnHoverStart()
    {
        material.color = hoveredColor;
    }

    public void OnHoverEnd()
    {
        material.color = defaultColor;
    }

    public void OnGrabStart(Grabber hand)
    {
        transform.SetParent(hand.transform); 
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true; 
    }
    public void OnGrabEnd()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
