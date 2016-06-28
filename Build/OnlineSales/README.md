# SOASales - Build
* OnlineSales.zip - ESB application
* OnlineSales - Website application that consumes the services provided by ESB 
* ProductsService - wcf services
* FindProductsService - FindProductsService Service
* BasicFindProductsService - Simplefied version of search method in FindProductsService

- FindProductsService, that is consumed by the ESB, should be on the following url http://localhost/FindProductsService/    
on the following url a help page about the methods provided va be found http://localhost/FindProductsService/help


- BasicFindProductsService, that is consumed by the ESB, should be on the following url http://localhost/BasicFindProductsService/
a help page can be found on 
http://localhost/BasicFindProductsService/help

- ProductsService, used by the ESB, should be on the following url
http://localhost/ProductsService/
Further info on 
http://localhost/ProductsService/Services/

##Notes:

* ESB Application

The Ebay services are configured but they will fail on authehtication on Ebay.
An account must be cretaed on Ebay and the account identifier must be set on the workflows: 

- On searchproduct.xml find the element 
<set-property propertyName="X-EBAY-SOA-SECURITY-APPNAME" value="" doc:name="SetPropertyHeader"/>

set the value with the account identifier.

- On getproduct.xml do the same but on the element
<set-property propertyName="X-EBAY-API-APP-ID" value="" doc:name="Property"/>

The change on getproduct.xml will also be used for compareproducts.xml.