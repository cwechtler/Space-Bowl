using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

public class ActionMasterTest
{
    //private List<int> pinFalls;
    //private ActionMasterOld.Action endTurn = ActionMasterOld.Action.EndTurn;
    //private ActionMasterOld.Action tidy = ActionMasterOld.Action.Tidy;
    //private ActionMasterOld.Action reset = ActionMasterOld.Action.Reset;
    //private ActionMasterOld.Action endGame = ActionMasterOld.Action.EndGame;


    //[SetUp]
    //public void Setup(){
    //    pinFalls = new List<int>();
    //}

    //[Test]
    //public void T00PassingTest() {
    //    Assert.AreEqual(1, 1);
    //}

    //[Test]
    //public void T01OneStrikeReturnsEndTurn(){
    //    pinFalls.Add(10);
    //    Assert.AreEqual(endTurn, ActionMasterOld.NextAction(pinFalls));
    //}

    //[Test]
    //public void T02Bowl8ReturnTidy(){
    //    pinFalls.Add(8);
    //    Assert.AreEqual(tidy, ActionMasterOld.NextAction(pinFalls));
    //}

    //[Test]
    //public void T03Bowl28SpareReturnsEndTurn(){
    //    int[] rolls = { 0, 10 };
    //    Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T04CheckResetStrikeBowl19(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
    //    Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T05CheckResetAtSpareInLastFrame(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9 };
    //    Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T06CheckEndGameInLastFrame(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 8,2,2 };
    //    Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T07CheckEndGameAtBowl20(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,2 };
    //    Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T08CheckTidyAtBowl20(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5 };
    //    Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T09CheckTidyAtGutterBowl20(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0 };
    //    Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T10CheckResetStrikeBowl20(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10 };
    //    Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T11CheckEndGame0Bowl20(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 9,0 };
    //    Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T12CheckBowl10OnSecondBallInFrame(){
    //    int[] rolls = { 0,10, 5,1 };
    //    Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T13CheckEndGameTurkey(){
    //    int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10 };
    //    Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    //}

    //[Test]
    //public void T14CheckZeroOneGivesEndturn(){
    //    int[] rolls = { 0, 1 };
    //    Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    //}
}
