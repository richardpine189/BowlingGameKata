using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    // Las tiradas no cargadas deberían ser nulas
    [Test]
    public void NotLoadedTurn_IsNull()
    {
        Assert.Null(_bowlingGame.Turns[0]);
    }

    // Cargar una tirada en la primer posición
    [Test]
    public void GivenAThrow_ReturnResult()
    {
        int firstThrow = 7;

        _bowlingGame.AddThrow(firstThrow);

        Assert.AreEqual(firstThrow, _bowlingGame.Turns[0][0]);

        int secondThrow = 2;

        _bowlingGame.AddThrow(secondThrow);

        Assert.AreEqual(secondThrow, _bowlingGame.Turns[0][1]);
    }

    // En cada turno el jugador hace dos tiradas.
    [Test]
    public void GivenATurn_PlayerHaveTwoThrows()
    {
        int[] Turn = new int[2] { 6, 3 };

        for (int i = 0; i < Turn.Length; i++)
        {
            _bowlingGame.AddThrow(Turn[i]);
        }

        Assert.AreEqual(Turn, _bowlingGame.Turns[0]);
    }

    // Test para ver si cierto turno es un spare
    [TestCase(5, 4, false)]
    [TestCase(8, 2, true)]
    [TestCase(10, 8, false)]
    public void GivenATurn_CheckIfSpare(int firstThrow, int secondThrow, bool isSpare)
    {
        _bowlingGame.AddThrow(firstThrow);
        _bowlingGame.AddThrow(secondThrow);

        Assert.AreEqual(isSpare, _bowlingGame.TurnIsSpare(0));
    }

    // Test para ver si cierto turno es un strike
    [TestCase(5, 4, false)]
    [TestCase(8, 2, false)]
    [TestCase(10, 8, true)]
    public void GivenATurn_CheckIfStrike(int firstThrow, int secondThrow, bool isSpare)
    {
        _bowlingGame.AddThrow(firstThrow);
        _bowlingGame.AddThrow(secondThrow);

        Assert.AreEqual(isSpare, _bowlingGame.TurnIsStrike(0));
    }

    // Si en un tiro se hace un strike el siguiente tiro se debe cargar en el próximo turno, y el segundo tiro del strike debe quedar nulo.
    [Test]
    public void GivenAStrike_NextThrowInNextTurn()
    {
        _bowlingGame.AddThrow(10);
        _bowlingGame.AddThrow(9);

        Assert.Null(_bowlingGame.Turns[0][1]);

        Assert.AreEqual(9, _bowlingGame.Turns[1][0]);
    }

    // Si en un turno el jugador no tira los 10 bolos, la puntuación del turno es el total de bolos tirados.
    [Test]
    public void GivenTwoThrows_SumTotalOfPinesDown()
    {
        _bowlingGame.AddThrow(3);
        _bowlingGame.AddThrow(5);

        Assert.AreEqual(8, _bowlingGame.GetTurnScore(0));
    }

    // Si en un turno hay un spare se suma a la puntuación del turno el próximo tiro.
    [TestCase(null, ExpectedResult = null)]
    [TestCase(6, ExpectedResult = 16)]
    public int? GivenATurn_WithAllPinesDownBetweenTwoThrows_SumTheNextResultThrow(int? thirdThrow)
    {
        _bowlingGame.AddThrow(7);
        _bowlingGame.AddThrow(3);

        if (thirdThrow != null)
        {
            _bowlingGame.AddThrow(thirdThrow.Value);
        }

        return _bowlingGame.GetTurnScore(0);
    }

    // Si en un turno hay un strike se suma la puntuación de los próximos dos tiros.
    [TestCase(3, 5, ExpectedResult = 18)]
    [TestCase(null, 7, ExpectedResult = null)]
    public int? GivenATurn_WhereThePlayerMakeAStrike_SumTheNextTwoResultThrows(int? thirdThrow, int? fourthThrow)
    {
        _bowlingGame.AddThrow(10);

        if (thirdThrow != null)
        {
            _bowlingGame.AddThrow(thirdThrow.Value);
        }

        if (fourthThrow != null)
        {
            _bowlingGame.AddThrow(fourthThrow.Value);
        }

        return _bowlingGame.GetTurnScore(0);
    }

    // Si hay un strike 

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

    private int?[][] turns = new int?[TOTAL_AMOUNT_TURNS][];

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

    // Esta propiedad tiene sentido? Xq Solo existe para el test, no tiene ninguna utilidad para la clase, y de hecho hace más visible algo que tal vez no debería serlo
    public int?[][] Turns
    {
        get
        {
            return turns;
        }
    }

    public void AddThrow(int pinsThrown)
    {
        for (int i = 0; i < TOTAL_AMOUNT_TURNS; i++)
        {
            if (turns[i] == null)
            {
                turns[i] = new int?[2];
            }
            
            if(turns[i][0] != 10)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (turns[i][j] == null)
                    {
                        turns[i][j] = pinsThrown;
                        return;
                    }
                }
            }
        }
    }

    public bool TurnIsSpare(int turnIndex)
    {
        if(turns[turnIndex] != null)
        {
            if(turns[turnIndex][0] != null && turns[turnIndex][1] != null && turns[turnIndex][1] != null && turns[turnIndex].Sum() == 10)
            {
                return true;
            }
        }

        return false;
    }

    public bool TurnIsStrike(int turnIndex)
    {
        if(turns[turnIndex] != null)
        {
            if (turns[turnIndex][0] == 10)
            {
                return true;
            }
        }

        return false;
    }

    // Calcularlo cada vez que se necesita mostrar me parece poco performante.
    // Turno debería ser una clase en sí misma con la cantidad de bolos de cada tiro y un puntaje?
    // O debería tener un array paralelo con los puntajes de cada turno?
    public int? GetTurnScore(int turnIndex)
    {
        if(TurnIsStrike(turnIndex))
        {
            if(turns[turnIndex + 1] != null)
            {
                if(turns[turnIndex + 1][0] == 10)
                {
                    if (turns[turnIndex + 2] != null)
                    {
                        return 10 + turns[turnIndex + 1][0] + turns[turnIndex + 2][0];
                    }

                    return null;
                }

                if(turns[turnIndex + 1][1] != null)
                {
                    return 10 + turns[turnIndex + 1][0] + turns[turnIndex + 1][1];
                }
            }

            return null;
        }
        
        if(TurnIsSpare(turnIndex))
        {
            if(turns[turnIndex + 1] != null && turns[turnIndex + 1][0] != null)
            {
                return turns[turnIndex].Sum() + turns[turnIndex + 1][0];
            }

            return null;
        }
        
        if(turns[turnIndex].Any(x => !x.HasValue))
        {
            return null;
        }

        return turns[turnIndex].Sum();
    }
}