using System;
using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items = new List<Item>();

    public List<ItemSlot> slots;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    public int idCounter; // increments when item is created
    public int maxSize = 20;

    void OnValidate()
    {
        GetComponentsInChildren(includeInactive: true, result: slots);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory!");
        }
        instance = this;

        foreach (ItemSlot slot in slots)
        {
            slot.OnBeginDragEvent += OnBeginDragEvent;
            slot.OnDragEvent += OnDragEvent;
            slot.OnEndDragEvent += OnEndDragEvent;
            slot.OnDropEvent += OnDropEvent;
        }
    }

    public void Update()
    {
        slots[39].Clear();
    }

    public void Add(Item item)
    {
        Debug.Log("adding: " + item.name);

        if (items.Count >= maxSize)
            Debug.Log("Not enough room in inventory");

        items.Add(item);

        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty())
            {
                slot.AddItem(item);
                break;
            }
        }
    }

    public void Remove(Item item)
    {
        Debug.Log("removing: " + item.name);
        items.Remove(item);
    }

    public void ClearSlots()
    {
        foreach (ItemSlot s in slots)
            s.Clear();
    }

    public void Save()
    {
        QuickSaveWriter writer = QuickSaveWriter.Create("GuardianIdleSave");
        Item item;
        string key;

        for (int i = 0; i < slots.Count; i++)
        {
            key = "invslot" + i;

            if (!(slots[i].IsEmpty()))
            {
                item = slots[i].GetItem();
                string data = JsonUtility.ToJson(item, false);
                Debug.Log(key);
                writer.Write(key, data);
                writer.Write(key + "_icon", item.imagePath);

                if (item is Equipment)
                    writer.Write(key + "_type", "equipment");
                else
                    writer.Write(key + "_type", "item");


                Debug.Log("Wrote item in slot" + i + ": " + item);
                Debug.Log("JSON Utility: " + JsonUtility.ToJson(item, false));
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
        Item item;
        string key;

        for (int i = 0; i < slots.Count; i++)
        {
            key = "invslot" + i;

            if (reader.Exists(key))
            {
                string JsonString = reader.Read<string>(key);
                string type = reader.Read<string>(key + "_type");

                if (type == "equipment")
                {
                    item = JsonUtility.FromJson<Equipment>(JsonString);
                }
                else
                {
                    item = JsonUtility.FromJson<Item>(JsonString);
                }

                string icon = reader.Read<string>(key + "_icon");
                item.SetIcon(icon);

                Debug.Log("adding item to slot: " + i);
                slots[i].AddItem(item);
            }
            else
            {
                // Saved slot is empty, clear the slot to prevent duplication
                Debug.Log("clearing slot: " + i);
                slots[i].Clear();
            }
        }
    }
}
