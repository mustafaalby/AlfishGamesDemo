using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class playerInput : MonoBehaviour
{
    private float velocity = 0;
    
    Rigidbody rigid;
    Vector3 firstMousePosition = new Vector3();
    Vector3 updatedMousePosition = new Vector3();
    Vector3 difference = new Vector3();
    Touch touch;
    float camZPosDiff;
    private Camera cam;
    Animator animator;
    void Start()
    {
        cam = Camera.main;
        camZPosDiff = cam.transform.position.z - transform.position.z;
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                SetVelocity(2);
               // transform.position = new Vector3(transform.position.x + touch.deltaPosition.x, transform.position.y, transform.position.z);
                rigid.MovePosition(new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x, -1.97f, 1.97f), transform.position.y, transform.position.z));
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            SetVelocity(2);
            firstMousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, 10f));
            
        }
        if (Input.GetMouseButton(0))
        {
            updatedMousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, transform.position.y, 10f));            
            difference = updatedMousePosition - firstMousePosition;            
            firstMousePosition = updatedMousePosition;
            //transform.position = new Vector3(transform.position.x + difference.x, transform.position.y, transform.position.z);            
            rigid.MovePosition(new Vector3(Mathf.Clamp(transform.position.x + difference.x, -1.97f,1.97f ), transform.position.y, transform.position.z));
            
        }
        rigid.velocity = new Vector3(0, 0, getVelocity());
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z + camZPosDiff);
    }
    /*
     Mobil için input yazsam da Type-C kablomda problem yaşadığım için test etme imkanı bulamadım. Mantığıma göre çalışması gereken
     bir mobil input kodu da ekledim.
     Öte yandan Fare ile kontrol edebildiğimiz, bilgisayardan test edebilmek adına bir input daha oluşturdum.
     Update içerisinde fare özelinde input için bakacak olursak ilk tıklama ile pozisyon belirleyip, basılı tutarken farenin son 
     pozisyonuna göre nesnemizi hareket ettirdim.
     NEDENINI ANLAYAMADIGIM BIR SEBEPTEN DOLAYI NESNEYI HIZLICA OYNATTIGIMDA KONTROL ETTIGIMIZ NESNE ICERISINDE TOPLADIGIMIZ NESNELER
     COLLIDER ICERISINDEN GECIYOR VE NESLELERI KAYBEDIYORUM. ÇOZUMU HALA ARASTIRIYORUM. LUTFEN NESNEYI HIZLI HAREKET ETTIRMEYIN.
         */
    public float getVelocity()
    {
        return velocity;             
        //Kontrol ettiğimiz nesnenin değerini döndürüyoruz
    }
    public void SetVelocity(float temp)
    {
        velocity = temp;
        //kontrol ettiğimiz nesnenin hızını değiştiriyoruz
    }
    public void GoNextLevel()
    {
        velocity = 0;
        animator.enabled = true;
        animator.SetBool("trig", true);
        /*
         Bir level tamamlandığında sonraki levele geçişte kullanılacak animasyonu açıp oynatmak için kullanılan fonksiyon.
         velocityi ve animatorü beraber çalıştırmaya kalktığımda obje kitlendi. Onun yerine o anda velocity ve animatoru
         sırayla kapatıp açma yoluna gittim.
         */
    }
    public void stopAnimation()
    {
        animator.SetBool("trig", false);
        animator.enabled = false;
        /*
         * Yeni seviyeye geçişin ardından kontrol ettiğimiz nesnenin animasyonu durduktan sonra animatorü kapatıyoruz.
         * Yeni seviyede oynamaya hazır duruma geliyoruz.
         * Bu fonksiyon animation içerisindeki event tarafından çağırılıyor.
         */
    }
}
