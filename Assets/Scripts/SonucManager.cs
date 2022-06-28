using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruText,yanlisText,puanText;

    [SerializeField]
    private GameObject birinciYildiz, ikinciYildiz, ucuncuYildiz;

    public void SonuclariYazdir(int dogruAdet,int yanlisAdet,int puan)
    {
        dogruText.text = dogruAdet.ToString();
        yanlisText.text = yanlisAdet.ToString();
        puanText.text = puan.ToString();

        birinciYildiz.SetActive(false);
        ikinciYildiz.SetActive(false);
        ucuncuYildiz.SetActive(false);

        if (dogruAdet>=2 && dogruAdet<4)
        {
            birinciYildiz.SetActive(true);
        }
        else if (dogruAdet>=4 && dogruAdet<6)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
        }
        else if (dogruAdet>=6)
        {
            birinciYildiz.SetActive(true);
            ikinciYildiz.SetActive(true);
            ucuncuYildiz.SetActive(true);
        }
        else
        {
            birinciYildiz.SetActive(false);
            ikinciYildiz.SetActive(false);
            ucuncuYildiz.SetActive(false);
        }
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void CikisYap()
    {
        Application.Quit();      
    }
}
