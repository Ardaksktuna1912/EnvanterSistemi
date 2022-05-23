using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ScInventory inventoryScý;
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
            inventoryScý.DeleteItem(tempIndex);
            Swapping = false;
            inventUI.UpdateUI();
        }
    }

    public void DropItem()
    {
        if (Swapping==true)
        {
            inventoryScý.DropItem(tempIndex,gameObject.transform.position+Vector3.forward);
            Swapping = false;
            inventUI.UpdateUI();
        }
    }

    public void CurrenItem(int Index)
    {
        if (inventoryScý.ÝnventSlots[Index].objectScýItem)
        {
            pactions.Setýtem(inventoryScý.ÝnventSlots[Index].objectScýItem.itemprefab); 
        }
    }
    public void SwapItem(int index)
    {
        if (Swapping==false)
        {
            //Hangi Buttona týklandýgýný gösteriyor. Hafýzada tutuyor
            tempIndex = index;
            tempslot = inventoryScý.ÝnventSlots[tempIndex];
            Swapping = true;
        }
        else if(Swapping==true)
        {
            inventoryScý.ÝnventSlots[tempIndex] = inventoryScý.ÝnventSlots[index];
            inventoryScý.ÝnventSlots[index] = tempslot;
            Swapping = false;
        }
        inventUI.UpdateUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (inventoryScý.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                inventUI.UpdateUI();
            }
           
        }
    }
}
