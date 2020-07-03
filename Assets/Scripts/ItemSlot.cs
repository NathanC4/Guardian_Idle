using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
    Item item;
    public Image icon;

    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDropEvent;
   

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void Clear()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public Item GetItem()
    {
        return item;
    }

    public bool IsEmpty()
    {
        return item == null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //if (item != null)
        {
            icon.color = new Color(1, 1, 1, 0.5f);
            OnBeginDragEvent?.Invoke(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //if (item != null)
            OnDragEvent?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //if (item != null)
        {
            icon.color = new Color(1, 1, 1, 1);
            OnEndDragEvent?.Invoke(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDropEvent?.Invoke(this);
    }
}
