using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : Singleton<StageController>
{

   public GameObject StagePrefab;

    public BuildingPiece[] BuildingPieces;
    public DetectorArea DetectorArea;

    public Transform SpawnPoint;

    

    
    // Start is called before the first frame update
    void SpawnStage()
    {
        var instance = Instantiate(StagePrefab);
        instance.transform.position = SpawnPoint.position;

        BuildingPieces = instance.GetComponentsInChildren<BuildingPiece>();
        DetectorArea = instance.GetComponentInChildren<DetectorArea>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
