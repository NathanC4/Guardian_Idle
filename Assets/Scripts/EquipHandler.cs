using System;
using System.Collections.Generic;
using CI.QuickSave;
using UnityEngine;


public class EquipHandler : MonoBehaviour
{
    public static EquipHandler instance;

    public List<Equipment> items = new List<Equipment>();

    public List<EquipSlot> slots;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: slots);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EquipHandler!");
        }
        instance = this;

        //GetComponentsInChildren(includeInactive: true, result: slots);

        foreach (ItemSlot slot in slots)
        {
            slot.OnBeginDragEvent += OnBeginDragEvent;
            slot.OnDragEvent += OnDragEvent;
            slot.OnEndDragEvent += OnEndDragEvent;
            slot.OnDropEvent += OnDropEvent;
        }
    }

    public void Add(Equipment item)
    {
        Debug.Log("adding eq: " + item.name);

        items.Add(item);
        item.Equip();
    }

    public void Remove(Equipment item)
    {
        Debug.Log("removing eq: " + item.name);
        items.Remove(item);

        // Recalculate equipment stats
        Player.instance.ResetStats();
        
        foreach(Equipment e in items)
        {
            e.AddStats();
        }

        Player.instance.UpdateStats();
    }

    public void Save()
    {
        QuickSaveWriter writer = QuickSaveWriter.Create("GuardianIdleSave");
        Equipment item;
        string key;

        for (int i = 0; i < slots.Count; i++)
        {
            key = "equipSlot" + i;

            if (!(slots[i].IsEmpty()))
            {
                item = (Equipment)slots[i].GetItem();
                string data = JsonUtility.ToJson(item, false);

                writer.Write(key, data);
            }
            else
            {
                writer.Delete(key);
            }
        }

        writer.Commit();
    }

    public void Load()
    {
        QuickSaveReader reader = QuickSaveReader.Create("GuardianIdleSave");
        Equipment item;
        string key;

        for (int i = 0; i < slots.Count; i++)
        {
            key = "equipSlot" + i;

            if (reader.Exists(key))
            {
                string JsonString = reader.Read<string>(key);

                
                item = JsonUtility.FromJson<Equipment>(JsonString);
                slots[i].AddItem(item);
            }
            else
            {
                // Saved slot is empty, clear the slot to prevent duplication
                slots[i].Clear();
            }
        }
    }
}
