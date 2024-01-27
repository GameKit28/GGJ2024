using UnityEngine;

public class PuppetComponents : MonoBehaviour, IBodyParts
{

    public string puppetComponentName;
    public int id;
    public Sprite sprite;
    public IBodyParts.BodyPart bodyPart;

    public void SetProperties(string PuppetComponentName, int id, Sprite sprite, IBodyParts.BodyPart bodyPart)
    {
        this.puppetComponentName = PuppetComponentName;
        this.id = id;
        this.sprite = sprite;
        this.bodyPart = bodyPart;

    }
}
