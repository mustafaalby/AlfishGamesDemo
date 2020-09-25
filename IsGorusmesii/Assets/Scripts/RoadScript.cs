using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    [SerializeField] GameObject Road1;
    [SerializeField] GameObject Road2;
    [SerializeField] GameObject Road3;
    private PitScript Pit1;
    private PitScript Pit2;
    private PitScript Pit3;
    private int level;
    [SerializeField] List<LevelObject> Levels=new  List<LevelObject>();
    [SerializeField] GameObject CollectibleObjectParent;
    private void Awake()
    {
        Pit1 = Road1.transform.GetChild(3).GetComponent<PitScript>();
        Pit2 = Road2.transform.GetChild(3).GetComponent<PitScript>();
        Pit3 = Road3.transform.GetChild(3).GetComponent<PitScript>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaceObjects()
    {
        Pit1.neededObjectsToPassLevel = Levels[level].neededObjectToPassLevelRoadOne;
        Pit2.neededObjectsToPassLevel = Levels[level].neededObjectToPassLevelRoadTwo;
        Pit3.neededObjectsToPassLevel = Levels[level].neededObjectToPassLevelRoadThree;
        for (int i = 0; i < Levels[level].roadOneObjectPositions.Count; i++)
        {
            Instantiate(Levels[level].levelObject,
                new Vector3(Levels[level].roadOneObjectPositions[i].x,
                Levels[level].roadOneObjectPositions[i].y,
                Road1.transform.position.z + Levels[level].roadOneObjectPositions[i].z),
                Quaternion.identity
                ,CollectibleObjectParent.transform
                );
        }
        for (int i = 0; i < Levels[level].roadTwoObjectPositions.Count; i++)
        {
            Instantiate(Levels[level].levelObject,
                new Vector3(Levels[level].roadTwoObjectPositions[i].x,
                Levels[level].roadTwoObjectPositions[i].y,
                Road2.transform.position.z + Levels[level].roadTwoObjectPositions[i].z),
                Quaternion.identity
                , CollectibleObjectParent.transform
                );
        }
        for (int i = 0; i < Levels[level].roadThreeObjectPositions.Count; i++)
        {
            Instantiate(Levels[level].levelObject,
                new Vector3(Levels[level].roadThreeObjectPositions[i].x,
                Levels[level].roadThreeObjectPositions[i].y,
                Road3.transform.position.z + Levels[level].roadThreeObjectPositions[i].z),
                Quaternion.identity
                , CollectibleObjectParent.transform
                );
        }
    }
    /*
     oynanacak olan level, setLevel ile alınır. PlaceProjects ile 1,2 ve 3. check pointe nesneler yerleştirilir. Checkpointi geçmek 
     için gerekli olan minimum nesne sayısı atanır.
         */
    public int getLevel()
    {
        return level;
    }
    public void setLevel(int temp)
    {
        level = temp;
    }
}
