using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testing : MonoBehaviour
{
    private Grid grid;
    public Material material;
    public GameObject holder;
     float cellSizeDefault = 10;
    private float currCellSize ;
    private float cellRatio;
    bool isGameStart = false;
    public string inputSize ="100.00";
    public List<GameObject> screenGameobjects = new List<GameObject>();
    public InputField inputText;
    public Text warningText;

    // Start is called before the first frame update
    private void Start()
    {
        warningText.text = "";

        isGameStart = false;
    }
    private void Update()
    {
        if (isGameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                grid.SetValue(GetMouseWorldPosition(), 1);
            }
        }
       
      
    }
    public void ResizeCollider()
    {

        foreach (var item in holder.transform.GetComponentsInChildren<BoxCollider2D>())
        {

            if (item.name == "Right")
            {
                item.size = new Vector2(4.916443f,1);
                item.offset = new Vector2(4.19622f,0);
                item.size = new Vector2(item.size.x * cellRatio, item.size.y);
                item.offset = new Vector2(item.offset.x * cellRatio, item.offset.y);
            }
            else if (item.name =="Left")
            {
                item.size = new Vector2(5.076385f, 1);
                item.offset = new Vector2(-2.517754f, 0);
                item.size = new Vector2(item.size.x * cellRatio, item.size.y);
                item.offset = new Vector2(item.offset.x * cellRatio, item.offset.y);
            }
            else if (item.name =="Up")
            {
                item.size = new Vector2(0.76017f, 4.99752f);
                item.offset = new Vector2(0.7992821f, 3.437878f);
                item.size = new Vector2(item.size.x , item.size.y * cellRatio);
                item.offset = new Vector2(item.offset.x , item.offset.y * cellRatio);
            }
            else if (item.name=="Down")
            {
                item.size = new Vector2(0.7202072f, 4.3979f);
                item.offset = new Vector2(0.899189f, -3.817636f);
                item.size = new Vector2(item.size.x, item.size.y * cellRatio);
                item.offset = new Vector2(item.offset.x, item.offset.y * cellRatio);
            }
        }
    }
    public  Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
    public void StartGame()
    {
        try
        {
            
            warningText.text = "";
            if (int.Parse(inputText.text) >= 65)
            {
                warningText.text = "Your input need to less than 65";
            }
            else
            {
                if (screenGameobjects.Count > 0)
                {
                    foreach (var item in screenGameobjects)
                    {
                        Destroy(item);
                    }
                }
                screenGameobjects.Clear();
                currCellSize = 115 / float.Parse(inputText.text);
                cellRatio = (currCellSize / cellSizeDefault);
                ResizeCollider();
                isGameStart = true;
                grid = new Grid(int.Parse(inputText.text), int.Parse(inputText.text), currCellSize, gameObject.transform.position, material, holder);
                screenGameobjects.AddRange(GameObject.FindGameObjectsWithTag("square"));
                screenGameobjects.AddRange(GameObject.FindGameObjectsWithTag("line"));
                warningText.text = "";
            }
           
        }
        catch (System.Exception)
        {
            warningText.text = "Your Input need to be number";


        }
        
        
    }

}
