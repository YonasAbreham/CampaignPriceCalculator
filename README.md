## CampaignPriceCalculator REST API and UnitTest

### Description ###

This project calculate campaigns base on product combination and campaigns based on volume when a customer is doing checkout.In this project we have to
main functionality 

### 1. Combo campaigns: ###
.which is the customer must combne a minimum of two products with/with out combined itself to get the campaign price.	
 Note: If the customer adds three products to their basket and all of them are in a campaign, the customer only pays the campaign price for two of them and will pay original price for the third product
		
### 2. Volume campaigns: ###
.which is the customer needs to add numbers of Items to their basket to trigger the campaign price,but the customer needs to buy two to get    the campaign price.
Note:  If the customer adds a third item to the basket, the customer needs to pay regular price for the third item and campaign price for the rest

*** The unique identifier of the product is EAN code

Example list of products EAN Code with price:
* EAN = 5000112637922, Price = 40
* EAN = 5000112637939,  Price = 45
* EAN = 7310865004703,  Price = 50
* EAN = 7340005404261,  Price = 55
* EAN = 7000112637937,  Price = 65
* EAN = 8711000530085,  Price = 40
* EAN = 7310865004703,  Price = 50 
* EAN = 55345112637937, Price = 65

### Requirements ###
.NET 6

### How to Run ###
- Open CampaignPriceCalculator.sln in the Backend directory by Visual Studio 2022 and run CampaignPriceCalculator.API project.

![GitHub Logo](https://github.com/YonasAbreham/CampaignPriceCalculator/blob/master/img/Capture.JPG) 
