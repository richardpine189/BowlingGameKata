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
    // Si en un turno el jugador no tira los 10 bolos, la puntuaci�n del turno es el total de bolos tirados.
    [Test]
    public void GivenTwoThrows_SumTotalOfPinesDown()
    {

    }
    /* Si en un turno el jugador tira los 10 bolos (spare), la puntuaci�n es 10 m�s el numero de bolos tirados
     * en la siguiente tirada (del siguiente turno).
     */
    [Test]
    public void GivenATurn_WithAllPinesDownBetweenTwoThrows_SumTheNextResultThrow()
    {

    }
    /* Si en la primera tirada del turno tira los 10 bolos (strike) el turno acaba y la puntuaci�n es 10
     * mas las dos siguientes tiradas.
     */
    [Test]
    public void GivenATurn_WhereThePlayerMakeAStrike_SumTheNextTwoResultThrows()
    {

    }
    /* Si el jugador logra un spare o un strike en el �ltimo turno, obtiene una o dos tiradas respectivamente
     * de bonificaci�n. Estas tiradas cuentan como parte del mismo turno (El decimo).
     */
    [Test]
    public void GivenTheLastTurn_WhereThePlayerMakesASpare_GenerateOneBonusThrow()
    {

    }
    public void GivenTheLastTurn_WhereThePlayerMakesAStrike_GenerateTwoBonusThrow()
    {

    }
    /* Si en las tiradas de bonificaci�n el jugador tira todos los bolos, el proceso NO se repite,
     * es decir no se generan mas tiradas de bonificaci�n.
     */

    //NOTA: El puntaje generado en las tiradas de bonificaci�n se suma a la puntuaci�n del turno final.
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