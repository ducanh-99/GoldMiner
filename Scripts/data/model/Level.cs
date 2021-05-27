using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level 
{
    public int index;
    public int required_score;
    public int time;
    public int star; // star=0 : lock, star =1,2,3
    public Level(int index,int required_score,int time) {
        this.index = index;
        this.required_score = required_score;
        this.time = time;
        this.star = 0;
    }

    override
    public string ToString() {
        return "Index = " + index +
            ", required_score =" + required_score +
            ", time = " + time;
    }
}
