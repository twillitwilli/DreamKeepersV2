[System.Serializable]
public class BinarySaveData
{
    public string playerName;

    // -------------------- World Save Data ----------------------

    public int
        saveFile,
        currentScene;

    public float
        currentGameTime;

    // ------------------------------------------------------------

    // --------------------- Player Save Data ---------------------

    public float
        health,
        maxHealth,
        maxMagic,
        armor;

    public int
        gold,
        maxGold;

    public int
        arrows,
        maxArrows;

    public int
        healthCrystals,
        magicCrystals;

    // Dream Stats //

    public int
        soulHearts,
        soulHeartShards,
        dreamFragments,
        dreamShards,
        dreamCrystals;

    // ---------------------------------------------------------------

    // ------------------------ Unlocks ------------------------------

    public bool[] mainQuestProgression;

    public bool[] nexusPortalUnlocks;

    public bool[] unlockedSwords;

    public bool[] unlockedBows;

    public bool[] unlockedKeys;

    // ----------------------------------------------------------------

    // --------------------- Job Save Data ----------------------------

    public int[] currentLevel;

    public float[] currentExp;

    // ----------------------------------------------------------------
}
