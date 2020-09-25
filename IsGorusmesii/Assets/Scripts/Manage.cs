using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manage : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] PitScript Pit1;
    [SerializeField] PitScript Pit2;
    [SerializeField] PitScript Pit3;
    [SerializeField] TMPro.TextMeshProUGUI prevLevelText;
    [SerializeField] TMPro.TextMeshProUGUI nextLevelText;
    [SerializeField] Image partOneImage;
    [SerializeField] Image partTwoImage;
    [SerializeField] Image partThreeImage;
    [SerializeField] GameObject CollectibleOBjectParent;
    playerInput playerInp;    
    RoadScript roadScript;
    
    int level = 0;
    private void Awake()
    {
        roadScript = GameObject.Find("RoadParent").GetComponent<RoadScript>();
        playerInp = Player.GetComponent<playerInput>();
    }
    void Start()
    {
        GameStarts();

        Debug.Log(PlayerPrefs.GetInt("Level"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GameStarts()
    {
        level = PlayerPrefs.GetInt("Level");

        prevLevelText.text = (level+1).ToString();
        nextLevelText.text = (level + 2).ToString();

        roadScript.setLevel(level);
        roadScript.PlaceObjects();

        partOneImage.color = Color.white;
        partTwoImage.color = Color.white;
        partThreeImage.color = Color.white;
        
    }/*
        Level Başladığında Level kayıt bilgisi alınıp, progress bardaki önceki ve sonraki level textleri güncellenir.
        oluşturulacak toplanabilir nesneler için Level bilgisi yollanır ve nesneleri oluşturacak fonksiyon çağırılır.
        progress bardaki progress image leri beyaza çevrilir. Bu Imageler yerine Sprite Mask ile tek bir Image de kullanılabilirdi
        ancak bu yöntem o anda daha pratik geldi.
     */
    public void GameOver()
    {

        SceneManager.LoadScene(0);
    }
    public void LevelCompleted()
    {
        
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level")+1);
        
        
        ClearCollectibleObjects();
        prevLevelText.text = (PlayerPrefs.GetInt("Level") + 1).ToString();
        nextLevelText.text = (PlayerPrefs.GetInt("Level") + 2).ToString();

        roadScript.setLevel(PlayerPrefs.GetInt("Level"));
        roadScript.PlaceObjects();

        partOneImage.color = Color.white;
        partTwoImage.color = Color.white;
        partThreeImage.color = Color.white;


        Player.transform.position = new Vector3(transform.position.x, transform.position.y, -24.5f);
        playerInp.GoNextLevel();
        /*
         FinishLine trigger tarafından çağırılan fonksiyon, oynanacak level kaydını günceller, progress bardaki
         level text bilgisini yeniler ve yeni oluşturulacak nesneler için level bilgisini RoadScripte yollar.
         Progress bardaki image ler tekrar beyaza çevrilir.
         Son olarak ise sıradaki levele geçmek için oluşturulan animasyonu oynatacak fonksiyon çalıştırılır.
         */
        

    }
    
     void ClearCollectibleObjects ()
    {
        foreach (Transform item in CollectibleOBjectParent.transform)
        {
            Destroy(item.gameObject);
        }
        /*
         Level son bulduğunda, önceki levelde oluşturulmuş toplayabildiğimiz nesneleri siliyoruz.
         */
    }
}
