using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPool ArrowPool;

    //private List<GameObject> _TempObjects = new List<GameObject>();
    private Queue<GameObject> Arrows = new Queue<GameObject>();

    private float RandomTime; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimedSpawn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TimedSpawn()
    {


        while (true)
        {
            RandomTime = Random.Range(0.4f, 2.5f); 
            yield return new WaitForSeconds(RandomTime);
            AddNewArrow(); 
        }
    }

    public void AddNewArrow()
    {

        
        var _temp = ArrowPool.GetPooledObj();
        _temp.SetActive(true);

        Arrows.Enqueue(_temp); 
       // _TempObjects.Add(_temp);

        _temp.transform.position = transform.position;

        _temp.GetComponent<GamePiece>().spawnerRef = this; 
        
    }

    public void RemoveArrow(GameObject Obj)
    {
       
        ArrowPool.DeactivatePooledObj(Obj);
        Arrows.Dequeue(); 
        //_TempObjects.RemoveAt(0);
    }
    public void ActivateInput()
    {
        GameObject _temp = Arrows.Dequeue();
        //ArrowPool.DeactivatePooledObj();
        //Arrows.Dequeue();
        _temp.GetComponent<GamePiece>().Checker();
        ArrowPool.DeactivatePooledObj(_temp);

    }
}
