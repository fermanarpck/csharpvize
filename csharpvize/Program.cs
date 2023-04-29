public class Category
{
    public string Name { get; set; }
    public List<Category> SubCategories { get; set; }

    public Category(string name)
    {
        Name = name;
        SubCategories = new List<Category>();
    }

    public List<Category> GetAllSubCategories()
    {
        List<Category> result = new List<Category>();
        foreach (Category subCategory in SubCategories)
        {
            result.Add(subCategory);
            result.AddRange(subCategory.GetAllSubCategories());
        }
        return result;
    }

    static void Main(string[] args)
    {
        Category elektronikCategory = new Category("Elektronik");
        Category bilgisayarCategory = new Category("Bilgisayarlar");
        Category telefonCategory = new Category("Telefonlar");
        Category laptopCategory = new Category("Laptoplar");

        Category giyimcategory = new Category("giyim");
        Category tshirtcategory = new Category("tshirt");
        Category pantoloncategory = new Category("pantolon");
        Category gomlekcategory = new Category("gomlek");

        elektronikCategory.SubCategories.Add(bilgisayarCategory);
        elektronikCategory.SubCategories.Add(telefonCategory);
        bilgisayarCategory.SubCategories.Add(laptopCategory);

        giyimcategory.SubCategories.Add(tshirtcategory);
        giyimcategory.SubCategories.Add(pantoloncategory);
        giyimcategory.SubCategories.Add(gomlekcategory);

        List<Category> ElektronikSubCategories = elektronikCategory.GetAllSubCategories();
        List<Category> GiyimSubCategories = giyimcategory.GetAllSubCategories();

        Console.WriteLine("Elektronik Kategorisi Alt Kategorileri:");
        foreach (Category category in ElektronikSubCategories)
        {
            Console.WriteLine(category.Name);
        }

        Console.WriteLine("Giyim Kategorisi Alt Kategorileri:");
        foreach (Category category in GiyimSubCategories)
        {
            Console.WriteLine(category.Name);
        }

        Console.ReadKey();
    }

}

