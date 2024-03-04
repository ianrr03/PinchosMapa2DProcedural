using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum; //5
    [SerializeField] int spikeSpawnHeight;
    [SerializeField] GameObject dirt, Grass, spike;
    
    // Start is called before the first frame update
    void Start()
    {
        Generation();
    }//Start

    void Generation() 
    {
        int repeatValue = 0;
        for (int x = 0; x < width; x++)
        {
            if (repeatNum == 0) 
            { 
                height = Random.Range(minHeight, maxHeight);
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;


            } else
            {
                GenerateFlatPlatform(x);
                repeatValue--;
            }
        }
             
    }//Generation

    void GenerateFlatPlatform(int x)
    {
        for(int y=0; y < height; y++)
        {
            spawnObj(dirt,x,y);
        }
        if(height < spikeSpawnHeight)
        {
            spawnObj(Grass, x, height);
            spawnObj(spike, x,height + 1);
        }else
         {
            spawnObj(Grass,x,height - 0.6f);

         }
        
    }

    void spawnObj (GameObject obj, int x, float y)
    {
        obj=Instantiate(obj,new Vector2(x,y), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
    
}
