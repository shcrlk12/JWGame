using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public float maxWeight = 50f;
    public float currentWeight = 0f;

    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (currentWeight + item.weight > maxWeight)
        {
            Debug.Log("무게 초과!");
            return false;
        }

        items.Add(item);
        currentWeight += item.weight;
        return true;
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            currentWeight -= item.weight;
        }
    }
}