using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : Singleton<StageController>
{

    public float Angle = 90;
    public float TorqueOffset = 5000;
    public float Power = 500000;
    public float PowerOffset = 10000;

    public Stage StagePrefab;
    public Transform SpawnPoint;


    private Stage stageInstance;
    // Start is called before the first frame update
    public void SpawnStage()
    {
        stageInstance = Instantiate(StagePrefab);
        stageInstance.transform.position = SpawnPoint.position;
    }

    public IEnumerator BreakingSequence()
    {

        yield return new WaitForSeconds(1);

        stageInstance.Scatter(Angle, Power - PowerOffset, Power + PowerOffset, -TorqueOffset, TorqueOffset);
        yield return new WaitForSeconds(1);

        stageInstance.Scatter(Angle, Power - PowerOffset, Power + PowerOffset, -TorqueOffset, TorqueOffset);
        yield return new WaitForSeconds(1);

        stageInstance.Scatter(Angle, Power - PowerOffset, Power + PowerOffset, -TorqueOffset, TorqueOffset);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
