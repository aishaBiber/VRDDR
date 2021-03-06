using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{

    public Animator anim;
    public string gripButton;

    private GrabbableObject hoveredObject;
    private GrabbableObject grabbedObject; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Grip()
    {
        anim.SetBool("Gripped", true);
    }

    void Release()
    {
        anim.SetBool("Gripped", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(gripButton))
        {

            Grip();
            if(hoveredObject != null)
            {
                grabbedObject = hoveredObject;
                grabbedObject.OnGrabStart(this);
                hoveredObject = null; 
            }
        }
        if (Input.GetButtonUp(gripButton))
        {
            Release();
            if (grabbedObject != null)
            {
                grabbedObject.OnGrabEnd();
                grabbedObject = null; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();

        if(grabbable != null)
        {
            hoveredObject = grabbable;
            grabbable.OnHoverStart(); 
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var grabbable = other.GetComponent<GrabbableObject>();
        if (grabbable != null)
        {
            hoveredObject.OnHoverEnd(); 
            hoveredObject = null;

        }
    }
}
