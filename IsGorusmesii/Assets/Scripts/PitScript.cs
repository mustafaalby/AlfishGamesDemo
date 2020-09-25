using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitScript : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] playerInput player;
    [SerializeField] Image partImage;
    [SerializeField] GameObject particle;
    private forceArea forceArea;
    private Manage manage;
    private int objectCounter=0;
    [SerializeField] Animator animator;
    public int neededObjectsToPassLevel=0;
    private float gateTimer;
    private bool timerBool = false;
    private float playerTimer;
    private bool playerTimerBool = false;
    
    private void Awake()
    {
        manage = GameObject.Find("Manager").GetComponent<Manage>();
        forceArea = GameObject.Find("ForceArea").GetComponent<forceArea>();
    }
    void Start()
    {
        
        text.text = objectCounter.ToString() + "/" + neededObjectsToPassLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerBool)
        {
            gateTimer += Time.deltaTime;
            
            if (gateTimer > 1f)
            {   timer();
                timerBool = false;
                gateTimer = 0;
            }
        }
        if (playerTimerBool)
        {
            playerTimer += Time.deltaTime;
            if (playerTimer > 2)
            {
                restoreVelocity();
                playerTimerBool = false;
                playerTimer = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            player.SetVelocity(0);
            forceArea.ApplyForce();
            timerBool = true;
            /*Player Checkpointe geldiğinde, Player Velocity değeri sıfırlanır. Player içerisindeki toplanabilir nesnelere
             Force uygulanarak checkpoint içerisinde düşürülür.*/
        }
        else
        {
            objectCounter++;
            text.text = objectCounter.ToString() + "/" + neededObjectsToPassLevel.ToString();
            timerBool = true;    
            /*
                Eğer checkpoint noktasındaki triggerı tetikleyen player değilde toplanabilir nesne ise, bu nesnelerin sayısı toplanır
                checkpoint üzerindeki text güncellenir. Animasyonları tetikleyecek ve toplanabilen nesnelerin sayısının kontrolünü
                yapacak fonksiyonu çağıracak timer çalıştırılır.
             */
        }       
    }
    void timer()
    {
        if (objectCounter >= neededObjectsToPassLevel)
        {
            animator.SetBool("isGateClose", true);
            playerTimerBool = true;
            partImage.color = new Color(1, 0.4196079f, 0,1);
            Instantiate(particle,new  Vector3 (transform.position.x,transform.position.y,transform.position.z),Quaternion.Euler(-90,0,0),transform);
            /*
         Eğer checkpointte yeteri kadar nesne toplanmışsa gate animasyonunu çalıştır. Player velocity değerini restore edecek 
         fonksiyonu çağıracak timer çalışıtırılır. Progres bardaki atanan image rengini değiştir.
         */
        }
        else
        {
            manage.GameOver();
        }
        
    }
    void restoreVelocity()
    {

        player.SetVelocity(2);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetBool("isGateClose", false);
        }
        /*Player checkpointten çıktıktan sonra kapının tekrar kapanmasını sağlayan animasyon çalıştırılır*/
    }

}
