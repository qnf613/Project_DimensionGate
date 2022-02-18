using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public int exp;
    public int expToNextLv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LevelSystem()
    {
        level = 1;
        exp = 0;
        expToNextLv = 10;
    }

    public void AddExperience(int amount)
    {
        exp += amount;
    }

    public void LevelUp()
    {
        level++;
        //Keep the amount of exp that exceeds the required amount to level up
        exp -= expToNextLv;
        //Increase the required amount of level up *this is temporary formula
        expToNextLv *= 2;
    }

    //debug purpose
    public int GetLevelNum()
    {
        return level;
    }

}
