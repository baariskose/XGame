using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCollideManager : MonoBehaviour
{
    public int collisionCount;
    public HashSet<GameObject> collidedObjects = new HashSet<GameObject>();
   //public List<GameObject> collidedObjects = new List<GameObject>();
    private List<GameObject> collidedObjectsTemp = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in collidedObjectsTemp)
        {
            if (item.GetComponent<TextMesh>().text != "x")
            {
                collidedObjects.Remove(item);
            }
        }
        if (collidedObjects.Count >= 2)
        {
            DeleteCollidedObjects();

            collidedObjects.Clear();
        }
       
    }
    public void SetCollideObject(GameObject gameObject)
    {
        if(collidedObjects.Count < 2)
        {
          if(this.gameObject.transform.parent.name != gameObject.name)
            {
                collidedObjects.Add(gameObject);
                collidedObjectsTemp.Add(gameObject);

            }

        }
    }
    public void DeleteCollidedObjects()
    {
        int i = 0;
        gameObject.transform.GetComponentInParent<TextMesh>().text = "";
        foreach (var item in collidedObjectsTemp)
        {
            item.GetComponent<TextMesh>().text = "";
            item.transform.GetChild(0).gameObject.GetComponent<CollisionCollideManager>().collidedObjects.Remove(gameObject.transform.parent.gameObject);
        }
    }
   
}
