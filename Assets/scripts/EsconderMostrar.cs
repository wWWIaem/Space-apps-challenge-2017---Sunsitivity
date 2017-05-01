using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsconderMostrar : MonoBehaviour {
    public Text lblLat;
    public Text lblLong;
    public Text txtLong;
    public Text txtLat;
    public Text titulo;
    public Button siguiente;
    public Button playSim;
    public Button info;
    public Button simTierra;
    public Button uvindex;
    

     
	void Start () {
        siguiente.onClick.AddListener(presionarSiguiente);
        playSim.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        simTierra.gameObject.SetActive(false);
        uvindex.gameObject.SetActive(false);
    }

    public void presionarSiguiente()
    {
        Debug.Log("hola");
        
        lblLat.text = "";
        lblLong.text = "";
        txtLong.text = "";
        txtLat.text = "";
        titulo.text = "";
        siguiente.gameObject.SetActive(true);

        playSim.gameObject.SetActive(true);
        info.gameObject.SetActive(true);
        simTierra.gameObject.SetActive(true);
        uvindex.gameObject.SetActive(true);

    }
}
