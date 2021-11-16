using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPooling : MonoBehaviour
{

    public ObjectPool ArrowPool;

    private List<GameObject> _TempObjects = new List<GameObject>(); 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddNewArrow()
    {
        var _temp = ArrowPool.GetPooledObj();
        _temp.SetActive(true);
        _TempObjects.Add(_temp);
    }

    public void RemoveArrow()
    {
        ArrowPool.DeactivatePooledObj(_TempObjects[0]);
        _TempObjects.RemoveAt(0); 
    }
}
