namespace CadastroProdutos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;

            string path = @"C:\DadosEstoque\";
            string file = "products.txt";

            List<Product> products = new List<Product>();

            do
            {
                option = Menu();

                switch (option)
                {
                    case 1:
                        products.Add(CreateProduct());
                        SaveFile(products, path, file);
                        break;
                    case 2:
                        ShowAll(products);
                        break;
                }
            }while (option != 0);
            
        }

        static int Menu()
        {
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine("======Estoque de Produtos======");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Mostrar Produtos");
                Console.WriteLine("0 - Sair");
                op = int.Parse(Console.ReadLine());
            } while (op < 0 || op > 2);

            return op;
        }

        static Product CreateProduct()
        {
            Console.Clear();
            Console.WriteLine("======Cadastro do Produtos======");

            Console.WriteLine("Informe um id:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme a descrição do produto:");
            string description = Console.ReadLine();

            Console.WriteLine("\nInforme o preço do produto:");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme a quantidade disponível:");
            int qtd = int.Parse(Console.ReadLine());

            return new Product(id, description, price, qtd);
        }

        static void ShowAll(List<Product> list)
        {
            Console.Clear();
            Console.WriteLine("======Todos os Produtos=====\n");
            foreach (var product in list)
            {
                Console.WriteLine(product.ToString());
                Console.WriteLine("\n============================\n");
            }

            Console.ReadKey();
        }

        static void SaveFile(List<Product> l, string path, string file)
        {
            CheckPath(path, file);

            StreamWriter sw = new StreamWriter(path + file);

            foreach(var product in l)
            {
                sw.WriteLine(product.ToString());
            }

            sw.Close();
        }

        static List<Product> LoadFile(string path, string file)
        {
            CheckPath(path, file);

            List<Product> l = new List<Product>();
            foreach (var linha in File.ReadAllLines(path+file)) 
            {
                string[] fields = linha.Split(";");

                int id = int.Parse(fields[0]);
                string description = fields[1];
                double price = double.Parse(fields[2]);
                int qtd = int.Parse(fields[3]);

                l.Add(new Product(id, description, price, qtd));
            }

            return l;
        }

        static void CheckPath(string path, string file)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(path + file))
            {
                File.Create(path + file);
            }
        }
    }
}
