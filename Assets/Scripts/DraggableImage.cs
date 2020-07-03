using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableImage : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler
{
    

    void Start()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log(gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(transform.parent);
        transform.localPosition = Vector2.zero;
    }
}
    
