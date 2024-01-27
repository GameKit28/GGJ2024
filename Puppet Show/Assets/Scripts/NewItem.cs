using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItem : MonoBehaviour, IBodyParts
{
    public Sprite sprite;
    public GameObject itemPrefab;

    private void Start()
    {
        GameObject myNewItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        myNewItem.transform.SetParent(transform.parent);
        myNewItem.GetComponent<PuppetComponents>().SetProperties("sword", 1, sprite, IBodyParts.BodyPart.rightHand); ;
    }
}
