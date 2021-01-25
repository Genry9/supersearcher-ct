namespace SuperSearcher.BLL.Models.Statistics.Extensions
{
	internal static class StringCalculationExtensions
	{
		internal static (int totalNum, int totalAlp, int totalSpec) CalculateSplit(this string str)
		{
			int alp, digit, splch, i, l;
			alp = digit = splch = i = 0;
			l = str.Length;

			while (i < l)
			{
				if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
				{
					alp++;
				}
				else if (str[i] >= '0' && str[i] <= '9')
				{
					digit++;
				}
				else
				{
					splch++;
				}

				i++;
			}

			return (digit, alp, splch);

		}

	}
}
