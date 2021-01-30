using System;

public static class MyExtentions
{
	public static void Randomise (this ObjectToGenerate[] arr)
	{
		Random rand = new Random();

		for (int i = arr.Length - 1; i >= 1; i--)
		{
			int j = rand.Next(i + 1);

			ObjectToGenerate tmp = arr[j];
			arr[j] = arr[i];
			arr[i] = tmp;
		}
	}
}