using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtrl : MonoBehaviour{
    public static SFXCtrl instance;

    public SFX sfx;

    // Use this for initialization
    private void Awake(){
        if (instance == null){
            instance = this;
        }
    }


    public void showCoinSpark(Vector3 pos){
        Instantiate(sfx.sfx_coin_pickup, pos, Quaternion.identity);
    }
    public void showBulletSpark(Vector3 pos){
        Instantiate(sfx.sfx_bullet_pickup, pos, Quaternion.identity);
    }
    public void showlandingdust(Vector3 pos){
        Instantiate(sfx.sfx_playerlands, pos, Quaternion.identity);
    }
    
    public void showSplash(Vector3 pos){
        Instantiate(sfx.sfx_splash, pos, Quaternion.identity);
    }
    
    public void shandleboxbraking(Vector3 pos){
        Vector3 pos1 = pos;
        pos1.x -= 0.3f;
        Vector3 pos2 = pos;
        pos1.x += 0.3f;
        Vector3 pos3 = pos;
        pos1.x -= 0.3f;
        pos1.y -= 0.3f;
        Vector3 pos4 = pos;
        pos1.x += 0.3f;
        pos1.y += 0.3f;

        Instantiate(sfx.sfx_fragment_1, pos1, Quaternion.identity);
        Instantiate(sfx.sfx_fragment_2, pos2, Quaternion.identity);
        Instantiate(sfx.sfx_fragment_2, pos3, Quaternion.identity);
        Instantiate(sfx.sfx_fragment_1, pos4, Quaternion.identity);
        

    }
}