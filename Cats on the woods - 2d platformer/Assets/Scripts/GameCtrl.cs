using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour{
    public static GameCtrl instance;
    public float restartDelay;
    public GameData data;
    public Text textcoincount;
    public Text textScore;
    public int coinvalue;

    private string datafilepath;
    private BinaryFormatter bf;

    private void Awake(){
        if (instance == null){
            instance = this;
        }

        bf = new BinaryFormatter();
        datafilepath = Application.persistentDataPath + "/game.dat";

        Debug.Log(datafilepath);
    }

    // Use this for initialization
    void Start(){
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Escape)){
            resetData();
        }
    }

    private void OnEnable(){
        Debug.Log("data loaded");
        loadData();
    }

    private void OnDisable(){
        Debug.Log("data saved");
        savedata();
    }

    public void savedata(){
        FileStream fs = new FileStream(datafilepath,FileMode.Create);
        bf.Serialize(fs,data);
        fs.Close();
    }

    public void loadData(){
        if (File.Exists(datafilepath)){
            FileStream fs = new FileStream(datafilepath,FileMode.Open);
            data = (GameData) bf.Deserialize(fs);
           // Debug.Log("numbers of coins = "+data.coinCount);
            textcoincount.text = " x " + data.coinCount;
            textScore.text = "Score: " + data.score;
            fs.Close();
        }
    }

    void resetData(){
        FileStream fs = new FileStream(datafilepath,FileMode.Create);
        data.coinCount = 0;
        textcoincount.text = " x 0";
        data.score = 0;
        textScore.text = "Score: " + data.score;
        bf.Serialize(fs,data);
        fs.Close();
        Debug.Log("data reset");
    }

    public void playerDied(GameObject player){
        player.SetActive(false);


        Invoke("ReastarLevel", restartDelay);
    }

    void ReastarLevel(){
        SceneManager.LoadScene("Gameplay");
    }

    public void playerDrowned(GameObject player){
        Invoke("ReastarLevel", restartDelay);
    }

    public void updatecoincount(){
        data.coinCount += 1;
        textcoincount.text = " x " + data.coinCount;
        updatescore(coinvalue);
    }

    public void updatescore(int value){
        data.score += value;
        textScore.text = "Score: " + data.score;
    }
}