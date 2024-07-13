namespace Techcareer.Models{

    public class Repository{

        private static readonly List<Product> _products = new();
        private static readonly List<Category> _category = new();

        static Repository(){
            _category.Add(new Category{CategoryId = 1, Name = "Web"});
            _category.Add(new Category{CategoryId = 2, Name = "Game"});

            _products.Add(new Product{ProductId = 1,Name="Asp.Net Bootcamp",Description="Güzel Bootcamp",Clock=50,IsActive=true,Image="1.png",CategoryId=1});
            _products.Add(new Product{ProductId = 2,Name="Full-Stack Bootcamp",Description="Güzel Bootcamp",Clock=50,IsActive=true,Image="3.png",CategoryId=1});
            _products.Add(new Product{ProductId = 3,Name="Unity Game Bootcamp",Description="Güzel Bootcamp",Clock=50,IsActive=true,Image="2.png",CategoryId=2});
        }

        public static List<Product> Products{get{return _products;}}

        public static void CreateProduct(Product entity){
            _products.Add(entity);
        }

        public static void EditProduct(Product updatedProduct){

            var entity = _products.FirstOrDefault(p=>p.ProductId == updatedProduct.ProductId);

            if(entity != null){
                entity.Name = updatedProduct.Name;
                entity.Clock = updatedProduct.Clock;
                entity.Description = updatedProduct.Description;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }
        }
        public static void DeleteProduct(Product deleteProduct){

            var entities = _products.FirstOrDefault(p=>p.ProductId == deleteProduct.ProductId);

            if(entities != null){
                _products.Remove(entities);
            }
            
        }
        public static List<Category> Categories{get{return _category;}}

        public static Product? GetById(int? id){
            return _products.FirstOrDefault(b=>b.ProductId == id);
        }
    }
}