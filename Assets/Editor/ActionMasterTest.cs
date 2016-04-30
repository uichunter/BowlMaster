using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ActionMasterTest {
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

    [Test]
    public void T01OneStrike ()
	{
		ActionMaster actionMaster = new ActionMaster();
		Assert.AreEqual(endTurn,actionMaster.Bowl(10));
	}
}
