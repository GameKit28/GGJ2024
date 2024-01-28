using UnityEngine;
[System.Serializable]
public class Item : IBodyParts
{

    public string puppetComponentName;
    public int id;
    public Sprite sprite;
    public IBodyParts.BodyPart bodyPart;
    public int movementType
    public int movementStrength
    public int damage
    public string puppetComponentDescription;


    public void SetProperties(string PuppetComponentName, int id, Sprite sprite, IBodyParts.BodyPart bodyPart, string puppetComponentDescription, int movementType, int movementStrength, int damage)
    {
        this.puppetComponentName = PuppetComponentName;
        this.puppetComponentDescription = puppetComponentDescription;
        this.id = id;
        this.sprite = sprite;
        this.bodyPart = bodyPart;
        this.movementType = movementType;
        this.movementStrength = movementStrength;
        this.damage = damage;
        


    }
}