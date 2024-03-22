using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource hookGoldFx , hookStoneFx , playerLaughFx , pullSoundFx , ropeStrechFx , timeRunningOutFx , gameOverFx;

    void Awake()
    {
        MakeInstance();
    }
    
    void MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    public void HookGoldSound(){
        hookGoldFx.Play();
    }

    public void HookStoneSound(){
        hookStoneFx.Play();
    }

    public void PlayerLaughSound(){
        playerLaughFx.Play();
    }

    public void RopeStrechSound(bool PlayFx){
        if(PlayFx){
            if(!ropeStrechFx.isPlaying){
                ropeStrechFx.Play();
            }
        }
        else{
            if(!ropeStrechFx.isPlaying){
                ropeStrechFx.Stop();
            }
        }
    }

    public void PullSound(bool PlayFx){
        if(PlayFx){
            if(!pullSoundFx.isPlaying){
                pullSoundFx.Play();
            }
        }
        else{
            if(!pullSoundFx.isPlaying){
                pullSoundFx.Stop();
            }
        }
    }

    public void TimeRunningOutSound(bool PlayFx){
        if(PlayFx){
            if(!timeRunningOutFx.isPlaying){
                timeRunningOutFx.Play();
            }
        }
        else{
            if(!timeRunningOutFx.isPlaying){
                timeRunningOutFx.Stop();
            }
        }
    }

    public void GameOverSound(){
        gameOverFx.Play();
    }
}
