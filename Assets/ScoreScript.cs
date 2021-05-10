using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript
{
    private static int level = 1;
    
    public void increment()
    {
        level++;
    }

    public void reset()
    {
        level = 1;
    }

    public int get()
    {
        return level;
    }
}
