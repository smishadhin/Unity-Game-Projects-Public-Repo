using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpwaner : MonoBehaviour{
    public GameObject platform;
    public GameObject diamonds;

    private Vector3 lastpos;
    private float size;
    public bool gameOver;

    // Use this for initialization
    void Start(){
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 5; i++){
            SpwanPlatforms();
        }
        
       
    }

    public void spwanplatforms(){
        InvokeRepeating("SpwanPlatforms",1f,0.2f);
    }
    // Update is called once per frame
    void Update(){
        if (GameManager.instance.gameOver == true){
            CancelInvoke("SpwanPlatforms");
        }
    }

    void SpwanPlatforms(){
        int rand = Random.Range(0, 6);
        if (rand < 3){
            SpwanX();
        } else if(rand >=3){
            SpwanZ();
        }
    }
    
    void SpwanX(){
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        
        int rand = Random.Range(0, 3);
        if (rand <1){
            Instantiate(diamonds, new Vector3(pos.x,pos.y +1 ,pos.z), diamonds.transform.rotation);
        }
    }

    void SpwanZ(){
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        
        int rand = Random.Range(0, 3);
        if (rand <1){
            Instantiate(diamonds,  new Vector3(pos.x,pos.y +1 ,pos.z), diamonds.transform.rotation);
        }
    }

    
}