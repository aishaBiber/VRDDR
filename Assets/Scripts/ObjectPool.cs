using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    public GameObject PoolObject;
    public int StartPool; 
    private List<GameObject> ActiveObjects = new List<GameObject>();
    private List<GameObject> InactiveObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < StartPool; i++)
        {
           var _tempPoolObj = Instantiate(PoolObject);
            _tempPoolObj.transform.SetParent(transform);
            _tempPoolObj.SetActive(false);
            InactiveObjects.Add(_tempPoolObj); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObj()
    {

        if (InactiveObjects.Count > 0 ) {
            var _tempPoolObj = InactiveObjects[0]; 
            InactiveObjects.RemoveAt(0);
            return _tempPoolObj;
        }
        else
        {
            var _tempPoolObj = Instantiate(PoolObject);
            _tempPoolObj.transform.SetParent(transform);
            _tempPoolObj.SetActive(false);
            InactiveObjects.Add(_tempPoolObj);
            return _tempPoolObj;
        }
      
    }


    public void DeactivatePooledObj(GameObject NewPooledObj)
    {
        NewPooledObj.SetActive(false);
        InactiveObjects.Add(NewPooledObj); 
    }
}
