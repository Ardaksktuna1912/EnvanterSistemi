using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]GameObject Item;
    public Transform ItemHolder;
    GameObject temp�tem=null;

    public void Set�tem(GameObject itemin)

    {
        
        Item = itemin;
        if (temp�tem)
        {
            Destroy(temp�tem.gameObject);
        }
        temp�tem = Instantiate(itemin,ItemHolder);
        temp�tem.transform.localPosition = Vector3.zero;
    }
}
