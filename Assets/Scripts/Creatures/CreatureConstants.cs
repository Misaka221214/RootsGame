using System;
using System.Collections.Generic;
using UnityEngine;

public static class CreatureConstants {
    public static float SEARCH_RANGE = 10f;

    public static float STUCK_VELOCITY_THRESHOLD = 0.001f;
    public static float STUCK_COOLDOWN = 3f;
    public static float STUCK_JUMP = 20f;

    public static float HEALTH_LOW = 5f;
    public static float HEALTH_MID = 10f;
    public static float HEALTH_HIGH = 15f;

    public static float MASS_LOW = 5f;
    public static float MASS_MID = 10f;
    public static float MASS_HIGH = 15f;

    public static float VELOCITY_LOW = 3f;
    public static float VELOCITY_MID = 10f;
    public static float VELOCITY_HIGH = 15f;

    public static int AMMO_LOW = 5;
    public static int AMMO_MID = 10;
    public static int AMMO_HIGH = 15;

    public static float MELEE_COOLDOWN = 50f;
    public static float RANGE_COOLDOWN = 50f;

    public static float WANDERING_COOLDOWN = 3f;

    public static float RABBIT_JUMP_COOLDOWN = 2f;
}

public enum CreatureType {
    SLIME,
    RABBIT,
    NEYMAR,
    CTHULHU,
    DORITOS,
    DORITOS_RABBIT,
    SLIME_NEYMAR
}

public static class CreatureData
{
    public static Dictionary<CreatureType, String> CreatureName = new Dictionary<CreatureType, String>(){
    {
        CreatureType.SLIME, "Slime"
    },{
        CreatureType.RABBIT, "Rabbit"
    },{
        CreatureType.NEYMAR, "Neymar"
    },{
        CreatureType.CTHULHU, "Cthulhu"
    },{
        CreatureType.DORITOS, "Doritos"
    },{
        CreatureType.DORITOS_RABBIT, "Doritos Rabbit"
    },{
        CreatureType.SLIME_NEYMAR, "Slime Neymar"
    }
    };
    
    public static Dictionary<CreatureType, Sprite> CreatureSprite = new Dictionary<CreatureType, Sprite>(){
        {
            CreatureType.SLIME, Resources.Load("Assets/Resources/CreatureSprites/slime.png") as Sprite
        },{
            CreatureType.RABBIT, Resources.Load("Assets/Resources/CreatureSprites/兔子.png") as Sprite
        },{
            CreatureType.NEYMAR, Resources.Load("Assets/Resources/CreatureSprites/Neymar Idle.png") as Sprite
        },{
            CreatureType.CTHULHU, Resources.Load("Assets/Resources/CreatureSprites/slime.png") as Sprite
        },{
            CreatureType.DORITOS, Resources.Load("Assets/Resources/CreatureSprites/slime.png") as Sprite
        },{
            CreatureType.DORITOS_RABBIT, Resources.Load("Assets/Resources/CreatureSprites/slime.png") as Sprite
        },{
            CreatureType.SLIME_NEYMAR, Resources.Load("Assets/Resources/CreatureSprites/slime.png") as Sprite
        }
    };
    
}