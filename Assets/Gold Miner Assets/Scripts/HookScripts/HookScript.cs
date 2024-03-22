using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    [HideInInspector] public bool itemAttached;
    private HookMovement hookMovement;
    private PlayerAnimations playerAnimations;
    void Awake()
    {
        hookMovement = GetComponentInParent<HookMovement>();    
        playerAnimations = GetComponentInParent<PlayerAnimations>();    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Item" && !itemAttached)
        {
            itemAttached = true;
            other.transform.parent = itemHolder;
            other.transform.position = itemHolder.position;
            hookMovement.HookAttachedItem();
            playerAnimations.PullingAnimations();
            hookMovement.moveSpeed = other.GetComponent<ItemScript>().hookSpeed;
            if(other.tag == "SmallGold" || other.tag == "MiddleGold" || other.tag == "LargeGold"){
                SoundManager.instance.HookGoldSound();
            }
            else{
                SoundManager.instance.HookStoneSound();
            }
            SoundManager.instance.PullSound(true);
        }
        
        if(other.tag == "DeliverItem"){
            if(itemAttached){
                itemAttached = false;
                Transform obj = itemHolder.GetChild(0);
                if(obj.tag == "SmallGold" || obj.tag == "MiddleGold" || obj.tag == "LargeGold"){
                    playerAnimations.LaughAnimations();
                }
                obj.parent = null;
                obj.gameObject.SetActive(false);
                playerAnimations.IdleAnimations();
                SoundManager.instance.PullSound(false);
            }
        }
    }
}
