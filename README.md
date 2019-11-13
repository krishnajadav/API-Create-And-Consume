# WebApi Create And Consume
Firstly, the project contains 2 sub projects,
1) <b>API CRUD DEMO</b> :- This solution consists actual WebApi with crud operation.

2) <b>MVC_Product</b>   :- This project is for sending and receiving WebApi requests and you can also call this WebApi by POSTMAN.    

# How To Configure

1) Open ProductDB.sql file into MSSQL Server and run this whole sql file,if you would find any error then remove file location lines in sql file.

2) Check Entityframework in API CRUD DEMO project and change the connection string in web.config file.

3) Make sure you first run WebApi project then consuming project.

# How It Works

1) You can run MVC_Prduct project and check it works or not but make sure you run Api project concurrently.

<img src="https://i.ibb.co/JpjmtjJ/Product-API.png" width="50%" height="60%"/>

2) You can also pass data to webapi with use of POSTMAN. 

<img src="https://i.ibb.co/pJv5TXq/Postman.png" width="100%" height="80%"/>
