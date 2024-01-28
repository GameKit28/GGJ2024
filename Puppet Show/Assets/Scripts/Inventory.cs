using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<IBodyParts.BodyPart, PuppetComponents> itemByBodyParts = new Dictionary<IBodyParts.BodyPart, PuppetComponents>();

    public static Inventory Instance;
    private void Start()
    {
        GameObject.DontDestroyOnLoad(this);
        Instance = this;
    }
    public void AddPuppetComponent(PuppetComponents item)
    {
        itemByBodyParts[item.bodyPart] = item;
        Debug.Log(itemByBodyParts.Count);
    }
    public void RemovePuppetComponent()
    {

    }
}
