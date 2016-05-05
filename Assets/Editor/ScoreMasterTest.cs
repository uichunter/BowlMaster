using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class ScoreMasterTest  {


	private List<FrameList> frameList;
	private List<int> guess;
	private List<int> scoreList;

	[SetUp]
	public void Setup ()
	{
		frameList = new List<FrameList>();
		guess = new List<int>();
		scoreList = new List<int>();
	}

	[Test]
	public void T01Normal(){
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=1,RollID=2,PinDown=1});

		guess.Add(2);
		Assert.AreEqual(guess,ScoreMaster.ScoreList(frameList));
	}

	[Test]
	public void T02FewMoreStep(){
		
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=1,RollID=2,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=1});


		guess.Add(2);
		guess.Add(4);
		Assert.AreEqual(guess,ScoreMaster.ScoreList(frameList));
	}

	[Test]
	public void T03OneStrike(){
		
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=10});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=1});


		guess.Add(12);
		guess.Add(14);
		scoreList = ScoreMaster.ScoreList(frameList);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T04DoubleStrke ()
	{
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=10});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=1});
		frameList.Add(new FrameList{FrameID=3,RollID=1,PinDown=10});

		scoreList = ScoreMaster.ScoreList(frameList);

		guess.Add(12);
		guess.Add(14);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T05ThreeSpare()
	{
		frameList.Add(new FrameList{FrameID=1,RollID=1,PinDown=3});
		frameList.Add(new FrameList{FrameID=1,RollID=2,PinDown=7});
		frameList.Add(new FrameList{FrameID=2,RollID=1,PinDown=1});
		frameList.Add(new FrameList{FrameID=2,RollID=2,PinDown=9});
		frameList.Add(new FrameList{FrameID=3,RollID=1,PinDown=5});
		frameList.Add(new FrameList{FrameID=3,RollID=2,PinDown=5});

		scoreList = ScoreMaster.ScoreList(frameList);

		guess.Add(11);
		guess.Add(26);
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T06AllOneBeforeFrame10 ()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				frameList.Add (new FrameList{ FrameID = i, RollID = j, PinDown = 1});
			}
		}

		scoreList = ScoreMaster.ScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		Assert.AreEqual(guess,scoreList);
	}

	[Test]
	public void T07FullOneHit()
	{
		for (int i = 1; i <= 9; i++) {
			for (int j = 1; j <= 2; j++) {
				frameList.Add (new FrameList{ FrameID = i, RollID = j, PinDown = 1});
			}
		}
		frameList.Add (new FrameList{ FrameID =10, RollID =1, PinDown = 1});
		frameList.Add (new FrameList{ FrameID =10, RollID =2, PinDown = 1});

		scoreList = ScoreMaster.ScoreList (frameList);

		int sum =0;
		for (int i = 1; i <= 9; i++) {
			sum += 2;
			guess.Add(sum);
		}
		guess.Add(20);
		Assert.AreEqual(guess,scoreList);
	}

}
