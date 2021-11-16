using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public float speed = 200;
    public float minHeight, maxHeight; 
    private bool isChecked;
    public Spawner spawnerRef; 


    // Start is called before the first frame update
    void Start()
    {
        isChecked = false; 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
        if(transform.localPosition.y > maxHeight)
        {
            //gameObject.SetActive(false);
            spawnerRef.RemoveArrow(gameObject); 
        }
    }
    public void Checker()
    {
       if(transform.localPosition.y > minHeight && transform.localPosition.y < maxHeight)
        {
            isChecked = true;
            Debug.Log("Hit"); 
        }
        else
        {
            isChecked = false;
            Debug.Log("No hit");
        }

      
    }


    
}
