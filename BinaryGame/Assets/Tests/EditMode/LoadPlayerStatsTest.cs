using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class LoadPlayerStatsTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void LoadHealthTest()
    {
        var gameObject = new GameObject();

        var gameController = gameObject.AddComponent<GameController>();


        int health = 3;


        Assert.AreEqual(health, gameController.health);
    }

    [Test]
    public void LoadScoreTest()
    {
        var gameObject = new GameObject();

        var gameController = gameObject.AddComponent<GameController>();


        int score = 0;


        Assert.AreEqual(score, gameController.endlessScore);
    }

    [Test]
    public void LoadCurrentLevelTest()
    {
        var gameObject = new GameObject();

        var gameController = gameObject.AddComponent<GameController>();


        int currentLevel = 1;


        Assert.AreEqual(currentLevel, gameController.currentLevel);
    }

}
