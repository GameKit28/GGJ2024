using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemRandomizer : MonoBehaviour, IPointerEnterHandler
{
    public GameObject itemPrefab;

    public List<ItemAsset> possibleItems;
    //updating UI text variables
    private GameObject nameUI;
    private GameObject descriptionUI;
    private TMPro.TextMeshProUGUI nameTextComponent;
    private TMPro.TextMeshProUGUI descriptionTextComponent;
    private string nameValue;
    private string descriptionValue;
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
        //code for finding the text reference
        nameValue = chosenItem.puppetComponentName;
        descriptionValue = chosenItem.puppetComponentDescription;
        nameUI = GameObject.FindWithTag("name");
        descriptionUI = GameObject.FindWithTag("description");
        nameTextComponent = nameUI.GetComponent<TMPro.TextMeshProUGUI>();
        descriptionTextComponent = descriptionUI.GetComponent<TMPro.TextMeshProUGUI>();

    }

    private T GetRandom<T>(List<T> options){
        
        if(options.Count > 0){
            int index = Random.Range(0, options.Count);
            return options[index];
        }else{
            return default(T);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        nameTextComponent.text = nameValue;
        descriptionTextComponent.text = descriptionValue;
    }
}
