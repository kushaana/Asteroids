using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;
    static float ballLifeTime = 10;
    static float minRandomSpawnTime = 5;
    static float maxRandomSpawnTime = 10;
    static float stdBlockPoints = 2;
    static float bonusBlockPoints = 5;
    static float pickupBlockPoints = 3;
    static float stdBlockProbability = 0.7f;
    static float bonusBlockProbability = 0.2f;
    static float pickupBlockProbability = 0.1f;
    static float ballsPerGame = 5;
    static float freezeTime = 2;
    static float speedUpTime = 2;
    static float speedUpFactor = 2;


    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the ball life time
    /// </summary>
    /// <value>ball life time</value>
    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float MinRandomSpawnTime
    {
        get { return minRandomSpawnTime; }
    }

    public float MaxRandomSpawnTime
    {
        get { return maxRandomSpawnTime; }
    }

    public float StdBlockPoints
    {
        get { return stdBlockPoints; }
    }

    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public float PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    public float StdBlockProbability
    {
        get { return stdBlockProbability; }
    }
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability; }
    }
    public float PickupBlockProbability
    {
        get { return pickupBlockProbability; }
    }

    public float BallsPerGame
    {
        get { return ballsPerGame; }
    }

    public float FreezeTime
    {
        get { return freezeTime; }
    }

    public float SpeedUpTime
    {
        get { return speedUpTime; }
    }

    public float SpeedUpFactor
    {
        get { return speedUpFactor; }
    } 
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReading();
    }

    public void StreamReading()
    {
        StreamReader streamReader = null;
        //string[] name;
        string[] values;
        try
        {
            streamReader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string readLine = streamReader.ReadLine();
            readLine.Split(',');
            readLine = streamReader.ReadLine();
            values = readLine.Split(',');
            FillVariablies(values);
        }
        catch (Exception) { }
        finally
        {
            if (streamReader != null)
                streamReader.Close();
        }
    }
    public void FillVariablies(string[] values)
    {
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minRandomSpawnTime = float.Parse(values[3]);
        maxRandomSpawnTime = float.Parse(values[4]);
        stdBlockPoints = float.Parse(values[5]);
        bonusBlockPoints = float.Parse(values[6]);
        pickupBlockPoints = float.Parse(values[7]);
        stdBlockProbability = float.Parse(values[8]);
        bonusBlockProbability = float.Parse(values[9]);
        pickupBlockProbability = float.Parse(values[10]);
        ballsPerGame = float.Parse(values[11]);
        freezeTime = float.Parse(values[12]);
        speedUpTime = float.Parse(values[13]);
        speedUpFactor = float.Parse(values[14]);
    }
    #endregion
}
