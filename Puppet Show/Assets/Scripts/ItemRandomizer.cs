using System.Collections.Generic;
using UnityEngine;

public class ItemRandomizer : MonoBehaviour
{
    public GameObject itemPrefab;

    public List<ItemAsset> possibleItems;

    private void Start()
    {
        int randomIndex = Random.Range(0, possibleItems.Count);
        ItemAsset chosenItem = possibleItems[randomIndex];

        GameObject myNewItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        PuppetComponents componentInstance = myNewItem.GetComponent<PuppetComponents>();
        
        componentInstance.puppetComponentName = chosenItem.puppetComponentName;
        componentInstance.puppetComponentDescription = chosenItem.puppetComponentDescription;
        componentInstance.bodyPart = chosenItem.bodyPart;
        componentInstance.sprite = chosenItem.sprite;
        componentInstance.movementStrategy = GetRandom(chosenItem.validMovementBehaviours);
        componentInstance.triggerStrategy = GetRandom(chosenItem.validTriggerBehaviours);
        componentInstance.effectStrategy = GetRandom(chosenItem.validEffectBehaviours);
        componentInstance.constantModifiers = chosenItem.constantModifiers;
        componentInstance.percentageModifiers = chosenItem.percentageModifiers;
        
        myNewItem.transform.SetParent(transform.parent);
        componentInstance.ApplyPropertiesToUI(myNewItem);
    }

    private T GetRandom<T>(List<T> options){
        int index = Random.Range(0, options.Count);
        return options[index];
    }
}
