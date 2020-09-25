using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Level")]
public class LevelObject : ScriptableObject
{
    public GameObject levelObject;
    public List<Vector3> roadOneObjectPositions;
    public List<Vector3> roadTwoObjectPositions;
    public List<Vector3> roadThreeObjectPositions;
    public int neededObjectToPassLevelRoadOne;
    public int neededObjectToPassLevelRoadTwo;
    public int neededObjectToPassLevelRoadThree;

}
/*
 LevelObjectler 3 adet checkpoint için  hangi nesneyi sahneye koyacağımız, 1., 2. ve 3. checkpointler için 
 bu nesnelerin hangi pozisyonlarda olması gerektiğini ve checkpoint üzerinden başarıyla geçebilmek için kaç adet
 nesneyi başarıyla checkpointe taşımamız gerektiğini belirtebildiğimiz nesnelerdir.
     */