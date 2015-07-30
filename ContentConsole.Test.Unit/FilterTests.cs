using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace ContentConsole.Test.Unit
{

	[TestFixture]
	public class FilterTests
	{
		[Test]
		public void ReplaceWorld1()//not case sensitive
		{
			String world = "Horrible";

			String result = "H######e";

			Assert.AreEqual (result, Filter.ReplaceWorld (world));
		}

		[Test]
		public void ReplaceWorld2()//empty string
		{
			String world = "";

			String result = "";

			Assert.AreEqual (result, Filter.ReplaceWorld (world));
		}


		[Test]
		public void FilterBannedWorlds1() //empty string
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "";
			int count = 0;
			Assert.AreEqual (count, Filter.FilterBannedWorlds (bannedWorlds,text,true, true).BannedWorldsCount);
		}

		[Test]
		public void FilterBannedWorlds2()//same world several times
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "bad bad bad";
			int count = 3;
			Assert.AreEqual (count, Filter.FilterBannedWorlds (bannedWorlds,text,true, true).BannedWorldsCount);
		}

		[Test]
		public void FilterBannedWorlds3()//not case sensitive
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "Horrible";
			int count = 1;
			Assert.AreEqual (count, Filter.FilterBannedWorlds (bannedWorlds,text,true, false).BannedWorldsCount);
		}

		[Test]
		public void FilterBannedWorlds4()//not case sensitive - extreme
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "hORRiBlE";
			String result = "h######E";
			Assert.AreEqual (result, Filter.FilterBannedWorlds (bannedWorlds,text,true, false).TextResult);
		}

		[Test]
		public void FilterBannedWorlds5() //no space
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "badbadbad";
			int count = 3;
			Assert.AreEqual (count, Filter.FilterBannedWorlds (bannedWorlds,text,true, true).BannedWorldsCount);
		}

		[Test]
		public void FilterBannedWorlds6()//worlds replacement
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "I am a nasty boy";
			String result = "I am a n###y boy";

			Assert.AreEqual (result, Filter.FilterBannedWorlds (bannedWorlds,text,true, true).TextResult);
		}

		[Test]
		public void FilterBannedWorlds7()//no replacement
		{
			List<String> bannedWorlds = new List<String> ();

			bannedWorlds.Add ("swine");
			bannedWorlds.Add ("bad");
			bannedWorlds.Add ("nasty");
			bannedWorlds.Add ("horrible");

			String text = "I am a nasty boy";

			Assert.AreEqual (text, Filter.FilterBannedWorlds (bannedWorlds,text,false, true).TextResult);
		}
	}
}

