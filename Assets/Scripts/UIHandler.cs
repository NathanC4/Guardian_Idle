using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject invPanel;
    public GameObject equipPanel;

    private void Start()
    {
        invPanel.SetActive(false);
        equipPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventoryWindow();
        }

        if (Input.GetButtonDown("EquipPanel"))
        {
            ToggleEquipWindow();
        }
    }

    public void ToggleInventoryWindow()
    {
        invPanel.SetActive(!invPanel.activeSelf);
    }

    public void ToggleEquipWindow()
    {
        equipPanel.SetActive(!equipPanel.activeSelf);
    }
}
