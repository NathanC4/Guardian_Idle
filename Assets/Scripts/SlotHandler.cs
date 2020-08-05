using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotHandler : MonoBehaviour
{
    //test
    public Image draggableItem;
    public Inventory inventory = Inventory.instance;
    public EquipHandler equipHandler = EquipHandler.instance;

    ItemSlot source = null;

    void Awake()
    {
        //inventory = Inventory.instance;
        //equipHandler = EquipHandler.instance;

        inventory.OnBeginDragEvent += BeginDrag;
        inventory.OnDragEvent += Drag;
        inventory.OnEndDragEvent += EndDrag;
        inventory.OnDropEvent += Drop;

        equipHandler.OnBeginDragEvent += BeginDrag;
        equipHandler.OnDragEvent += Drag;
        equipHandler.OnEndDragEvent += EndDrag;
        equipHandler.OnDropEvent += Drop;

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

        if (source == null)
            return;

        if (!IsValid(source.GetItem(), destination) )
            return;

        // Move or swap items
        if (destination.IsEmpty()) // Destination is empty, simply move item
        {
            if (destination is EquipSlot)
            {
                EquipHandler.instance.Add((Equipment) source.GetItem());
            }

            if (source is EquipSlot)
            {
                EquipHandler.instance.Remove((Equipment)source.GetItem());
            }

            destination.AddItem(source.GetItem());
            source.Clear();
        }
        else
        {
            // Check if swap is valid
            if (!IsValid(destination.GetItem(), source))
                return;

            if (destination is EquipSlot)
            {
                EquipHandler.instance.Remove((Equipment)destination.GetItem());
                EquipHandler.instance.Add((Equipment)source.GetItem());
            }

            Item temp = destination.GetItem();
            destination.AddItem(source.GetItem());
            source.AddItem(temp);
        }

        destination.GetItem().ShowTooltip(); // Show tooltip for moved item
    }

    // Check if slot is a valid destination for item
    public bool IsValid(Item item, ItemSlot slot)
    {
        
        if (slot is InventorySlot)
            return true;

        if (slot is EquipSlot)
        {
            if (item is Equipment)
            {
                EquipSlot es = (EquipSlot)slot;
                Equipment eq = (Equipment)item;

                Debug.Log("Slot wear slot: " + es);
                Debug.Log("Item wear slot: " + eq.GetWearSlot());

                return es.GetWearSlot() == eq.GetWearSlot();
            }
        }

        return false;
    }
}
    
