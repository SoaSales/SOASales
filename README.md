# SOASales
SOASales - A SOA System for Research Purposes

SOASales is a SOA case study for research purposes, which implements an online store that allows consumers to manage accounts and search for products to purchase. This application is composed by several services, distributed through different providers and invoked by different consumers that communicate through an Enterprise Service Bus. The services are implemented using a diversity of technologies and features,following the key SOA characteristics.

## Folder structure
* Build - The binaries for all the applications
* Docs - Files related to the OnlineSales database, creation script and data
* src - The source projects for all the applications

## System deployment
### Software Requirements
* IIS
* Apache Tomcat (installed as a windows service)
* Mule standalone (installed as a windows service) to deploy the ESB workflows
* Active MQ
* MySQL

###Deployment
#### MySQL
On MySQL run the CreateScript.sql to create the database required for OnlineSales organization.
On file dataOnlineSales.csv data to populate the database is provided.

#### IIS Solution
* The system is configured to have both OnlineSales and OnlineBooks running on the same machine.

* Copy the following Folders available on Build\OnlineSales
ProductsService
OnlineSales
FindProductsService
BasicFindProductsService

* On IIS, under default web application, create the following web applications for each of the previous folders with the same name and pointing to the respective folder.
ProductsService,
OnlineSales,
FindProductsService,
BasicFindProductsService,

#### Apache Tomcat solution
* Configure apache tomcat to run on http://localhost:9090/
* Start the service.
* Copy the OnlineBooks folder available on Build\OnlineBooks on tomacat's 'webapps' folder.
* Tomcat should deploy the application automatically.
* Inside OnlineBooks folder, inside folder DataBase an SqLite database with data was included.

#### Mule solution
* Before deploying the mule application ensure other apps are running.

* On the 'apps' folder in the mule installation location place the OnlineSales.zip available on Build\OnlineSales. 
Mule should automatically detect OnlineSales.zip, unzip the file and deploy the solution.
The process may take a few minutes as mule is not constantly checking for new files.
* In 'logs' folder the logs for mule can be seen in file 'mule.log', entries will be recorded refering to the solution deployment.   
* At this point the system is deployed and functional with OnlineSales and OnlineBooks organizations.

#### Notes:

* The Ebay services are configured but they will fail authehtication on Ebay.
An account must be cretaed on Ebay and the account identifier must be set on the workflows: 

* On searchproduct.xml find the element <set-property propertyName="X-EBAY-SOA-SECURITY-APPNAME" value="" doc:name="SetPropertyHeader"/>

* set the value with the account identifier.

* On getproduct.xml do the same but on the element <set-property propertyName="X-EBAY-API-APP-ID" value="" doc:name="Property"/>

* The change on getproduct.xml will also be used for compareproducts.xml.
