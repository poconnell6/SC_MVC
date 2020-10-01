# SC_MVC
Migration of Earlier WinForms site to ASP.NET framework MVC/EF/Identity2.1(WIP)

* Good seperation of concerns, most/all logic at controller level, layout at 
  page level, formatting at css level, etc.
* Manual migration and integration of dotnet identity.
* Extension of Identity "users" model and read/write of custom data through
  UserManager
* Role based auth at controller, action, and function levels.
* I now have a Solid understanding of the basics of the identity framework in 
  specific and MVC concepts in general. 

* Shopping cart datamodel and architecture done, controller inplementation WIP. 
  (Demonstrates understanding of EF/LINQ)
* Cart table is essentially just a mapping table for UserID and BookID  
  (it has a PK since duplicate composites are expected).
  
    - Adding a book to the cart always just adds a row.
  
    - Viewing the cart filters by UserId, (Count; group by UserId - to produce 
      number of a given book in a given users cart) and the joins with the books 
      table to to get the actual name of the book finally displaying the 
      "friendly name" and number in cart to the user.
  
    - Removing a book(s) works similarly to viewing, except instead of of joining 
      and viewing you just filter for top(N) records and take those PKs and drop 
      the record.
  
* When designed and implemented the "Checkout" function combines the users 
  "Cart" data with the "AddAddressViewModel" data and the pricing data in 
  "Books" to produce a printable/emailed receipt for the user and passes the
  Cart data to the Order Controller.
* (When designed and implemented ) The Order Controller then generates an 
  OrderID and adds that to the mapping tables for UserID+OrderDate and 
  BookID+NumBooks.
  
    - Displaying past orders works like the "Sale Items" section of the 
      Works/Index page except it it is nested one more deep. The users orders are
      sorted by date and then listed (slightly indented) one item per line.
  
* I am going to keep working on this in any case as i think it might make a 
  decent portfolio piece.
  
  
