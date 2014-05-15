traitify.net
============
Traitify is a .NET 4 wrapper for the Traitify Developer's API.

## Installation
Include the TraitifyLibrary in your Visual Studio solution.

##Usage

#### Config
```csharp
  Traitify traitify = new Traitify("https://api-domain.com", "--Your Public Key--", "--Secret Key--", "v1");
```

#### Create Assessment
```csharp
  String deck_id = "--Your Deck Id--";
  Assessment assessment = traitify.CreateAssessment(deck_id);
  Console.WriteLine("AssessmentId: " + assessment.id);
```


