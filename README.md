# English-Query-To-DB-Query
Search is common in any Application.  Applications will not have capability to understand the Natural Language like English. This is a Proof of Concept(POC) Application to demonstrate for converting Natual Language(english)  Query to Database Query.
The POC uses CSharp as programming Language but it can be easily converted into any other programming language like Python , Java etc...

The POC Application contains 

 - Weather.db which contains Tempreature's in different cities.
 - Code  To Convert Natural Language Query To Database Query.

Ex NLP Query:-
What is the Tempreature in Delhi

Application Converts Mapped Database Query and fetches the records
Select Tempreature from Weather where cityname='Delhi'

Where Tempreature is column name in Weather Table.
