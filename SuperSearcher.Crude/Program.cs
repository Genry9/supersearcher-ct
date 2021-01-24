using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

namespace SuperSearcher.Crude
{
	class Program
	{
		static List<string> _found;
		static int _limit = 5;
		static bool _readyToExit = false;

		static List<KeyValuePair<string, DateTime>> history = new List<KeyValuePair<string, DateTime>>();

		static void Main(string[] args)
		{
			while (!_readyToExit)
			{
				Menu();
			}

		}

		public static void StartSearch()
		{
			_found = new List<string>();
			KeyValuePair<string, string> conditions;
			try 
			{
				conditions = GetSearchConditions();
			}
			catch(ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
				Pause();
				StartSearch();
				return;
			}
			
			history.Add(new KeyValuePair<string, DateTime>(conditions.Value, DateTime.UtcNow));
			Search(conditions.Key, conditions.Value);
			ShowSearchResults();

		}

		static void Pause()
		{
			Console.WriteLine("Press Enter to continue..");
			Console.ReadLine();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		/// <exception cref="ArgumentException">Thrown when wrong start path</exception>
		static KeyValuePair<string, string> GetSearchConditions()
		{
			Console.WriteLine("Type start Path");
			var _key = Console.ReadLine();

			if (!Directory.Exists(_key))
			{
				throw new ArgumentException($"{_key}: Not Found!");
			}

			Console.WriteLine("Type search term");
			var _value = Console.ReadLine();
			return new KeyValuePair<string, string>(_key, _value);
		}

		static void ShowSearchResults()
		{
			Console.WriteLine($"\tFiles found: {_found.Count}\n");
			foreach (var item in _found)
			{
				Console.WriteLine(item);
			}
			Pause();
		}


		static void ShowHistory()
		{
			foreach (var item in history.OrderBy(x => x.Value))
			{
				Console.WriteLine($"{item.Value}:{item.Key}");
			}
		}

		static void Menu()
		{

			Console.Clear();
			Console.WriteLine("Press 1 to start search;\nPress 2 to show history;\nPress 3 to view statistics;\n");
			switch (Console.ReadKey().Key)
			{

				case ConsoleKey.D0:
				break;
				case ConsoleKey.D1:
				StartSearch();
				break;
				case ConsoleKey.D2:
				break;
				case ConsoleKey.D3:
				break;
				case ConsoleKey.D4:
				break;
				case ConsoleKey.D5:
				break;
				case ConsoleKey.D6:
				break;
				case ConsoleKey.D7:
				break;
				case ConsoleKey.D8:
				break;
				case ConsoleKey.D9:
				break;
				case ConsoleKey.NumPad0:
				break;
				case ConsoleKey.NumPad1:
				StartSearch();
				break;
				case ConsoleKey.NumPad2:
				break;
				case ConsoleKey.NumPad3:
				break;
				case ConsoleKey.NumPad4:
				break;
				case ConsoleKey.NumPad5:
				break;
				case ConsoleKey.NumPad6:
				break;
				case ConsoleKey.NumPad7:
				break;
				case ConsoleKey.NumPad8:
				break;
				case ConsoleKey.NumPad9:
				break;
				case ConsoleKey.Oem1:
				StartSearch();
				break;
				case ConsoleKey.OemPlus:
				break;
				case ConsoleKey.OemComma:
				break;
				case ConsoleKey.OemMinus:
				break;
				case ConsoleKey.OemPeriod:
				break;
				case ConsoleKey.Oem2:
				break;
				case ConsoleKey.Oem3:
				break;
				case ConsoleKey.Oem4:
				break;
				case ConsoleKey.Oem5:
				break;
				case ConsoleKey.Oem6:
				break;
				case ConsoleKey.Oem7:
				break;
				case ConsoleKey.Oem8:
				break;
				case ConsoleKey.Oem102:
				break;
				default:
				_readyToExit = true;
				break;
			}
		}

		static void Search(string from, string _for)
		{
			_found.AddRange(GetFiles(from, _for));

			if (_found.Count > _limit)
			{
				return;
			}
			else
				foreach (var item in GetDirectories(from))
				{
					Search(item, _for);
				}
		}

		static IEnumerable<string> GetFiles(string from, string with)
		{
			try
			{

				return Directory.GetFiles(from).Where(x => Path.GetFileName(x).Contains(with));
			}
			catch (UnauthorizedAccessException)
			{
				return new List<string>();
			}

		}
		static string[] GetDirectories(string from)
		{
			try
			{
				return Directory.GetDirectories(from);
			}
			catch (UnauthorizedAccessException)
			{
				return new string[0];
			}
		}
	}
}
