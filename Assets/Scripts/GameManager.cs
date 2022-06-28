using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Listeler icin
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public Soru[] sorular; 
    private static List<Soru> cevaplanmamisSorular;

    private Soru gecerliSoru;

    [SerializeField]
    private Text soruText;

    [SerializeField]
    private Text dogruCevapText, yanlisCevapText;

    [SerializeField]
    private GameObject dogruButon, yanlisButon;

    int dogruAdet, yanlisAdet;

    int toplamPuan;

    [SerializeField]
    private GameObject sonucPaneli;

    SonucManager sonucManager;

    void Start()
    {
        if (cevaplanmamisSorular==null || cevaplanmamisSorular.Count==0)
        {
            cevaplanmamisSorular = sorular.ToList<Soru>();
        }

        dogruAdet = 0;
        yanlisAdet = 0;
        toplamPuan = 0;

        RastgeleSoruSec();
    }
    void RastgeleSoruSec()
    {
        yanlisButon.GetComponent<RectTransform>().DOLocalMoveX(320f, 0.2f);
        dogruButon.GetComponent<RectTransform>().DOLocalMoveX(-320f, 0.2f);

        int randomSoruIndex = Random.Range(0, cevaplanmamisSorular.Count);
        gecerliSoru = cevaplanmamisSorular[randomSoruIndex];

        soruText.text = gecerliSoru.soru;

        if (gecerliSoru.dogrumu)
        {
            dogruCevapText.text = "DOÐRU CEVAPLADINIZ";
            yanlisCevapText.text = "YANLIÞ CEVAPLADINIZ";

        }
        else 
        {
            dogruCevapText.text = "YANLIÞ CEVAPLADINIZ";
            yanlisCevapText.text = "DOÐRU CEVAPLADINIZ";
        }
    }

    IEnumerator SorularArasiBekleRoutine()
    {
        cevaplanmamisSorular.Remove(gecerliSoru);

        yield return new WaitForSeconds(0.5f);

        if (cevaplanmamisSorular.Count<=0)
        {
            sonucPaneli.SetActive(true);

            sonucManager = Object.FindObjectOfType<SonucManager>();
            sonucManager.SonuclariYazdir(dogruAdet,yanlisAdet,toplamPuan);
        }
        else
        {
            RastgeleSoruSec();
        }
    }
    public void DogruButonaBasildi()
    {
        if (gecerliSoru.dogrumu) //true ise default hali
        {
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }

        yanlisButon.GetComponent<RectTransform>().DOLocalMoveX(1000f,0.2f);

        StartCoroutine(SorularArasiBekleRoutine());
    }
    public void YanlisButonaBasildi()
    {
        if (!gecerliSoru.dogrumu) //! ile tersini kastederiz.
        {
            dogruAdet++;
            toplamPuan += 100;
        }
        else
        {
            yanlisAdet++;
        }

        dogruButon.GetComponent<RectTransform>().DOLocalMoveX(-1000f, 0.2f);

        StartCoroutine(SorularArasiBekleRoutine());
    }
   
}
