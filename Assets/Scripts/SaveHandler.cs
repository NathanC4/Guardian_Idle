using System.Collections.Generic;
using CI.QuickSave;
using UnityEngine;

public class SaveHandler : MonoBehaviour
{
    //string test;
    List<InventorySlot> slots;
    Item item;


    // Start is called before the first frame update
    void Start()
    {
        QuickSaveReader reader = QuickSaveReader.Create("Test File");
        
    }

    //public void Save()
    //{
    //    slots = Inventory.instance.slots;
    //
    //    QuickSaveWriter writer = QuickSaveWriter.Create("Test File");
    //    
    //    
    //    //Debug.Log("slots.Count: " + slots.Count);
    //    //writer.Write("2", slots[0].GetItem());
    //
    //
    //    for (int i = 0; i < slots.Count; i++)
    //    {
    //        if ( !(slots[i].IsEmpty() ) )
    //        {
    //            item = slots[i].GetItem();
    //            string key = "invslot" + i;
    //            Debug.Log(key);
    //            writer.Write(key, item);
    //            Debug.Log("Wrote item in slot" + i + ": " + item);
    //            Debug.Log("JSON Utility: " + JsonUtility.ToJson(item, true));
    //        }
    //    }
    //
    //    writer.Commit();
    //    
    //}

}

