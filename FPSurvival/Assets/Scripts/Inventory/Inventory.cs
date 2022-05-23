using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ScInventory inventorySc�;
    InventoryUIControl inventUI;
    bool Swapping;
    Slot tempslot;
    int tempIndex;
    public PlayerActions pactions;
    private void Start()
    {
        inventUI = GetComponent<InventoryUIControl>();
        //inventUI.UpdateUI();
    }
    public void DeleteItem()
    {
        if (Swapping==true)
        {
            inventorySc�.DeleteItem(tempIndex);
            Swapping = false;
            inventUI.UpdateUI();
        }
    }

    public void DropItem()
    {
        if (Swapping==true)
        {
            inventorySc�.DropItem(tempIndex,gameObject.transform.position+Vector3.forward);
            Swapping = false;
            inventUI.UpdateUI();
        }
    }

    public void CurrenItem(int Index)
    {
        if (inventorySc�.�nventSlots[Index].objectSc�Item)
        {
            pactions.Set�tem(inventorySc�.�nventSlots[Index].objectSc�Item.itemprefab); 
        }
    }
    public void SwapItem(int index)
    {
        if (Swapping==false)
        {
            //Hangi Buttona t�kland�g�n� g�steriyor. Haf�zada tutuyor
            tempIndex = index;
            tempslot = inventorySc�.�nventSlots[tempIndex];
            Swapping = true;
        }
        else if(Swapping==true)
        {
            inventorySc�.�nventSlots[tempIndex] = inventorySc�.�nventSlots[index];
            inventorySc�.�nventSlots[index] = tempslot;
            Swapping = false;
        }
        inventUI.UpdateUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (inventorySc�.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                inventUI.UpdateUI();
            }
           
        }
    }
}
