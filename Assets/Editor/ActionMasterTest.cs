//using UnityEngine;
//using UnityEditor;
//using NUnit.Framework;
//
//public class ActionMasterTest {
//	private ActionMaster actionMaster;
//	private ActionMaster.Action endFrame = ActionMaster.Action.EndFrame;
//	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
//	private ActionMaster.Action reset = ActionMaster.Action.Reset;
//	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
//
//	[SetUp]
//	public void Setup ()
//	{
//        actionMaster = new ActionMaster();
//	}
//
//	[Test]
//	public void T01FirstRoll ()
//	{
//		actionMaster.Bowl(1);
//		Assert.AreEqual(endFrame,actionMaster.Bowl(2));
//	}
//
//	[Test]
//	public void T02FirstMissThenSpareRetrunEndFrame ()
//	{
//		actionMaster.Bowl(0);
//		Assert.AreEqual(endFrame,actionMaster.Bowl(10));
//	}
//
//	[Test]
//	public void T02AFirstMissThen10SecondFrameRetrunTidy ()
//	{
//		actionMaster.Bowl(0);
//		actionMaster.Bowl(10);
//		Assert.AreEqual(tidy,actionMaster.Bowl(2));
//	}
//
//
//	[Test]
//	public void T03ReturnResetInLastFrameWithSpare ()
//	{
//		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 8 };
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(reset,actionMaster.Bowl(2));
//	}
//
//	[Test]
//	public void T04ReturnTidyInRoll19 ()
//	{
//		int[] rolls = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(tidy,actionMaster.Bowl(2));
//	}
//
//	[Test]
//	public void T05ReturnTidyInLastFrameWithOneStrike ()
//	{
//		int[] rolls = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,10 };
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(tidy,actionMaster.Bowl(2));
//	}
//
//	[Test]
//	public void T06ReturnEndgameInLastFrameWithTwoStrike ()
//	{
//		int[] rolls = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,10,10};
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(endGame,actionMaster.Bowl(2));
//	}
//
//	[Test]
//	public void T06AReturnEndgameInLastFrameWithTripleStrike ()
//	{
//		int[] rolls = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2};
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(reset,actionMaster.Bowl(10));
//		Assert.AreEqual(reset,actionMaster.Bowl(10));
//		Assert.AreEqual(endGame,actionMaster.Bowl(10));
//	}
//
//	[Test]
//	public void T07ReturnEndgameInLastFrameWithNoSpare ()
//	{
//		int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(endGame,actionMaster.Bowl(2));
//	}
//
//	[Test]
//	public void T08ReturnTidyInLastFrameWithStrikeAndMiss ()
//	{
//		int[] rolls = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,10};
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(tidy,actionMaster.Bowl(0));
//	}
//
//	[Test]
//	public void T09ReturnEndGameInLastFrameWithOutSpare ()
//	{
//		int[] rolls = { 1, 2, 0, 10, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2,8};
//		foreach (int roll in rolls) {
//			actionMaster.Bowl(roll);
//		}
//
//		Assert.AreEqual(endGame,actionMaster.Bowl(1));
//	}
//
//	[Test]
//	public void T10YoutubeTest ()
//	{
//		Assert.AreEqual(tidy,actionMaster.Bowl(8));
//		Assert.AreEqual(endFrame,actionMaster.Bowl(2));
//		Assert.AreEqual(tidy,actionMaster.Bowl(7));
//		Assert.AreEqual(endFrame,actionMaster.Bowl(3));
//		Assert.AreEqual(tidy,actionMaster.Bowl(3));
//		Assert.AreEqual(endFrame,actionMaster.Bowl(4));
//	}
//
//
//}
