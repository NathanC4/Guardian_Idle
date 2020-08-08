using System.Collections.Generic;
using CI.QuickSave;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    //string test;
    List<ItemSlot> slots;
    Item item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Save()
    {
        slots = Inventory.instance.slots;
    
        QuickSaveWriter writer = QuickSaveWriter.Create("Test File");
        
        
        //Debug.Log("slots.Count: " + slots.Count);
        //writer.Write("2", slots[0].GetItem());
    
    
        for (int i = 0; i < slots.Count; i++)
        {
            if ( !(slots[i].IsEmpty() ) )
            {
                item = slots[i].GetItem();
                string key = "invslot" + i;
                string data = JsonUtility.ToJson(item, false);
                Debug.Log(key);
                writer.Write(key, data);

                if (item is Equipment)
                    writer.Write(key + "_type", "equipment");
                else
                    writer.Write(key + "_type", "item");


                Debug.Log("Wrote item in slot" + i + ": " + item);
                Debug.Log("JSON Utility: " + JsonUtility.ToJson(item, false));
            }
        }
    
        writer.Commit();
        
    }

    public void Load()
    {
        QuickSaveReader reader = QuickSaveReader.Create("Test File");
        
        slots = Inventory.instance.slots;

        for (int i = 0; i < slots.Count; i++)
        {
            string key = "invslot" + i;

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

                Debug.Log("read item: " + item);
                slots[i].AddItem(item);
            }
        }

    }
}

