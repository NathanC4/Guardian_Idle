using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotHandler : MonoBehaviour
{
    public Image draggableItem;
    public Inventory inventory = Inventory.instance;
    public EquipHandler equipHandler = EquipHandler.instance;
    //public Inventory2 equipHandler = Inventory2.instance;

    ItemSlot source = null;

    void Awake()
    {
        //inventory = Inventory.instance;
        //equipHandler = EquipHandler.instance;

        

        equipHandler.OnBeginDragEvent += BeginDrag;
        equipHandler.OnDragEvent += Drag;
        equipHandler.OnEndDragEvent += EndDrag;
        equipHandler.OnDropEvent += Drop;

        inventory.OnBeginDragEvent += BeginDrag;
        inventory.OnDragEvent += Drag;
        inventory.OnEndDragEvent += EndDrag;
        inventory.OnDropEvent += Drop;
    }

    public void BeginDrag(ItemSlot slot)
    {
        Debug.Log("Begin dragging: " + slot);

        if (!slot.IsEmpty()) // don't need to do anything if user is dragging an empty slot
        {
            source = slot;

            draggableItem.sprite = slot.icon.sprite;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }

    public void Drag(ItemSlot slot)
    {
        Debug.Log("Dragging: " + slot);

        if (source != null)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    public void EndDrag(ItemSlot slot)
    {
        Debug.Log("End dragging: " + slot);

        if (source != null)
        {
            source = null;

            draggableItem.gameObject.SetActive(false);
        }
    }

    public void Drop(ItemSlot destination)
    {
        Debug.Log("Dropping: " + destination);

        if (source != null)
        {
            // move or swap items
            if (destination.IsEmpty())
            {
                destination.AddItem(source.GetItem());
                source.Clear();
            }
            else
            {
                Item temp = destination.GetItem();
                destination.AddItem(source.GetItem());
                source.AddItem(temp);
            }
        }
    }
}
    
