using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject testoCoins;
    public GameObject position;
    public GameObject[] cars;
    private GameObject car;
   
    public void Start()
    {
        Classifica.Reset();
        GameManager.flag_started_coundown = false;
        GameManager.start = false;
        foreach (GameObject c  in cars)
        {
            c.GetComponent<Rigidbody>().useGravity = false;
            c.gameObject.transform.localScale = new Vector3(20, 20, 20);
            c.gameObject.transform.rotation =
                new Quaternion(-0.0252383146f, 0.983145773F, -0.0892141908F, -0.157569751F);
            c.gameObject.transform.position = new Vector3(-1291.09998f, -164.300003f, -512.099976f);
        }
        car = Instantiate(cars[2]);
        car.transform.SetParent(GameObject.FindWithTag("CanvasMods").transform,false);
        
        
        
       
        /*Da togliere*/
        if (!PlayerPrefs.HasKey("player"))
        {
            PlayerPrefs.SetString("player", "Vincenzo");
        }

        testoCoins.GetComponent<Text>().text = ""+PlayerPrefs.GetInt("coins");
        position.GetComponent<Text>().text = PlayerPrefs.GetString("posizione_gara");
    }
    
    void Update () {
        car.transform.Rotate(0, 30 * Time.deltaTime, 0);
        
    }

    public void startRacing()
    {
        //Questi due parametri da settare quando viene selezionata la macchina (da qui devono essere tolti)
        PlayerPrefs.SetInt("macchina_giocatore", 0);
        PlayerPrefs.SetInt("forza", 200);
        PlayerPrefs.SetInt("num_giri_race", 1);
        
        PlayerPrefs.SetString("modalita", "racing");
        
        //Questo da settare in partenza, nella scena iniziale (o se non settato deve essere player di default), da qui deve essere tolto
        PlayerPrefs.SetString("player_name", "Vicenzo");
       
        
        SceneManager.LoadScene("Game");
    }
    
    public void startTime()
    {
        //Questi due parametri da settare quando viene selezionata la macchina (da qui devono essere tolti)
        PlayerPrefs.SetInt("macchina_giocatore", 1);
        PlayerPrefs.SetInt("forza", 80);
        
        PlayerPrefs.SetString("modalita", "time");
        
        //Questo da settare in partenza, nella scena iniziale (o se non settato deve essere player di default), da qui deve essere tolto
        PlayerPrefs.SetString("player_name", "Vicenzo");
        
        
        SceneManager.LoadScene("Game");
    }
    
    /*Questa e la precedente sono solo di debug, alla fine diventano un unica funzione*/
    public void startMulti()
    {
        //Questi due parametri da settare quando viene selezionata la macchina (da qui devono essere tolti)
        PlayerPrefs.SetInt("macchina_giocatore", 1);
        PlayerPrefs.SetInt("forza", 200);
        PlayerPrefs.SetInt("num_giri_multi", 1);

        PlayerPrefs.SetString("modalita", "multiplayer");
        
        //Questo da settare in partenza, nella scena iniziale (o se non settato deve essere player di default), da qui deve essere tolto
        PlayerPrefs.SetString("player_name", "Vicenzo");
        
        SceneManager.LoadScene("Loading");
        
        
    }
    
    
    public void goMulti()
    {
        GameObject.FindWithTag("CanvasMods").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("CanvasRules").GetComponent<Canvas>().enabled = true;
        GameObject.FindWithTag("ResumeTimeAttack").SetActive(false);
        GameObject.FindWithTag("ResumeRacing").SetActive(false);
        
        
    }
    
    public void goRacing()
    {
        GameObject.FindWithTag("CanvasMods").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("CanvasRules").GetComponent<Canvas>().enabled = true;
        GameObject.FindWithTag("ResumeTimeAttack").SetActive(false);
        GameObject.FindWithTag("ResumeMultiplayer").SetActive(false);
        
    }
    
    public void goTimeAttack()
    {

        GameObject.FindWithTag("CanvasMods").GetComponent<Canvas>().enabled = false;
        GameObject.FindWithTag("CanvasRules").GetComponent<Canvas>().enabled = true;
        GameObject.FindWithTag("ResumeRacing").SetActive(false);
        GameObject.FindWithTag("ResumeMultiplayer").SetActive(false);
        
        
    }
}
