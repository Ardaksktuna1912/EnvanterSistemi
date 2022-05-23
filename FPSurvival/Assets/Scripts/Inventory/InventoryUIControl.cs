using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIControl : MonoBehaviour
{
    public List<SlotUIControl> SlotUIlist = new List<SlotUIControl>();
    Inventory userInventroy;
    private void Start()
    {
        userInventroy = GetComponent<Inventory>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i <SlotUIlist.Count; i++)
        {
            if (userInventroy.inventorySc�.�nventSlots[i].itemCount>0)
            {
                SlotUIlist[i].ItemImg.sprite = userInventroy.inventorySc�.�nventSlots[i].objectSc�Item.itemIcon;
                if (userInventroy.inventorySc�.�nventSlots[i].objectSc�Item.StackItem==true)
                {
                    SlotUIlist[i].ItemCountText.gameObject.SetActive(true);
                    SlotUIlist[i].ItemCountText.text = userInventroy.inventorySc�.�nventSlots[i].itemCount.ToString();
                }
                else
                {
                    SlotUIlist[i].ItemCountText.gameObject.SetActive(false);
                }
            }
            else
            {
                SlotUIlist[i].ItemImg.sprite =null;
                SlotUIlist[i].ItemCountText.gameObject.SetActive(false);
            }
        }
    }
}
