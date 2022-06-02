using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    public string collisionSide;
    int connectionCount = 0;
    GameObject preParent;
    BoxCollider2D boxCol;
    bool isCollide=false;
    bool isCollideOnce = false;
    private void Awake()
    {
        boxCol = gameObject.GetComponent<BoxCollider2D>();
        boxCol.enabled = false;
        boxCol.isTrigger = false;
    }
    void Start()
    {
        preParent = gameObject.transform.parent.transform.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (preParent.GetComponentInParent<TextMesh>().text == "x")
        {
            isCollide = true;
            boxCol.enabled = true;
            boxCol.isTrigger = true;
        }
        else
        {
            isCollide = false;
            boxCol.enabled = false;
            boxCol.isTrigger = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (isCollide)
        {
            isCollideOnce = true;
            if (isCollideOnce)
            {
                preParent.GetComponent<CollisionCollideManager>().SetCollideObject(collision.gameObject.transform.parent.gameObject.transform.parent.gameObject);
                isCollideOnce = false;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.transform.parent.GetComponent<CollisionCollideManager>().collidedObjects.Remove(collision.gameObject);
    }
   

}
