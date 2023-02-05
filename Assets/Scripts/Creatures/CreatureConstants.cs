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
    public static float RANGE_COOLDOWN = 5f;

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