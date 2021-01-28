using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ChanceCalculater
{
    public static int RollChance(int normalChance, int overallChance)
    {
        overallChance += normalChance;

        int roll = Random.Range(0, 100);

        if (overallChance >= roll)
            overallChance = 0;

        return overallChance;
    }
}
