# The dog API

Clone Github repon så att ni har det lokalt

I den cloned mapp (eg. c:\GitHub\Assigment) skåpa ett ASP.NET Core Web API
```powershell
dotnet new webapi
``` 

## Uppgift

Skåpa ett API som gör det möjligt att hämnta och uppdatera [hundraser](https://en.wikipedia.org/wiki/List_of_dog_breeds) [[se](https://sv.wikipedia.org/wiki/Alfabetisk_lista_%C3%B6ver_hundraser)].

Hundraserna sparas som json filer i en mapp på disken som hetter *DogFiles*, där ska finnas en fil per hundras. När man gör en action i APIet ska filen på disk läsas, skåpas, uppdateras ellers tagis bort.

Filerna i mappen är i formatet json, innehållar följande parameter: breedName, wikipediaUrl, description

APIet skall bestå av två bas URL for hund ressursen (dogs, dogs/[ras])

Det ska via APIet vara möjligt att:

* Få en lista alla hundraser (GET: /dogs) utan detaljer
* Skåpa en ny hundras (POST: /dogs)
* Ta bort alla hundraser (DELETE: /dogs)
* Få alla detaljer om en hundras (GET: /dogs/[ras])
* Uppdatera information om en ras (PUT: /dogs/[ras])
* Ta bort en specifik ras (DELETE: /dogs/[ras])

Försök att få APIet att retunera data i JSON, se till att Content-type (HTTP response headern) stämmer.

## Links
[Web API Design](https://pages.apigee.com/rs/apigee/images/api-design-ebook-2012-03.pdf)

[Json.NET](https://www.newtonsoft.com/json)

[MSDN: Create a Web API using ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api)

[Postman](https://www.getpostman.com), bra verktyg till att testa REST APIer med

## Hints
Lägg till Nuget parketet: *Newtonsoft.Json* 

Där finns en mapp som hettar *Models* och denna innehåller en C# klass som är en model for  json-filerna i DogFiles-mappan, och kan använnas till att parsa json filen med.

Implementationen for Get-controllern kan se ut så:

```csharp
[HttpGet]
public IEnumerable<string> Get()
{
    var files = System.IO.Directory.GetFiles("DogFiles","*.json");
    List<Dog> dogs = new List<Dog>(); 
    foreach(var file in files){
        dogs.Add(JsonConvert.DeserializeObject<Dog>(System.IO.File.ReadAllText(file)));
    }
    return dogs.Select(d => d.BreedName).ToArray();
}
```
