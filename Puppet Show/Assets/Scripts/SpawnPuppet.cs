using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPuppet : MonoBehaviour
{
    [SerializeField] private GameObject emptyPuppetPrefab;
    /*Head,
    LeftShoulder,
    RightShoulder,
    LeftHand,
    RightHand,
    LeftForearm,
    RightForearm
*/
    public void ConstructPuppet(Dictionary<IBodyParts.InventoryBodyParts, PuppetComponents> itemByBodyParts)
    {
        //Head
        PuppetComponents headComponent = itemByBodyParts[IBodyParts.InventoryBodyParts.Head];
        GameObject headPos = emptyPuppetPrefab.transform.GetChild(2).gameObject;
        
        RagdollPartBehaviour headBehavior = headPos.GetComponent<RagdollPartBehaviour>();
        headBehavior.movementStrategy = headComponent.movementStrategy;
        headBehavior.triggerStrategy = headComponent.triggerStrategy;
        headBehavior.effectStrategy = headComponent.effectStrategy;

        GameObject head = headPos.transform.GetChild(0).gameObject;
        SpriteRenderer headSR = head.GetComponent<SpriteRenderer>();
        headSR.sprite = headComponent.sprite;

        GameObject leftShoulder = emptyPuppetPrefab.transform.GetChild(3).gameObject;

        PuppetComponents leftForearmComponent = itemByBodyParts[IBodyParts.InventoryBodyParts.LeftForearm];
        GameObject leftForearmPos = leftShoulder.transform.GetChild(0).gameObject;

        RagdollPartBehaviour leftForearmBehavior = leftForearmPos.GetComponent<RagdollPartBehaviour>();
        leftForearmBehavior.movementStrategy = leftForearmComponent.movementStrategy;
        leftForearmBehavior.triggerStrategy = leftForearmComponent.triggerStrategy;
        leftForearmBehavior.effectStrategy = leftForearmComponent.effectStrategy;

        SpriteRenderer leftForearmRender = leftForearmPos.GetComponent<SpriteRenderer>();
        leftForearmRender.sprite = leftForearmComponent.sprite;

        PuppetComponents leftHandComponent = itemByBodyParts[IBodyParts.InventoryBodyParts.LeftHand];
        GameObject leftHandPos = leftShoulder.transform.GetChild(1).gameObject;

        RagdollPartBehaviour leftHandBehavior = leftHandPos.GetComponent<RagdollPartBehaviour>();
        leftHandBehavior.movementStrategy = leftHandComponent.movementStrategy;
        leftHandBehavior.triggerStrategy = leftHandComponent.triggerStrategy;
        leftHandBehavior.effectStrategy = leftHandComponent.effectStrategy;

        SpriteRenderer leftHandRender = leftHandPos.GetComponent<SpriteRenderer>();
        leftHandRender.sprite = leftHandComponent.sprite;

        GameObject rightShoulder = emptyPuppetPrefab.transform.GetChild(4).gameObject;

        PuppetComponents rightForearmComponent = itemByBodyParts[IBodyParts.InventoryBodyParts.LeftForearm];
        GameObject rightForearmPos = rightShoulder.transform.GetChild(0).gameObject;

        RagdollPartBehaviour rightForearmBehavior = rightForearmPos.GetComponent<RagdollPartBehaviour>();
        rightForearmBehavior.movementStrategy = rightForearmComponent.movementStrategy;
        rightForearmBehavior.triggerStrategy = rightForearmComponent.triggerStrategy;
        rightForearmBehavior.effectStrategy = rightForearmComponent.effectStrategy;

        SpriteRenderer rightForearmRender = rightForearmPos.GetComponent<SpriteRenderer>();
        rightForearmRender.sprite = rightForearmComponent.sprite;

        PuppetComponents rightHandComponent = itemByBodyParts[IBodyParts.InventoryBodyParts.LeftHand];
        GameObject rightHandPos = rightShoulder.transform.GetChild(1).gameObject;

        RagdollPartBehaviour rightHandBehavior = rightHandPos.GetComponent<RagdollPartBehaviour>();
        rightHandBehavior.movementStrategy = rightHandComponent.movementStrategy;
        rightHandBehavior.triggerStrategy = rightHandComponent.triggerStrategy;
        rightHandBehavior.effectStrategy = rightHandComponent.effectStrategy;

        SpriteRenderer rightHandRender = rightHandPos.GetComponent<SpriteRenderer>();
        rightHandRender.sprite = rightHandComponent.sprite;
    }

}
