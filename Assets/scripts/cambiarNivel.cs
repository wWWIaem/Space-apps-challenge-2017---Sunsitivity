using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarNivel : MonoBehaviour {
    public void CambiarNivel()
    {
       SceneManager.LoadScene("info");
    }

    public void cambiarSimPlaneta()
    {
        SceneManager.LoadScene("simPlaneta");
    }

    public void cambiarSimRecorrido()
    {
        SceneManager.LoadScene("simRecorrido");
    }

    public void cambiarGame()
    {
        SceneManager.LoadScene("game");
    }
	
}
