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

    // Cada partida se compone de 10 turnos.

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

    // Hay 10 bolos que intentan tirar en cada turno.
    [Test]
    public void GivenAMatch_ExistOnlyTenPines()
    {

    }
    // En cada turno el jugador hace dos tiradas.
    [Test]
    public void GivenATurn_PlayerHaveTwoThrows()
    {

    }
    // Si en un turno el jugador no tira los 10 bolos, la puntuación del turno es el total de bolos tirados.
    [Test]
    public void GivenTwoThrows_SumTotalOfPinesDown()
    {

    }
    /* Si en un turno el jugador tira los 10 bolos (spare), la puntuación es 10 más el numero de bolos tirados
     * en la siguiente tirada (del siguiente turno).
     */
    [Test]
    public void GivenATurn_WithAllPinesDownBetweenTwoThrows_SumTheNextResultThrow()
    {

    }
    /* Si en la primera tirada del turno tira los 10 bolos (strike) el turno acaba y la puntuación es 10
     * mas las dos siguientes tiradas.
     */
    [Test]
    public void GivenATurn_WhereThePlayerMakeAStrike_SumTheNextTwoResultThrows()
    {

    }
    /* Si el jugador logra un spare o un strike en el último turno, obtiene una o dos tiradas respectivamente
     * de bonificación. Estas tiradas cuentan como parte del mismo turno (El decimo).
     */
    [Test]
    public void GivenTheLastTurn_WhereThePlayerMakesASpare_GenerateOneBonusThrow()
    {

    }
    public void GivenTheLastTurn_WhereThePlayerMakesAStrike_GenerateTwoBonusThrow()
    {

    }
    /* Si en las tiradas de bonificación el jugador tira todos los bolos, el proceso NO se repite,
     * es decir no se generan mas tiradas de bonificación.
     */

    //NOTA: El puntaje generado en las tiradas de bonificación se suma a la puntuación del turno final.
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