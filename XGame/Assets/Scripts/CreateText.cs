using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateText : MonoBehaviour
{
    static int id = 0;
    public static TextMesh CreateWorldText(string text,GameObject gameObject,Transform parent = null, Vector3 localPosition=default(Vector3), int fontSize = 20, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder =5000)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent,text, gameObject,localPosition, fontSize, (Color)color, textAnchor,textAlignment,sortingOrder);
    }
    public static TextMesh CreateWorldText(Transform parent,string text, GameObject holder,Vector3 localPosition, int fontSize,Color color,TextAnchor textAnchor , TextAlignment textAlignment, int sortingOrder )
    {
        
        GameObject gameObject = new GameObject(id+"", typeof(TextMesh));
        Transform transform = gameObject.transform;
        GameObject holderClone = Instantiate(holder, new Vector3(0, 0, 0), Quaternion.identity);
        gameObject.tag ="square";
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        holderClone.transform.SetParent(transform);
        holderClone.gameObject.transform.position = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        id++;
        return textMesh;
    }
}
