# USParksMVC

Using this MVC allows the user to look up parks within the database, create new ones, edit them, and delete them.
    User's can only edit and delete their own parks and nature but can edit and delete attractions found throughout the parks and also remove and add nature to any park.

## Features
- Full CRUD of Parks, Nature, and Attractions
- Able to assign nature and attractions to parks
- Contains seeded content of some known parks, nature, and attractions in the USA

## Seeding instructions
To obtain the seed content
1. Within visual studio open up tools
2. Go to NuGet Package Manager
```sh
Package Manager Console
```
3. Within the default project in the Package Manager Console at the top switch to:
```sh
USParks.Data
```
4. Type in: 
```sh
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
```
4. Type in: 
```sh
Update-Database
```

## How to use
1. Open up browser with the MVC
2. Next make an account with an email and password (the password must have at least 6 characters, a capital letter, a number, and a special character)
3. Browse the website (While creating new parks/attractions/nature users can upload images for those items.  The images have a limit of 5mb and support both jpg and png.)



## USParksMVC Author
- Ethan Starling
