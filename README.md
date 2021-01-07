# LibraryApplication
Library Application with .Net Core 

How To Run .Net Backend with Anroid Application on localhost

To run the application properly these steps should be completed in the same order.

1- MSSQL Database should be installed and all the tables with required columns in .Netcore classes should be created.
2- Database Server name on .Net core DEV_Context class should be changed with your MSSQL Server name.
3- Firewall permissions should be approved for both .Net core and Android Emulator.
4- .Net core backend application should run as a C# project not with IIS Express. (As the server wil be consumed on localhost by emulator).
5- Android Application should run on Android Emulator after localhost permission approved.
