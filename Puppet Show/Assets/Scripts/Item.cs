using UnityEngine;
[System.Serializable]
public class Item : IBodyParts
{

    public string puppetComponentName;
    public int id;
    public Sprite sprite;
    public IBodyParts.BodyPart bodyPart;
    public string puppetComponentDescription;

    public void SetProperties(string PuppetComponentName, int id, Sprite sprite, IBodyParts.BodyPart bodyPart, string puppetComponentDescription)
    {
        this.puppetComponentName = PuppetComponentName;
        this.puppetComponentDescription = puppetComponentDescription;
        this.id = id;
        this.sprite = sprite;
        this.bodyPart = bodyPart;

    }
}