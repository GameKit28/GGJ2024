using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class NewItem : MonoBehaviour, IBodyParts, IPointerEnterHandler
{
    public Sprite sprite;
    public GameObject itemPrefab;
    //updating UI text variables
    private GameObject nameUI;
    private GameObject descriptionUI;
    private TMPro.TextMeshProUGUI nameTextComponent;
    private TMPro.TextMeshProUGUI descriptionTextComponent;
    private string nameValue;
    private string descriptionValue;
    public List<Item> myItems;
    private void Start()
    {
        int randomIndex = Random.Range(0, myItems.Count);
        GameObject myNewItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        int randomMovement = Random.Range(0, 5);
        int randomDamage = Random.Range(0,100)/20;
        int movementStrength = Random.Range(0, 100) / 20;
        nameValue = myItems[randomIndex].puppetComponentName;
        descriptionValue = myItems[randomIndex].puppetComponentDescription;
        myNewItem.transform.SetParent(transform.parent);
        myNewItem.GetComponent<PuppetComponents>().SetProperties(
            myItems[randomIndex].puppetComponentName,
            myItems[randomIndex].id,
            myItems[randomIndex].sprite,
            myItems[randomIndex].bodyPart,
            myItems[randomIndex].puppetComponentDescription,
            randomMovement,
            movementStrength, 
            randomDamage
        ); ;

        //code for finding the text reference
        nameUI = GameObject.FindWithTag("name");
        Debug.Log(nameUI);
        descriptionUI = GameObject.FindWithTag("description");
        nameTextComponent = nameUI.GetComponent<TMPro.TextMeshProUGUI>();
        
        Debug.Log(nameTextComponent);
        
        descriptionTextComponent = descriptionUI.GetComponent<TMPro.TextMeshProUGUI>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("is hover");
        nameTextComponent.text = nameValue;
        descriptionTextComponent.text = descriptionValue;
    }
}
