using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<IBodyParts.InventoryBodyParts, PuppetComponents> itemByBodyParts = new Dictionary<IBodyParts.InventoryBodyParts, PuppetComponents>();

    public static Inventory Instance;
    private void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        Instance = this;
    }
    public void AddPuppetComponent(PuppetComponents item)
    {
        
        itemByBodyParts[limbsideFormatting(item.bodyPart)] = item;
        Debug.Log("item added");
        Debug.Log(itemByBodyParts.Count);
    }
    public void RemovePuppetComponent()
    {

    }
    private IBodyParts.InventoryBodyParts limbsideFormatting(IBodyParts.BodyPart part)
    {
        switch (part)
        {
            case IBodyParts.BodyPart.Hand:
                if(itemByBodyParts.ContainsKey(IBodyParts.InventoryBodyParts.LeftHand))
                {
                    return IBodyParts.InventoryBodyParts.RightHand;
                }
                return IBodyParts.InventoryBodyParts.LeftHand;
            case IBodyParts.BodyPart.Shoulder:
                if (itemByBodyParts.ContainsKey(IBodyParts.InventoryBodyParts.LeftShoulder))
                {
                    return IBodyParts.InventoryBodyParts.RightShoulder;
                }
                return IBodyParts.InventoryBodyParts.LeftShoulder;
            case IBodyParts.BodyPart.Forearm:
                if (itemByBodyParts.ContainsKey(IBodyParts.InventoryBodyParts.LeftForearm))
                {
                    return IBodyParts.InventoryBodyParts.RightForearm;
                }
                return IBodyParts.InventoryBodyParts.LeftForearm;
            default:
                return IBodyParts.InventoryBodyParts.Head;
        }
    }
}
