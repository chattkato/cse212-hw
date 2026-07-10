public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int amount)
{
    // Plan:
    // 1. I need to return an array of doubles with 'amount' elements.
    // 2. Each element at index i should be the (i+1)th multiple of 'number',
    //    i.e. number * 1, number * 2, number * 3, ... number * amount.
    // 3. Create an array of size 'amount'.
    // 4. Loop from 0 to amount-1, and at each index store number * (index+1).
    // 5. Return the filled array.

    double[] multiples = new double[amount];

    for (int i = 0; i < amount; i++)
    {
        multiples[i] = number * (i + 1);
    }

    return multiples;
}
       public static void RotateListRight(List<int> data, int amount)
{
    // Plan:
    // 1. Rotating right by 'amount' means the last 'amount' elements move to
    //    the front, and everything else shifts right to fill in behind them.
    // 2. Using list slicing:
    //    - The "tail" is the last 'amount' elements: data.GetRange(data.Count - amount, amount)
    //    - The "head" is everything before that: data.GetRange(0, data.Count - amount)
    // 3. Clear the original list.
    // 4. Add the tail first, then add the head after it.
    //    This reconstructs the list in the rotated order.

    int count = data.Count;

    List<int> tail = data.GetRange(count - amount, amount);
    List<int> head = data.GetRange(0, count - amount);

    data.Clear();
    data.AddRange(tail);
    data.AddRange(head);
}
}
