using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ContentConsole
{
	public static class Filter
	{
		
		public static FilterResult FilterBannedWorlds(List<String> bannedWorlds, String text, bool replace, bool caseSensitive) //! case sensitive
		{
			int count = 0;

			bool[] upperCases = new bool[text.Length];
			char[] charText = text.ToCharArray ();

			if (!caseSensitive) //detection of the upper case to replace them at the end
			{
				 
				for (int i = 0; i < charText.Length ; ++i)
				{
					if (char.IsUpper (charText [i])) 
					{
						upperCases [i] = true;
					} 
					else 
					{
						upperCases [i] = false;
					}
				}
				text = text.ToLower (); //lower all the text !
			}

			foreach (String bannedWorld in bannedWorlds) //loop on the bad worlds list
			{
				count += Regex.Matches(text, bannedWorld).Count; //count the negative worlds

				if (replace) //replace them if asked
				{
					string replacedbannedWorld = ReplaceWorld (bannedWorld);
					text = text.Replace (bannedWorld, replacedbannedWorld);
				}
					
			}

			if (!caseSensitive) //the text is lower -> we have to put back the upper cases
			{
				charText = text.ToCharArray ();

				for (int i = 0; i < charText.Length ; ++i)
				{
					if (upperCases [i]) 
					{
						charText [i] = char.ToUpper (charText [i]);
					} 
					else 
					{
						charText [i] = char.ToLower (charText [i]);
					}
				}

				text = new String(charText);
			}
		
			return new FilterResult (text, count);
		}

		public static string ReplaceWorld(string world) //! case sensitive
		{
			char[] localArray = world.ToCharArray ();

			for (int i = 1; i < localArray.Length - 1; ++i) 
			{
				localArray[i]='#';
			}

			return new string (localArray);
		}

	}



	public class FilterResult
	{
		private string textResult = "";
		public string TextResult {
			get
			{
				return textResult;
			}
		}

		private int bannedWorldsCount = 0;
		public int BannedWorldsCount {
			get 
			{
				return bannedWorldsCount;
			}
		}

		public FilterResult(string text, int count)
		{
		textResult = text;
		bannedWorldsCount = count;
		}
	}
}

