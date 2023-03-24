using System;
using System.Collections.Generic;
using System.Linq;

class ChocolateDispenser
{
    private List<string> chocolates = new List<string>();
    private int[] colors = { 0, 0, 0, 0, 0, 0, 0 }; // [green, silver, blue, crimson, purple, red, pink]


    private int getColorIndex(string finalColor)
    {
        foreach (var color in Enum.GetValues(1, 2, 3, 4, 5, 6, 7, 8)
        {
            if (color.ToString() == finalColor)
            {
                return (int)color;
            }
        }
        return 0;
    }


    public void addChocolates(string color, int count)
    {
        for (int i = 0; i < count; i++)
        {
            chocolates.Insert(0, color);
            colors[color]++;
        }
    }

    public List<string> removeChocolates(int number)
    {
        List<string> removed = new List<string>();
        for (int i = 0; i < number && chocolates.Count > 0; i++)
        {
            string color = chocolates[0];
            chocolates.RemoveAt(0);
            colors[getColorIndex(color)]--;
            removed.Add(color);
        }
        return removed;
    }

    public List<string> dispenseChocolates(int number)
    {
        List<string> dispensed = new List<string>();
        for (int i = 0; i < number && chocolates.Count > 0; i++)
        {
            string color = chocolates[chocolates.Count - 1];
            chocolates.RemoveAt(chocolates.Count - 1);
            colors[getColorIndex(color)]--;
            dispensed.Add(color);
        }
        return dispensed;
    }

    public List<string> dispenseChocolatesOfColor(int number, string color)
    {
        List<string> dispensed = new List<string>();
        int count = 0;
        for (int i = chocolates.Count - 1; i >= 0 && count < number; i--)
        {
            if (chocolates[i] == color)
            {
                string dispensedColor = chocolates[i];
                chocolates.RemoveAt(i);
                colors[getColorIndex(dispensedColor)]--;
                dispensed.Insert(0, dispensedColor);
                count++;
            }
        }
        return dispensed;
    }

    public int[] noOfChocolates()
    {
        return colors;
    }

    public void sortChocolateBasedOnCount()
    {
        chocolates.Sort((x, y) => colors[getColorIndex(y)] - colors[getColorIndex(x)]);
    }

    public void changeChocolateColor(int number, string color, string finalColor)
    {
        int count = 0;
        for (int i = chocolates.Count - 1; i >= 0 && count < number; i--)
        {
            if (chocolates[i] == color)
            {
                chocolates[i] = finalColor;
                colors[getColorIndex(color)]--;
                colors[getColorIndex(finalColor)]++;
                count++;
            }
        }
    }

    public int[] changeChocolateColorAllOfxCount(string color, string finalColor)
    {
        int countOfFinalColorChocolates = 0;
        List<string> changedChocolates = new List<string>();
        for (int i = chocolates.Count - 1; i >= 0; i--)
        {
            if (chocolates[i] == color)
            {
                chocolates[i] = finalColor;
                colors[getColorIndex(color)]--;
                colors[getColorIndex(finalColor)]++;
                countOfFinalColorChocolates++;
            }
        }
        changedChocolates.AddRange(Enumerable.Repeat(finalColor, countOfFinalColorChocolates));
        changedChocolates.AddRange(chocolates);
        chocolates = changedChocolates;
        return new int[] { countOfFinalColorChocolates, chocolates.Count };
    }

    

    // public string removeChocolateOfColor(string color)
}
