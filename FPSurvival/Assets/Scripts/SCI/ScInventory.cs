using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptableobject/Inventory")]
public class ScInventory : ScriptableObject
{
    public List<Slot> �nventSlots=new List<Slot>();
    int stacklimit=3;
    public void DeleteItem(int index)
    {
        �nventSlots[index].isFull = false;
        �nventSlots[index].itemCount = 0;
        �nventSlots[index].objectSc�Item = null;
    }

    public void DropItem(int index,Vector3 pos)
    {
        for (int i = 0; i < �nventSlots[index].itemCount; i++)
        {
            GameObject TempItem = Instantiate(�nventSlots[index].objectSc�Item.itemprefab);
            TempItem.transform.position = pos+new Vector3(i,-0.36f,0) ; 
        }
        DeleteItem(index);
    }
    public bool AddItem(Sc�Object item)
    {
        foreach (var slot in �nventSlots)
        {
            if (slot.objectSc�Item==item)
            {
                if (slot.objectSc�Item.StackItem)
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
    public Sc�Object objectSc�Item;

    public void AddItemSlot(Sc�Object itemslot)
    {
        this.objectSc�Item = itemslot;
        if (itemslot.StackItem==false)
        {
            isFull = true;
        }

        itemCount++;
    }



}
