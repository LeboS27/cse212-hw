public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        var multiples = new double[length];// above l was creating an array of size length
        //initializing count i to know when the length has been reached, we start with a count of 1 because the number variable is the first one
        double multiple = number; // the constant 'number' or multiple to be continously added

        for(int i = 0; i < length; ++i)
        {
            multiples[i] = number; // here we are adding the multiple to the dynamic array
            number += multiple; // since it is a multiple we can simply just add number continuosly until we reach the length
        }
        return multiples; // returning the array multiples after the length has been reached
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //if list is empty or has 1  do nothing
        if (data.Count <= 1)
            return;
        
        // handle amount larger than list total
        amount = amount % data.Count;
        //if no rotation needed return
        if (amount == 0)
            return;
        
        // saving the last 'amount' elements
        List<int> temp = data.GetRange(data.Count - amount, amount);
        //removing those elements from the end
        data.RemoveRange(data.Count - amount, amount);
        // finsl strpdd them to the beginning
        data.InsertRange(0, temp);
        }
}
