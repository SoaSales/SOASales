package Services;
import Business.ProductsBll;
import Common.Trace;
import Entities.Books;

import javax.jws.WebMethod;
import javax.jws.WebService;
import javax.xml.ws.Endpoint;
import java.util.List;

/**
 * Created by Carla on 29/06/2015.
 */
@WebService()
public class ListingService {


  public static void main(String[] argv) {
    Object implementor = new ListingService ();
    String address = "http://localhost:9000/ListingService";
    Endpoint.publish(address, implementor);

    /*
    List<String> parameters = new ArrayList<String>();
    parameters.add("Linguagem");

    List<Book> booList = new ProductsBll().SearchProducts(parameters);

    System.out.println("OK");
    */
  }


  @WebMethod
  public Books ViewBook(int id){
    Trace.Log(ListingService.class.getName(), "GetBook", "Info", null);
    return new ProductsBll().GetProduct(id);
  }

  @WebMethod
  public List<Books> SearchBook(List<String> parameters){
    Trace.Log(ListingService.class.getName(), "GetBook", "Info", null);
    return new ProductsBll().SearchProducts(parameters);
  }

  @WebMethod
  public List<Books> GetAll(){
    Trace.Log(ListingService.class.getName(), "GetBook", "Info", null);
    return new ProductsBll().GetAll();
  }
}
