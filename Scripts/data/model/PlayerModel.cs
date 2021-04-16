using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerModel
{
    public int money;
    public int dynamite;

    public PlayerModel(int money,int dynamite) {
        this.money = money;
        this.dynamite = dynamite;
    }

    public PlayerModel() {

    }


}
