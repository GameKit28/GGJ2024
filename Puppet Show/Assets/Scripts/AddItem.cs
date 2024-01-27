using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddItem : MonoBehaviour {
    public TMP_Text descriptionText;
    public void OnHover()
    {
        descriptionText.text = "this is a sword";
        Debug.Log("it's working");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
