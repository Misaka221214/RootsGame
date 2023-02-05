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

    public static float MELEE_COOLDOWN = 5f;
    public static float RANGE_COOLDOWN = 3f;

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
    SLIME_NEYMAR,
    SLIME_CTHULHU,
    NYAR,
    GREEN_DORITOS,
    DORITOS_OCTOPUS,
    GREEN_NYAR,
    GREEN_RABBIT_OCTOPUS,
    GREEN_DORITOS_RABBIT,
    TRASH,
    NULL
}

public static class CreatureData
{
    // TODO: Add data for missing creatures

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
            CreatureType.SLIME, Resources.Load<Sprite>("CreatureSprites/slime")
        },{
            CreatureType.RABBIT, Resources.Load<Sprite>("CreatureSprites/兔子")
        },{
            CreatureType.NEYMAR, Resources.Load<Sprite>("CreatureSprites/Neymar Idle")
        },{
            CreatureType.CTHULHU, Resources.Load<Sprite>("CreatureSprites/slime")
        },{
            CreatureType.DORITOS, Resources.Load<Sprite>("CreatureSprites/slime")
        },{
            CreatureType.DORITOS_RABBIT, Resources.Load<Sprite>("CreatureSprites/slime")
        },{
            CreatureType.SLIME_NEYMAR, Resources.Load<Sprite>("CreatureSprites/骷髅史莱姆（史莱姆包着一具骷髅）")
        }
    };
    
    public static Dictionary<CreatureType, UnityEngine.Object> CreatureEnemyObject = new Dictionary<CreatureType, UnityEngine.Object>(){
        {
            CreatureType.SLIME, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        },{
            CreatureType.RABBIT, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        },{
            CreatureType.NEYMAR, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        },{
            CreatureType.CTHULHU, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        },{
            CreatureType.DORITOS, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        },{
            CreatureType.DORITOS_RABBIT, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        },{
            CreatureType.SLIME_NEYMAR, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        }
    };

    public static Dictionary<CreatureType, GameObject> PlayerCreaturePrefabs = new Dictionary<CreatureType, GameObject>(){
        {
            CreatureType.SLIME, Resources.Load("Prefabs/Creatures/Slime") as GameObject
        },{
            CreatureType.RABBIT, Resources.Load("Prefabs/Creatures/Rabbit") as GameObject
        },{
            CreatureType.NEYMAR, Resources.Load("Prefabs/Creatures/Neymar") as GameObject
        },{
            CreatureType.CTHULHU, Resources.Load("Prefabs/Creatures/Cthulhu") as GameObject
        },{
            CreatureType.DORITOS, Resources.Load("Prefabs/Creatures/Doritos") as GameObject
        },{
            CreatureType.DORITOS_RABBIT, Resources.Load("Prefabs/Creatures/DoritosRabbit") as GameObject
        }//{
            // CreatureType.SLIME_NEYMAR, Resources.Load("Prefabs/Creatures/SlimeEnemy")
        //}
    };

}