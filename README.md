"# codeExercise" 
TabCorp Coding Exercise – Marco Liporoni

Intro
The VS solution has been structured by separating a Domains and Web projects.
The solution also uses a Service and Repository layer. These layers have been created in the Web project for brevity. They could exist in a project of their own for modularity.

The Repository layer uses Entity Framework 6 to store entities into the current db context in memory, and eventually into the database.

The Service layer abstracts the services available for each entity. This is in line with a SOA approach.

Interfaces have also been created if we want to use Dependency Injection (not used for the brevity of this exercise).

The web application loads the json data from a file, and deserialises it into the Meeting/Race classes. Then the proper service is called to save the data into the current repository (in memory).

All binaries have been deleted, so the solution needs to be re-built.

Model

Two classes have been identified:
Meeting
Race
 

A Meeting has one or more races.
A Race can be in only one Meeting.
