# ReviewSystem
## Description
This project is an ASP.NET Core Web API for managing a product catalog, allowing users to interact with products, categories, sellers, and customer reviews. This API serves as a foundational backend for an e-commerce or review-based application, offering a flexible structure to manage and retrieve product-related information efficiently. The database schema is designed to facilitate relationships between various entities:
- **Products**: Each product includes details like title, production date, and price.
- **Categories**: Products are associated with multiple categories, creating a many-to-many relationship.
- **Sellers**: Products can have multiple sellers, also forming a many-to-many relationship.
- **Reviews**: Customers (reviewers) can leave reviews with a rating and text for products, linking products to reviewers.
  
## Key features:
- **Many-to-Many Relationships**: Implemented using junction tables (ProductCategories and ProductSellers) to handle associations.
- **RESTful API Endpoints**: Provides CRUD operations for each entity (Products, Categories, Sellers, Reviewers, and Reviews) with endpoints optimized for efficiency.
- **Data Validation and Error Handling**: Ensures robust API interactions and validates incoming data to maintain database integrity.
  

## Technologies
1. ASP.NET Core APIs
2. C#
3. Entity framework
4. LinQ
5. Repository and UnitOfWork Pattern
6. Postman
7. Swagger
8. MS SQL Server

## Database schema
![image](https://github.com/user-attachments/assets/ff51b126-0e4e-40d0-a07d-de6d9a5d8aa3)

## Endpoints
### Categories
![image](https://github.com/user-attachments/assets/4f2900a3-1f90-44ed-afef-0775b3da7466)

### Products
![image](https://github.com/user-attachments/assets/6c5637f0-b563-48d5-ab27-547a20df7a6d)

### Review
![image](https://github.com/user-attachments/assets/cb53e241-1669-4361-bc94-7fb8859d7344)

### Reviewer
![image](https://github.com/user-attachments/assets/87999898-4f94-4fe9-a60c-0a085eafb4f4)

### Seller
![image](https://github.com/user-attachments/assets/5fb33b3a-16a6-4fda-9c83-ca30d216ef5a)



