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
    public void Bowling_GivenANewMatch_HaveOnlyTenTurns()
    {
        // Given
        int expectedTurns = 10;

        Assert.AreEqual(expectedTurns, _bowlingGame.TotalAmountTurnsConst);
    }

    [Test]
    public void Bowling_GivenANewMatch_CheckTurnCount()
    {
        int expectedTurns = 10;

        Assert.AreEqual(expectedTurns, _bowlingGame.TotalAmountTurns);
    }
}

internal class BowlingGame
{
    private const int TOTAL_AMOUNT_TURNS = 10;

    private int[] turns = new int[TOTAL_AMOUNT_TURNS];

    public int TotalAmountTurnsConst {
        get
        {
            return TOTAL_AMOUNT_TURNS;
        }
    }

    public int TotalAmountTurns
    {
        get
        {
            return this.turns.Length;
        }
    }

}