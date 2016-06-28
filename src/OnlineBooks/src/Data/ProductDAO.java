package Data;

import Common.Trace;
import Entities.*;
import org.hibernate.ejb.HibernatePersistence;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.spi.PersistenceProvider;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by Carla on 21/06/2015.
 */
public class ProductDAO {

    public ProductDAO() {
    }

    public List<Books> SearchBooks(List<String> parameters){

        Trace.Log(ProductDAO.class.getName(), "Search Books Request", "Info", null);

        List<Books>bookList = new ArrayList<>();
        EntityManager entityManager = null;

        try {
        String query = "from Books where title like :title or description like :description or author like :author";
        PersistenceProvider persistenceProvider = new HibernatePersistence();
        EntityManagerFactory entityManagerFactory = persistenceProvider.createEntityManagerFactory("NewPersistenceUnit", new HashMap());
        entityManager = entityManagerFactory.createEntityManager();

            for(String param : parameters) {
                bookList.addAll(entityManager.createQuery(query, Books.class)
                        .setParameter("title", "%" + param + "%")
                        .setParameter("description", "%" + param + "%")
                        .setParameter("author", "%" + param + "%")
                        .getResultList());
            }

        }catch (Exception ex){
            Trace.Log(ProductDAO.class.getName(), "SearchBooks", "Severe", ex);
        }finally {
            if (entityManager.isOpen()) {
                entityManager.close();
            }
        }
        return bookList;
    }

    public Books GetBook(int productId){

        Trace.Log(ProductDAO.class.getName(), "GetBook", "Info", null);

        try {
            String query = "from Books where bookId = :id";
            PersistenceProvider persistenceProvider = new HibernatePersistence();
            EntityManagerFactory entityManagerFactory = persistenceProvider.createEntityManagerFactory("NewPersistenceUnit", new HashMap());
            EntityManager entityManager = entityManagerFactory.createEntityManager();
            Books book = entityManager.createQuery(query, Books.class).setParameter("id", productId).getSingleResult();
            entityManager.close();

           return book;
        }catch (Exception ex){
            Trace.Log(ProductDAO.class.getName(), "GetBook", "Severe", ex);
        }
        return null;
    }

    public List<Books> GetAll(){

        Trace.Log(ProductDAO.class.getName(), "GetAll", "Info", null);

        try {
            String query = "from Books";
            PersistenceProvider persistenceProvider = new HibernatePersistence();
            EntityManagerFactory entityManagerFactory = persistenceProvider.createEntityManagerFactory("NewPersistenceUnit", new HashMap());
            EntityManager entityManager = entityManagerFactory.createEntityManager();
            List<Books> bookList = entityManager.createQuery(query, Books.class).getResultList();
            entityManager.close();

            return bookList;
        }catch (Exception ex){
            Trace.Log(ProductDAO.class.getName(), "GetAll", "Severe", ex);
        }
        return null;
    }
}
