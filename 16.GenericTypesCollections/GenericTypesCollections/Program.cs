
using GenericTypesCollections;
using GenericTypesCollections.Animals;
using GenericTypesCollections.Foods;
using System.Collections;


#region Product Example
//Product<int> product = new Product<int>(90);
//product.Quality -= 20;

//Product<char> product1 = new Product<char>('A');
//product1.Quality = 'B';

//Product<string> product2 = new Product<string>("High");
//product2.Quality += "++";

//Console.WriteLine(product.Quality);
//Console.WriteLine(product1.Quality);
//Console.WriteLine(product2.Quality);
#endregion

#region Generic Type Zoo example
//Lion lion=new Lion("Simba");
//Lion lion2 = new Lion("Pumba");
//Meat meat = new Meat("Beef");

//ZooCage<Lion,Meat> cageLion = new ZooCage<Lion,Meat>(meat);
//cageLion.Add(lion);
//cageLion.Add(lion2);

//cageLion.ShowAnimals();
//cageLion.ShowFood();
//Console.WriteLine("----------------------");

//Elephant elephant = new Elephant("Hakuna");
//Elephant elephant2 = new Elephant("Matata");
//Grass grass = new Grass("Saman");

//ZooCage<Elephant,Grass> cageElephant = new ZooCage<Elephant,Grass>(grass);
//cageElephant.Add(elephant);
//cageElephant.Add(elephant2);

//cageElephant.ShowAnimals();
//cageElephant.ShowFood(); 
#endregion

#region ArrayList
//ArrayList array = new ArrayList();

//array.Add(1);
//array.Add(23.40m);
//array.Add('A');
//array.Add("Salam");

//foreach (var item in array)
//{
//    Console.WriteLine(item);
//} 
#endregion

#region SortedList non-generic
//SortedList list = new SortedList();
//list.Add('z', "Baki");
//list.Add('d', "Berde");
//list.Add('a', "Ganja");
//list.Add(1, "Yevlax");
//list.Add('c', "Yevlax");

//foreach (DictionaryEntry item in list)
//{
//    Console.WriteLine(item.Key + " " + item.Value);
//} 
#endregion

#region SirtedList generic
//SortedList<char, string> sorted = new SortedList<char, string>();

//sorted.Add('z', "Baki");
//sorted.Add('d', "Berde");
//sorted.Add('a', "Ganja");
//sorted.Add('b', "Yevlax");
//sorted.Add('c', "Yevlax");

//bool result= sorted.TryAdd('q', "Qazax");

//foreach (var item in sorted)
//{
//    Console.WriteLine(item.Key+" "+item.Value);
//}
//Console.WriteLine(result);

#endregion

//LIFO
#region Stack
//Stack<string> books = new Stack<string>();


//books.Push("Baki");
//books.Push("Sumqayit");
//books.Push("Zaqatala");

//string name;
////books.Pop();

//books.TryPop(out name);

//books.TryPop(out name);

//books.TryPop(out name);

//bool result = books.TryPop(out name);
//Console.WriteLine(result);

//Console.WriteLine();


//Console.WriteLine(books.Pop());


//for (int i = 0; i < books.Count; i++)
//{
//    Console.WriteLine(books.ElementAt(i));
//} 
#endregion

//FIFO
#region Queue
//Queue<string> names = new Queue<string>();

//names.Enqueue("Azade");
//names.Enqueue("Fidan");
//names.Enqueue("Revan");

////Console.WriteLine(names.Peek());
//Console.WriteLine(names.Dequeue());

//Console.WriteLine("--------------------------");
//for (int i = 0; i < names.Count; i++)
//{
//    Console.WriteLine(names.ElementAt(i));
//}

//Console.WriteLine(names.Dequeue());

//Console.WriteLine(names.Dequeue());

//Console.WriteLine(names.Dequeue()); 
#endregion

#region Dictionary

//Dictionary<string, string> countries = new Dictionary<string, string>();

//countries.Add("Azerbaycan","Baki, Berde");
//countries.Add("Russia", "Baki, Berde");
//countries.Add("Georgia", "Tbilisi, Batumi");


//for (int i = 0; i < countries.Count; i++)
//{
//    Console.WriteLine(countries.ElementAt(i).Key+" "+ countries.ElementAt(i).Value);
//} 
#endregion

#region List<T>
//List<int> list2 = new List<int>();

//list2.Add(40);
//list2.Add(50);
//list2.Add(500);

//List<int> list=new List<int>();

//list.Add(1);
//list.Add(2);
//list.Add(200);

//list.AddRange(list2);
//list.RemoveAll(x => x > 50);
//list.Remove(2);


//for (int i = 0; i < list.Count; i++)
//{
//    Console.WriteLine(list[i]);
//} 
#endregion















