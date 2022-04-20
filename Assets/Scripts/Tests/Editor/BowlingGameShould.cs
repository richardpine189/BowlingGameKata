using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BowlingGameShould
{
    private BowlingGame _bowlingGame;

    [SetUp]
    public void Setup()
    {
        _bowlingGame = new BowlingGame();
    }

    [Test]
    public void Test()
    {
        Assert.IsTrue(false);
    }
}
