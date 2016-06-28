package Business;

import Data.ProductDAO;
import Entities.Books;

import java.util.List;

/**
 * Created by Carla on 21/06/2015.
 */
public class ProductsBll {

    public List<Books> SearchProducts(List<String> parameters){
           ProductDAO dao = new ProductDAO();

           return dao.SearchBooks(parameters);
    }

    public Books GetProduct(int productId){
        ProductDAO dao = new ProductDAO();

        return dao.GetBook(productId);
    }

    public List<Books> GetAll(){
        ProductDAO dao = new ProductDAO();

        return dao.GetAll();
    }
}
