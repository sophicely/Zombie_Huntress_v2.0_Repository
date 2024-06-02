using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject itemSlotPrefab;

    private void Start()
    {
        InventorySystem.Instance.onInventoryChangedEventCallback += OnUpdateInventory;
        DrawInventory();
    }

    public void OnUpdateInventory()
    {
        // Limpiar todos los hijos del objeto transform antes de redibujar el inventario
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.Instance.inventory)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);
        ItemSlot slot = obj.GetComponent<ItemSlot>();
        slot.Set(item);
    }
}