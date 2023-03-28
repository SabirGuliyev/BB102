int[,] numbers =
{
    {13,20,25},
    {15,25,40 },
    {30,40,70},
    {1,2,3 }
};

for (int i = 0; i < numbers.GetLength(0); i++)
{
    for (int j = 0; j < numbers.GetLength(1); j++)
    {
        Console.WriteLine(numbers[i, j]);
    }
}

//Console.WriteLine(numbers.GetLength(1));

//string[] words = new string[3];
//string[] names = { "Azade", "Natiq", "Yusif" };

//for (int i = 0; i < words.Length; i++)
//{
//    words[i] = Console.ReadLine();
//}

//Console.WriteLine("___________________");
//for (int i = 0; i < words.Length; i++)
//{
//    Console.WriteLine(words[i]);
//}


//string[] words = { "Salam", "NEcesen" };

//for (int i = 0; i < words.Length; i++)
//{
//    for (int j = 0; j < words[i].Length; j++)
//    {
//        Console.WriteLine(words[i][j]);
//    }
//}