using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public float MoveSpeed;
    private Vector3 StartPosition; 
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * MoveSpeed * transform.up);


    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = StartPosition; 
    }
}
