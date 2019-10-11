using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour{
    public Texture2D map;

    public ColoredPrefabs[] colormapings;

    // Use this for initialization
    void Start(){
        GenerateLevel();
    }

    void GenerateLevel(){
        for (int x = 0; x < map.width; x++){
            for (int y = 0; y < map.height; y++){
                Generatetile(x, y);
            }
        }
    }

    void Generatetile(int x, int y){
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0){
            return;
        }

        foreach (ColoredPrefabs colormaping in colormapings){
            if (colormaping.color.Equals(pixelColor)){
                Vector2 pos = new Vector2(x, y);
                Instantiate(colormaping.prefab, pos, Quaternion.identity);
            }
        }
    }
}