using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItem : MonoBehaviour, IBodyParts
{
    public Sprite sprite;
    public GameObject itemPrefab;

  
    public List<Item> myItems;
    private void Start()
    {
        int randomIndex = Random.Range(0, myItems.Count);
        GameObject myNewItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        myNewItem.transform.SetParent(transform.parent);
        myNewItem.GetComponent<PuppetComponents>().SetProperties(
            myItems[randomIndex].puppetComponentName,
            myItems[randomIndex].id,
            myItems[randomIndex].sprite,
            myItems[randomIndex].bodyPart,
            myItems[randomIndex].puppetComponentDescription
        ); ;
    }
}
