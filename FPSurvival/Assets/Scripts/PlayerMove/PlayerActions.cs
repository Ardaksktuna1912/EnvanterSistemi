using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField]GameObject Item;
    public Transform ItemHolder;
    GameObject tempýtem=null;

    public void Setýtem(GameObject itemin)

    {
        
        Item = itemin;
        if (tempýtem)
        {
            Destroy(tempýtem.gameObject);
        }
        tempýtem = Instantiate(itemin,ItemHolder);
        tempýtem.transform.localPosition = Vector3.zero;
    }
}
