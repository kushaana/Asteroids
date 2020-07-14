using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;

    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return configurationData.BallLifeTime; }
    }

    public static float MinRandomSpawnTime
    {
        get { return configurationData.MinRandomSpawnTime; }
    }

    public static float MaxRandomSpawnTime
    {
        get { return configurationData.MaxRandomSpawnTime; }
    }

    public static float StdBlockPoints
    {
        get { return configurationData.StdBlockPoints; }
    }

    public static float BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }

    public static float PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }

    public static float StdBlockProbability
    {
        get { return configurationData.StdBlockProbability; }
    }
    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability; }
    }
    public static float PickupBlockProbability
    {
        get { return configurationData.PickupBlockProbability; }
    }

    public static float BallsPerGame
    {
        get { return configurationData.BallsPerGame; }
    }

    public static float FreezeTime
    {
        get { return configurationData.FreezeTime; }
    }

    public static float SpeedUpTime
    {
        get { return configurationData.SpeedUpTime; }
    }
    public static float SpeedUpFactor 
    {
        get { return configurationData.SpeedUpFactor; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
