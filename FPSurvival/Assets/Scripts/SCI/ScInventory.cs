using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptableobject/Inventory")]
public class ScInventory : ScriptableObject
{
    public List<Slot> ÝnventSlots=new List<Slot>();
    int stacklimit=3;
    public void DeleteItem(int index)
    {
        ÝnventSlots[index].isFull = false;
        ÝnventSlots[index].itemCount = 0;
        ÝnventSlots[index].objectScýItem = null;
    }

    public void DropItem(int index,Vector3 pos)
    {
        for (int i = 0; i < ÝnventSlots[index].itemCount; i++)
        {
            GameObject TempItem = Instantiate(ÝnventSlots[index].objectScýItem.itemprefab);
            TempItem.transform.position = pos+new Vector3(i,-0.36f,0) ; 
        }
        DeleteItem(index);
    }
    public bool AddItem(ScýObject item)
    {
        foreach (var slot in ÝnventSlots)
        {
            if (slot.objectScýItem==item)
            {
                if (slot.objectScýItem.StackItem)
                {
                    if (slot.itemCount<stacklimit)
                    {
                        slot.itemCount++;
                        if (slot.itemCount>=stacklimit)
                        {
                            slot.isFull = true;
                        }
                        return true;
                    }
                   
                }
            }
            else if (slot.itemCount==0)
            {
                slot.AddItemSlot(item);
                return true;
            }
        }
        return false;
    }
}


[System.Serializable]
public class Slot
{
    public bool isFull;
    public int itemCount;
    public ScýObject objectScýItem;

    public void AddItemSlot(ScýObject itemslot)
    {
        this.objectScýItem = itemslot;
        if (itemslot.StackItem==false)
        {
            isFull = true;
        }

        itemCount++;
    }



}
