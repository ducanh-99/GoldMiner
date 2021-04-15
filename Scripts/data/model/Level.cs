using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level 
{
    public int index;
    public int required_score;
    public int distance;
    public int time;
    public Level(int index,int required_score,int distance,int time) {
        this.index = index;
        this.required_score = required_score;
        this.distance = distance;
        this.time = time;
    }

    override
    public string ToString() {
        return "Index = " + index +
            ", required_score =" + required_score +
            ", distance = " + distance +
            ", time = " + time;
    }
}
