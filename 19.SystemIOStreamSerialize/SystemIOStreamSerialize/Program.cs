
#region File,Directory

//string path = @"C:\Users\sabir\Desktop\";

//Directory.CreateDirectory(@"C:\Users\sabir\Desktop\BB102Test");
//Directory.CreateDirectory(@"C:\Users\sabir\Desktop\BB102Test\TEST1");
//Directory.CreateDirectory(@"C:\Users\sabir\Desktop\BB102Test\TEST2");
//Directory.CreateDirectory(@"C:\Users\sabir\Desktop\BB102Test\TEST3\TEST4");
//File.Create(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt");
//File.Create(@"C:\Users\sabir\Desktop\BB102Test\testFile1.txt");
//File.Create(@"C:\Users\sabir\Desktop\BB102Test\testFile2.txt");

//string[] directories = Directory.GetDirectories(@"C:\Users\sabir\Desktop\BB102Test");
//string[] files = Directory.GetFiles(@"C:\Users\sabir\Desktop\BB102Test");

//DirectoryInfo directory = new DirectoryInfo(@"C:\Users\sabir\Desktop\BB102Test");
//directory.Create();


//FileInfo file = new FileInfo();
//File.Create(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt");

//directory.Delete(true);


//foreach (string dir in directories)
//{
//    Console.WriteLine(dir);
//}


//foreach (string file in files)
//{
//    Console.WriteLine(file);
//}




//if (!File.Exists(@"C:\Users\sabir\Desktop\BB102Test\test.txt"))
//{
//    File.Create(@"C:\Users\sabir\Desktop\BB102Test\test.txt");

//}

//Directory.Delete(@"C:\Users\sabir\Desktop\BB102Test", true);


//File.Delete(@"C:\Users\sabir\Desktop\BB102Test\test.txt");

#endregion

#region Stream
//File.Create(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt");


//StreamWriter sw = new StreamWriter(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt",true);

//sw.WriteLine("Isgenderov");
//sw.WriteLine("Baratli");
//sw.WriteLine("Aliyev");

//sw.Close();

//try
//{
//    StreamReader sr = new StreamReader(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt");

//    string result = sr.ReadToEnd();

//    Console.WriteLine(result);
//}
//catch (Exception)
//{

//    throw;
//}
//finally
//{
//    sr.Close();

//}

//StreamReader sr = new StreamReader(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt");

//string result=sr.ReadToEnd();

//Console.WriteLine(result);

//sr.Close();


//StreamWriter sw = new StreamWriter(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt", true);

//sw.WriteLine("Isgenderov");
//sw.WriteLine("Baratli");
//sw.WriteLine("Aliyev");

//sw.Close();



//string result;

//using (StreamWriter sw = new StreamWriter(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt", true))
//{
//    sw.WriteLine("Salam");
//}
//using (StreamReader sr = new StreamReader(@"C:\Users\sabir\Desktop\BB102Test\testFile.txt"))
//{
//    result = sr.ReadToEnd();
//}


//Console.WriteLine(result);
//Console.WriteLine(sr.ReadLine());
//Console.WriteLine(sr.ReadLine());
//Console.WriteLine(sr.ReadLine()); 
#endregion

using Newtonsoft.Json;
using SystemIOStreamSerialize.Models;

//Category category=new Category { Name="Phone"};

//Product product = new Product { Id = 1, Name = "Iphone",Category=category };
//Product product1 = new Product { Id = 2, Name = "Xiaomi", Category = category };
//Product product2 = new Product { Id = 3, Name = "Samsung", Category = category };

//List<Product> products=new List<Product> { product,product1,product2};









//string result=JsonConvert.SerializeObject(products);


//using(StreamWriter sw=new StreamWriter(@"C:\Users\sabir\OneDrive\Рабочий стол\SystemIOStreamSerialize\SystemIOStreamSerialize\Files\jsonObjects.json"))
//{
//    sw.Write(result);
//}
//Console.WriteLine(result);

//File.Create(@"C:\Users\sabir\OneDrive\Рабочий стол\SystemIOStreamSerialize\SystemIOStreamSerialize\Files\jsonObjects.json");







//string json;

//using(StreamReader sr=new StreamReader(@"C:\Users\sabir\OneDrive\Рабочий стол\SystemIOStreamSerialize\SystemIOStreamSerialize\Files\jsonObjects.json"))
//{
//   json= sr.ReadToEnd();
//}


//List<Product> products=JsonConvert.DeserializeObject<List<Product>>(json);


//foreach (Product product in products)
//{
//    Console.WriteLine(product.Name);
//}

