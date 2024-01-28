using UnityEngine;
using TMPro;

public class DescriptionText : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public void updateItemName(string newText)
    {
        itemName.text = newText;
    }
    public void updateItemDescription(string newText)
    {
        itemDescription.text = newText;
    }
    
}
